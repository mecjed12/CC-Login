using ApplicationData;
using ApplicationData.attribute;
using ApplicationData.repo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ApplicationLogic
{
	public class ApplicationLogicController
	{

		readonly DcvEntities Entities;

		public ApplicationLogicController(DcvEntities entities)
		{
			Entities = entities;
		}

		/// <summary>
		/// Gets a list of all the MappableProperties from className
		/// </summary>
		/// <param name="className"></param>
		/// <returns>List of MappableProperties from className</returns>
		public List<MappableProperties> GetProperties(string className)
		{
			var type = GetTypesFromApplications().FirstOrDefault(x => x.Name.Equals(className, StringComparison.InvariantCultureIgnoreCase));

			return GetProperties(type);
		}

		/// <summary>
		/// Gets a list of all the MappableProperties from type
		/// </summary>
		/// <param name="type"></param>
		/// <returns>List of MappableProperties from type</returns>
		public List<MappableProperties> GetProperties(Type type)
		{
			var props = new List<MappableProperties>();

			if (type != null)
			{
				if (Activator.CreateInstance(type) is IApplicationClass appClass)
				{
					props = appClass.GetProperties().OrderBy(x => x.GetCustomAttribute<ApplicationPropertyAttribute>().Index).Select(x => CreateMappable(x)).ToList();
				}
			}

			return props;
		}

		/// <summary>
		/// Get a list of all the application types 
		/// </summary>
		/// <returns>A List of ApplicationType</returns>
		public List<ApplicationType> GetApplicationTypes()
		{
			var output = new List<ApplicationType>();
			var types = GetTypesFromApplications();
			types.ForEach(type =>
			{
				output.Add(new ApplicationType() {
					Name = type.Name,
					DisplayName = type.GetCustomAttribute<DisplayAttribute>().Name != null ? type.GetCustomAttribute<DisplayAttribute>()?.Name : type.Name
				});
			});
			return output;
		}

		/// <summary>
		/// Gets a list of Types that inherent from IApplicationClass
		/// </summary>
		/// <returns>List of types that inherent from IApplicationClass</returns>
		public List<Type> GetTypesFromApplications()
		{
			var type = typeof(IApplicationClass);
			return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => type.IsAssignableFrom(x) && x != type).ToList();
		}


		/// <summary>
		/// Creates the MappableProperties from the PropertyInfo
		/// </summary>
		/// <param name="info"></param>
		/// <returns>MappableProperties</returns>
		public MappableProperties CreateMappable(PropertyInfo info)
		{
			return new MappableProperties()
			{
				PropName = info.Name,
				DisplayName = info.GetCustomAttribute<ApplicationPropertyAttribute>()?.DisplayName == null ? info.Name : info.GetCustomAttribute<ApplicationPropertyAttribute>().DisplayName,
				Required = info.GetCustomAttribute<ApplicationPropertyAttribute>().Required
			};
		}

		/// <summary>
		/// Gets the Repository of T
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">Used to get T</param>
		/// <returns>Repository of T</returns>
		public Repository<TRepo> GetRepository<TRepo>(TRepo t) where TRepo : class
		{
			var type = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).FirstOrDefault(y => y.IsSubclassOf(typeof(Repository<TRepo>)));
			if (Activator.CreateInstance(type, Entities) is Repository<TRepo> repo)
			{
				return repo;
			}
			return null;
		}

		/// <summary>
		/// Add object from the stream to the Database
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="properties"></param>
		/// <param name="className"></param>
		/// <returns>The amount of lines in the stream,
		/// the amount of objects added,
		/// a dictonary of Exception with the line the happend</returns>
		public (int Lines, int AddedCount, Dictionary<int, Exception> Errors) AddObjectsFromCSV(Stream stream, List<MappableProperties> properties, string className)
		{
			//Initalize returns
			int lines = 0;
			int added = 0;
			Dictionary<int, Exception> wrongLines = new Dictionary<int, Exception>();

			Type type = GetTypesFromApplications().FirstOrDefault(x => x.Name.Equals(className, StringComparison.InvariantCultureIgnoreCase));

			if (type == null)
				throw new InvalidTypeException();

			using (var reader = new StreamReader(stream))
			{
				int index = 0;
				while (reader.Peek() != -1)
				{
					lines++;
					var line = reader.ReadLine();
					index++;

					//Get Separator
					List<char> delimiters = new List<char>{';', ',', '|'};
					Dictionary<char, int> counts = delimiters.ToDictionary(key => key, value => 0);
					delimiters.ForEach(d =>
					{
						counts[d] = line.Count(t => t == d);
					});

					var args = line.Split(counts.Aggregate((l, r) => l.Value > r.Value ? l : r).Key);

					try
					{
						if (Activator.CreateInstance(type) is IApplicationClass appClass)
						{
							var appClassRelations = appClass.GetType().GetProperties().Where(x => x.IsDefined(typeof(RelationAttribute))).ToList();

							var subClasses = appClass.GetSubclasses();

							AddProperties(properties, args, appClass);

							if (GetExisting(type, appClass) != null) continue;

							foreach (var sub in subClasses)
							{
								Type subType = sub.GetType();

								if (Activator.CreateInstance(subType) is IApplicationSubclass subClass)
								{
									var subClassRelations = subClass.GetType().GetProperties().Where(x => x.IsDefined(typeof(RelationAttribute))).ToList();

									bool changed = AddProperties(properties, args, subClass);

									//Only create Relations when subClass isn't empty
									if (changed)
									{
										object existingSub = GetExisting(subType, subClass);

										var keys = subType.GetProperties().Where(x => x.IsDefined(typeof(RelationAttribute))).ToList();
										keys.ForEach(key =>
										{
											//Create RelationClass when appClass and subClass are connected using a RelationClass
											if (typeof(IList).IsAssignableFrom(key.PropertyType) && key.PropertyType.GenericTypeArguments[0].IsDefined(typeof(RelationAttribute)))
											{
												if (Activator.CreateInstance(key.PropertyType.GenericTypeArguments[0]) is object relationClass)
												{
													var relations = relationClass.GetType().GetProperties().Where(x => x.IsDefined(typeof(RelationAttribute))).ToList();

													//Add the appClass/subClass to the relationClass
													//Add the relationClass to the appClass/subClass or add the relationClass to the list in appClass/subClass 
													if (existingSub != null)
													{
														AddRelation(relations, relationClass, existingSub);
													}
													else
													{
														AddRelation(relations, relationClass, subClass);
													}

													AddRelation(relations, relationClass, appClass);

													AddRelation(appClassRelations, appClass, relationClass);
													AddRelation(subClassRelations, subClass, relationClass);
												}
											}
											else //Make connection when appClass and subClass are connected directly
											{
												//Add the appClass/subClass to the appClass/subClass
												AddRelation(appClassRelations, appClass, subClass);
												AddRelation(subClassRelations, subClass, appClass);
											}
										});
									}
								}
							}
							Entities.Add(appClass);
							added++;
						}
					}
					catch (Exception e)
					{
						wrongLines.Add(index, e);
					}
				}
			}
			Entities.SaveChanges();
			return (lines, added, wrongLines);
		}

		/// <summary>
		/// Get obj from database if it exists
		/// </summary>
		/// <param name="type"></param>
		/// <param name="obj"></param>
		/// <returns>obj from database, or null when obj doesn't exist on database</returns>
		private object GetExisting(Type type, object obj)
		{
			dynamic dynamicAppClass = Convert.ChangeType(obj, type);
			var typeRepository = GetRepository(dynamicAppClass);

			var existing = typeRepository.GetOne(dynamicAppClass);
			return existing;
		}

		/// <summary>
		/// Adds the properties from args to the obj
		/// </summary>
		/// <param name="properties"></param>
		/// <param name="args"></param>
		/// <param name="obj"></param>
		/// <returns>true when a property of obj changed from the default value</returns>
		private bool AddProperties(List<MappableProperties> properties, string[] args, object obj)
		{
			bool changed = false;
			properties.ForEach(prop =>
			{
				var p = obj.GetType().GetProperty(prop.PropName);
				if (p != null && prop.ColumnValue != null)
				{
					p.SetValue(obj, GetValue(p.PropertyType, args, prop.ColumnValue));
					changed = changed ? changed : p.GetValue(obj) != null;
				}
			});
			return changed;
		}

		/// <summary>
		/// Adds the value to the obj, adds the value to the list in obj or adds the id of the value to the obj
		/// </summary>
		/// <param name="properties"></param>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		/// <returns>The amount of relations added to obj, or -1 when no relation was added</returns>
		private static int AddRelation(List<PropertyInfo> properties, object obj, object value)
		{
			int added = 0;
			properties.ForEach(rel =>
			{
				if ((int)value.GetType().GetProperty("Id").GetValue(value) != 0)
				{
					if (rel.PropertyType == typeof(int) && rel.GetCustomAttribute<RelationAttribute>()?.Relation == value.GetType())
					{
						rel.SetValue(obj, value.GetType().GetProperty("Id").GetValue(value));
						added++;
					}
				}
				else
				{
					if (rel.PropertyType == value.GetType())
					{
						rel.SetValue(obj, value);
						added++;
					}
					else if (typeof(IList).IsAssignableFrom(rel.PropertyType) && rel.PropertyType.GenericTypeArguments[0] == value.GetType())
					{
						var temp = rel.GetValue(obj) as IList;
						if (temp == null)
							temp = Activator.CreateInstance(rel.PropertyType) as IList;//Create List of rel.PropertyType when rel is null
						temp.Add(value);
						rel.SetValue(obj, temp);
						added++;
					}
				}
			});
			return added == 0 ? -1 : added;
		}

		/// <summary>
		/// Gets the value from the array 
		/// </summary>
		/// <param name="type"></param>
		/// <param name="args"></param>
		/// <param name="position"></param>
		/// <returns>The value of the position in args as type, or null when position is null</returns>
		private object GetValue(Type type, string[] args, int? position)
		{
			var codes = (TypeCode[])Enum.GetValues(typeof(TypeCode));

			//Get the base type when type is nullable
			type = Nullable.GetUnderlyingType(type) ?? type;

			if (position == null || position >= args.Length)
				return null;

			var value = args[(int)position];

			if (string.IsNullOrWhiteSpace(value))
				return null;

			if (type == typeof(string))
			{
				return value;
			}

			if (type.BaseType == typeof(Enum))
			{
				return Enum.Parse(type, value);
			}

			foreach (var code in codes)
			{
				if (Type.GetTypeCode(type) == code && code != TypeCode.Object)
				{
					try
					{
						return Convert.ChangeType(value, type);
					}
					catch (FormatException)
					{
						throw new FormatException($"{value}");
					}
				}
			}
			return null;
		}
	}

	public struct ApplicationType
	{
		public string Name { get; set; }
		public string DisplayName { get; set; }
	}
}
