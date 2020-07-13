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

		public PersonRepository PersonRepo;
		public CourseRepository CourseRepo;

		public ApplicationLogicController(DcvEntities entities)
		{
			Entities = entities;
			PersonRepo = new PersonRepository(entities);
			CourseRepo = new CourseRepository(entities);
		}

		public List<Person> GetPeople()
		{
			return PersonRepo.GetAll();
		}

		public Person GetPersonById(int id)
		{
			return null;
		}

		public List<Course> GetCourses()
		{
			return CourseRepo.GetAll();
		}

		public Course GetCourseById(int id)
		{
			return CourseRepo.GetAll().FirstOrDefault(x => x.Id == id);
		}

		public List<MappableProperties> GetProperties(string className)
		{
			var type = GetApplicationTypes().FirstOrDefault(x => x.Name.Equals(className, StringComparison.InvariantCultureIgnoreCase));

			return GetProperties(type);
		}

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

		public List<Type> GetApplicationTypes()
		{
			var type = typeof(IApplicationClass);
			return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => type.IsAssignableFrom(x) && x != type).ToList();
		}

		public MappableProperties CreateMappable(PropertyInfo info)
		{
			return new MappableProperties()
			{
				PropName = info.Name,
				DisplayName = info.GetCustomAttribute<ApplicationPropertyAttribute>()?.DisplayName == null ? info.Name : info.GetCustomAttribute<ApplicationPropertyAttribute>().DisplayName
			};
		}


		/// <summary>
		/// Adds a person to the database if the person isn't on the database
		/// </summary>
		/// <param name="person"></param>
		/// <returns>returns id of added person.</returns>
		public int AddPerson(Person person)
		{
			//TODO Wait for more than one non nullable value that i can use
			//var p = Entities.People.FirstOrDefault(x => x.Name1.Equals(person.Name1) && x.Name2.Equals(person.Name2));

			//if(p != null)
			//{
			//    return p.Id;
			//}

			Entities.People.Add(person);
			Entities.SaveChanges();

			return person.Id;
		}


		/// <summary>
		/// Adds a course to the database if the course isn't on the database
		/// </summary>
		/// <param name="course"></param>
		/// <returns>0 when course was added. 1 when course is already in the database</returns>
		public int AddCourse(Course course)
		{
			var c = Entities.Courses.FirstOrDefault(x => x.Title == course.Title && x.Category == x.Category);

			if(c != null)
			{
				return 1;
			}

			Entities.Courses.Add(course);
			Entities.SaveChanges();

			return 0;
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

					if(Activator.CreateInstance(type) is IApplicationClass appClass)
					{
						var subClasses = appClass.GetSubclasses();

						foreach(var prop in properties)
						{
							var p = type.GetProperty(prop.PropName);
							if(p == null)
								continue;
							p.SetValue(appClass, GetValue(p.PropertyType, args, prop.ColumnValue));
						}

						Entities.Add(appClass);
						Entities.SaveChanges();

						//TODO make this look better
						foreach(var sub in subClasses)
						{
							var subType = sub.GetType();
							if(Activator.CreateInstance(subType) is IApplicationSubclass subClass)
							{
								bool changed = false;
								foreach(var prop in properties)
								{
									var p = subType.GetProperty(prop.PropName);
									if(p == null)
										continue;
									p.SetValue(subClass, GetValue(p.PropertyType, args, prop.ColumnValue));
									changed = true;
								}

								if(changed)
								{
									var keys = subType.GetProperties().Where(x => x.IsDefined(typeof(RelationAttribute))).ToList();
									foreach(var key in keys)
									{
										if(key.GetCustomAttribute<RelationAttribute>()?.Relation == appClass.GetType())
										{
											key.SetValue(subClass, type.GetProperty("Id").GetValue(appClass));
										}

										Entities.Add(subClass);
										Entities.SaveChanges();

										if(typeof(IList).IsAssignableFrom(key.PropertyType))
										{
											if(Activator.CreateInstance(key.PropertyType.GenericTypeArguments[0]) is object subSubClass)
											{
												var subKeys = subSubClass.GetType().GetProperties().Where(x => x.IsDefined(typeof(RelationAttribute))).ToList();

												foreach(var subKey in subKeys)
												{
													//TODO make this better and better to look at
													if(subKey.GetCustomAttribute<RelationAttribute>()?.Relation == appClass.GetType())
													{
														subKey.SetValue(subSubClass, type.GetProperty("Id").GetValue(appClass));
													}
													else if(subKey.GetCustomAttribute<RelationAttribute>()?.Relation == subClass.GetType())
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
		/// <returns>Value as right type</returns>
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
				if(Type.GetTypeCode(type) == code && code != TypeCode.Object)
				{
					return Convert.ChangeType(value, type);
				}
			}
			return null;
		}
	}
}
