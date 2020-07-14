using ApplicationData;
using ApplicationData.attribute;
using ApplicationData.model;
using ApplicationData.repo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

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
			var type = GetApplicationTypes().FirstOrDefault(x => x.Name.Equals(className, StringComparison.InvariantCultureIgnoreCase));

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

			if(type != null)
			{
				if(Activator.CreateInstance(type) is IApplicationClass appClass)
				{
					props = appClass.GetProperties().Select(x => CreateMappable(x)).ToList();
				}
			}

			return props;
		}

		/// <summary>
		/// Gets a list of Types that inherent from IApplicationClass
		/// </summary>
		/// <returns>List of types that inherent from IApplicationClass</returns>
		public List<Type> GetApplicationTypes()
		{
			var type = typeof(IApplicationClass);
			return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => type.IsAssignableFrom(x) && x != type).ToList();
		}

		/// <summary>
		/// Gets the Repository of T
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t"></param>
		/// <returns>Repository of T</returns>
		public Repository<T> GetRepository<T>(T t) where T : class
		{
			var u = typeof(T);
			var type = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).FirstOrDefault(y => y.IsSubclassOf(typeof(Repository<T>)));
			if(Activator.CreateInstance(type, Entities) is Repository<T> repo)
			{
				return repo;
			}
			return null;
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

		public void AddObjectsFromCSV(Stream stream, List<MappableProperties> properties, string className)
		{
			var type = GetApplicationTypes().FirstOrDefault(x => x.Name.Equals(className, StringComparison.InvariantCultureIgnoreCase));
			
			if(type == null)
				throw new InvalidTypeException();

			using(var reader = new StreamReader(stream))
			{
				while(reader.Peek() != -1)
				{
					var created = DateTime.Now;

					var line = reader.ReadLine();
					var args = line.Split(';');

					try {

						if (Activator.CreateInstance(type) is IApplicationClass appClass)
						{
							var subClasses = appClass.GetSubclasses();

							//TODO change this 
							dynamic o = Convert.ChangeType(appClass, type);

							foreach (var prop in properties)
							{
								var p = type.GetProperty(prop.PropName);
								if (p == null)
									continue;
								p.SetValue(appClass, GetValue(p.PropertyType, args, prop.ColumnValue));
							}

							//TODO find bettername and change this
							dynamic t = Convert.ChangeType(appClass, type);
							var exitingAppClass = GetRepository(t);
							var e = exitingAppClass.Exists(o);

							if (exitingAppClass == null)
							{
								Entities.Add(appClass);
								Entities.SaveChanges();
							}
							else
							{
								appClass = exitingAppClass;
							}

							//TODO make this look better
							foreach (var sub in subClasses)
							{
								var subType = sub.GetType();
								if (Activator.CreateInstance(subType) is IApplicationSubclass subClass)
								{
									bool changed = false;
									foreach (var prop in properties)
									{
										var p = subType.GetProperty(prop.PropName);
										if (p == null)
											continue;
										p.SetValue(subClass, GetValue(p.PropertyType, args, prop.ColumnValue));
										changed = true;
									}

									if (changed)
									{
										var existingSubClass = GetRepository(subClass).Exists(subClass);
										if (existingSubClass != null)
										{
											subClass = existingSubClass;
										}
										else
										{
											Entities.Add(subClass);
										}

										var keys = subType.GetProperties().Where(x => x.IsDefined(typeof(RelationAttribute))).ToList();
										foreach (var key in keys)
										{
											if (key.GetCustomAttribute<RelationAttribute>()?.Relation == appClass.GetType())
											{
												key.SetValue(subClass, type.GetProperty("Id").GetValue(appClass));
											}

											Entities.SaveChanges();

											if (typeof(IList).IsAssignableFrom(key.PropertyType))
											{
												if (Activator.CreateInstance(key.PropertyType.GenericTypeArguments[0]) is object subSubClass)
												{
													var subKeys = subSubClass.GetType().GetProperties().Where(x => x.IsDefined(typeof(RelationAttribute))).ToList();

													var existingSubSubClass = GetRepository(subSubClass).Exists(subSubClass);
													if (existingSubSubClass != null)
													{
														continue;
													}

													foreach (var subKey in subKeys)
													{
														//TODO make this better and better to look at
														if (subKey.GetCustomAttribute<RelationAttribute>()?.Relation == appClass.GetType())
														{
															subKey.SetValue(subSubClass, type.GetProperty("Id").GetValue(appClass));
														}
														else if (subKey.GetCustomAttribute<RelationAttribute>()?.Relation == subClass.GetType())
														{
															subKey.SetValue(subSubClass, subType.GetProperty("Id").GetValue(subClass));
														}
													}
													Entities.Add(subSubClass);
													Entities.SaveChanges();
												}
											}
										}
									}
								}
							}
						}
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
						throw e;
					}
				}
			}
			Entities.SaveChanges();
		}

		//https://localhost:44375/registration/person
		public void AddCoursesFromCSV(Stream fileStream, CourseConfig config)
		{
			//TODO
			//using(var reader = new StreamReader(fileStream, Encoding.UTF8, true))
			//{
			//	while(reader.Peek() != -1)
			//	{
			//		var line = reader.ReadLine();
			//		Debug.WriteLine(line);
			//		var args = line.Split(';');

			//		var course = new Course()
			//		{
			//			Title = GetValue(args, config.Title),
			//			Category = GetValue(args, config.Category),
			//			Description = GetValue(args, config.Description),
			//			Start = GetValueDate(args, config.Start),
			//			End = GetValueDate(args, config.End),
			//			MinParticipants = GetValueInt(args, config.ParticipantsMin),
			//			MaxParticipants = GetValueInt(args, config.ParticipantsMax),

			//			CreatedAt = DateTime.Now
			//		};

			//		var c = Entities.Courses.FirstOrDefault(x => x.Title.Equals(course.Title) && x.Category.Equals(course.Category));

			//		if(c != null)
			//			continue;

			//		Entities.Courses.Add(course);
			//	}
			//}
			//Entities.SaveChanges();
		}

		/// <summary>
		/// Gets the value from the array 
		/// </summary>
		/// <param name="type"></param>
		/// <param name="args"></param>
		/// <param name="position"></param>
		/// <returns>Returns the value of the position in args as type. Returns null when posistion null</returns>
		private object GetValue(Type type, string[] args, int? position)
		{
			var codes = (TypeCode[]) Enum.GetValues(typeof(TypeCode));

			//Get the base type when type is nullable
			type = Nullable.GetUnderlyingType(type) ?? type;

			if(position == null || position >= args.Length)
				return null;

			var value = args[(int) position];

			if(string.IsNullOrWhiteSpace(value))
				return null;

			if(type == typeof(string))
			{
				return value;
			}

			foreach(var code in codes)
			{
				if (Type.GetTypeCode(type) == code && code != TypeCode.Object)
				{
					try {
						return Convert.ChangeType(value, type);
					}catch (FormatException e)
					{
						throw e;
					}
				}
			}
			return null;
		}
	}
}
