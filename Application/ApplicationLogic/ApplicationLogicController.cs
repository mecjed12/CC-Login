using ApplicationData;
using Microsoft.EntityFrameworkCore;
using ApplicationData;
using ApplicationData.enums;
using ApplicationData.model;
using ApplicationData.repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
			return PersonRepo.GetById(id);
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
			var props = new List<MappableProperties>();

			var types = GetRegistrable();
			var t = types.FirstOrDefault(x => x.Name.Equals(className, StringComparison.InvariantCultureIgnoreCase));

			if(t != null)
			{
				if(Activator.CreateInstance(t) is IApplicationClass appClass)
				{
					props = appClass.GetProperties().Select(x => CreateMappable(x, appClass)).ToList();
				}
			}

			return props;
		}

		public List<Type> GetRegistrable()
		{
			var type = typeof(IApplicationClass);
			return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => type.IsAssignableFrom(x) && x != type).ToList();
		}

		public MappableProperties CreateMappable(PropertyInfo info, IApplicationClass appClass)
		{
			return new MappableProperties()
			{
				//ClassDescription = appClass.GetType().GetCustomAttribute<DescriptionAttribute>()?.Description,
				PropName = info.Name,
				DisplayName = info.GetType().GetCustomAttribute<ApplicationProperty>()?.DisplayName
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

		public void AddPeopleFromCSV(Stream stream, List<MappableProperties> config)
		{
			var x = config;
			//Debug.WriteLine(base64File);
			//byte[] data = Convert.FromBase64String(base64File);
			//string s = Encoding.UTF8.GetString(data);

			//Encoding.GetEncoding(1250)
			//using(var reader = new StreamReader(stream))
			//{
			//    while(reader.Peek() != -1)
			//    {
			//        var created = DateTime.Now;

			//        var line = reader.ReadLine();
			//        var args = line.Split(';');

			//        var person = new Person()
			//        {
			//            Name1 = GetValue(args, config.Name1),
			//            Name2 = GetValue(args, config.Name2),
			//            Title = GetValue(args, config.Title),
			//            Gender = GetValue(args, config.Gender),
			//            SVNumber = GetValueDouble(args, config.SVNumber),
			//            Date = GetValueDate(args, config.Date),
			//            Active = true,
			//            DeletedInactive = false,
			//            NewsletterFlag = false,
			//            Function = null,
			//            CreatedAt = created
			//        };

			//        var p = Entities.People.FirstOrDefault(x => x.Name1.Equals(person.Name1) && x.Name2.Equals(person.Name2));

			//        if(p != null)
			//        {
			//            continue;
			//        }

			//        Entities.People.Add(person);
			//        Entities.SaveChanges();

			//        if(config.Email != null)
			//        {
			//            var email = GetValue(args, config.Email);
			//            if(email != null)
			//            {

			//                var contact = new Contact()
			//                {
			//                    ArtOfCommunication = EKindOfCommunication.Email,
			//                    ContactValue = email,
			//                    ContactType = EContactType.Privat,
			//                    PersonId = person.Id,
			//                    CreatedAt = created
			//                };

			//                Entities.Add(contact);
			//            }
			//        }

			//        if(config.PhoneNumber != null)
			//        {
			//            var number = GetValue(args, config.PhoneNumber);
			//            if(number != null)
			//            {
			//                var contact = new Contact()
			//                {
			//                    ArtOfCommunication = EKindOfCommunication.Telefon,
			//                    ContactValue = number,
			//                    ContactType = EContactType.Privat,
			//                    PersonId = person.Id,
			//                    CreatedAt = created
			//                };

			//                Entities.Add(contact);
			//            }
			//        }

			//        if(config.Country != null || config.Place != null || config.Street != null || config.ZipCode != null)
			//        {
			//            var country = GetValue(args, config.Country);
			//            var place = GetValue(args, config.Place);
			//            var street = GetValue(args, config.Street);
			//            var zipCode = GetValueInt(args, config.ZipCode);

			//            if(country != null || place != null || street != null || zipCode != null)
			//            {
			//                var address = new Address()
			//                {
			//                    Country = country,
			//                    Street = street,
			//                    Place = place,
			//                    ZipCode = zipCode,
			//                    CreatedAt = created
			//                };

			//                Entities.Add(address);
			//                Entities.SaveChanges();

			//                var pAddress = new RelPersonAddress()
			//                {
			//                    AddressId = address.Id,
			//                    PersonId = person.Id
			//                };
			//                Entities.Add(pAddress);
			//            }
			//        }
			//    }
			//    Entities.SaveChanges();
			//}
		}

		//https://localhost:44375/registration/person
		public void AddCoursesFromCSV(Stream fileStream, CourseConfig config)
		{
			using(var reader = new StreamReader(fileStream, Encoding.UTF8, true))
			{
				while(reader.Peek() != -1)
				{
					var line = reader.ReadLine();
					Debug.WriteLine(line);
					var args = line.Split(';');

					var course = new Course()
					{
						Title = GetValue(args, config.Title),
						Category = GetValue(args, config.Category),
						Description = GetValue(args, config.Description),
						Start = GetValueDate(args, config.Start),
						End = GetValueDate(args, config.End),
						MinParticipants = GetValueInt(args, config.ParticipantsMin),
						MaxParticipants = GetValueInt(args, config.ParticipantsMax),

						CreatedAt = DateTime.Now
					};

					var c = Entities.Courses.FirstOrDefault(x => x.Title.Equals(course.Title) && x.Category.Equals(course.Category));

					if(c != null)
						continue;

					Entities.Courses.Add(course);
				}
			}
			Entities.SaveChanges();
		}

		private string GetValue(string[] args, int? position)
		{
			if(position == null)
				return null;

			string x = args[(int) position];

			if(string.IsNullOrWhiteSpace(x))
				return null;

			return x;
		}

		private int? GetValueInt(string[] args, int? position)
		{
			var x = GetValue(args, position);

			if(x == null)
				return null;

			return int.Parse(x);
		}

		private double? GetValueDouble(string[] args, int? position)
		{
			var x = GetValue(args, position);

			if(x == null)
				return null;

			return double.Parse(x);
		}

		private bool GetValueBool(string[] args, int? position)
		{
			var x = GetValue(args, position);

			if(x == null)
				return false;

			return bool.Parse(x);
		}

		private DateTime? GetValueDate(string[] args, int? position)
		{
			var x = GetValue(args, position);

			if(x == null)
				return null;

			var date = DateTime.Parse(x);

			return date;
		}
	}
}
