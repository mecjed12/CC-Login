using Microsoft.EntityFrameworkCore;
using RegistrationData;
using RegistrationData.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace RegistrationLogic
{
    public class RegistrationLogicController
    {

        readonly DcvEntities Entities;

        public RegistrationLogicController(DcvEntities entities)
        {
            Entities = entities;
        }

        public List<Person> GetPeople()
        {
            return Entities.People.ToList();
        }

        public Person GetPersonById(int id)
        {
            return Entities.People.FirstOrDefault(x => x.Id == id);
        }

        public List<Course> GetCourses()
        {
            return Entities.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return Entities.Courses.FirstOrDefault(x => x.Id == id);
        }

        public List<string> GetPersonColumnNames()
        {
            var columns = new List<string>();

            var p = Entities.Model.FindEntityType("RegistrationData.Person");

            foreach(var item in p.GetProperties())
            {
                columns.Add(item.GetColumnName());
            }

            return columns;
        }


        /// <summary>
        /// Adds a person to the database if the person isn't on the database
        /// </summary>
        /// <param name="person"></param>
        /// <returns>returns id of added person.</returns>
        public int AddPerson(Person person)
        {
            //TODO ask for anouther not nullable value
            var p = Entities.People.FirstOrDefault(x => x.Name1.Equals(person.Name1) && x.Name2.Equals(person.Name2));

            if(p != null)
            {
                return p.Id;
            }

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

        public void AddPeopleFromCSV(Stream fileStream, PersonConfig config)
        {
            //Encoding.GetEncoding(1250)
            using(var reader = new StreamReader(fileStream))
            {
                while(reader.Peek() != -1)
                {
                    var line = reader.ReadLine();
                    var args = line.Split(';');

                    var person = new Person()
                    {
                        Name1 = GetValue(args, config.Name1),
                        Name2 = GetValue(args, config.Name2),
                        Title = GetValue(args, config.Title),
                        Gender = GetValue(args, config.Gender),
                        SVNumber = GetValueInt(args, config.SVNumber),
                        Date = GetValueDate(args, config.Date),
                        Active = GetValueBool(args, config.Active),
                        DeletedInactive = GetValueBool(args, config.DeletedInactive),
                        NewsletterFlag = GetValueBool(args, config.NewsletterFlag),
                        Function = "3",
                        CreatedAt = DateTime.Now
                    };

                    var p = Entities.People.FirstOrDefault(x => x.Name1.Equals(person.Name1) && x.Name2.Equals(person.Name2));

                    if(p != null)
                    {
                        continue;
                    }

                    Entities.People.Add(person);

                }
                Entities.SaveChanges();
            }
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
                        ClassroomId = 3,
                        CreatedAt = DateTime.Now
                    };

                    var c = Entities.Courses.FirstOrDefault(x => x.Title.Equals(course.Title) && x.Category.Equals(course.Category));

                    if(c != null)
                        continue;

                    Entities.Courses.Add(course);
                }
            }
            var y = Entities.SaveChanges();
            Debug.WriteLine(y);
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

        private bool GetValueBool(string[] args, int? position)
        {
            var x = GetValue(args, position);

            if(x == null)
                return false;

            return bool.Parse(x);
        }

        //TODO test this and fix it if needed
        private DateTime? GetValueDate(string[] args, int? position)
        {
            var x = GetValue(args, position);

            var date = DateTime.Parse(x);

            return date;
        }
    }
}
