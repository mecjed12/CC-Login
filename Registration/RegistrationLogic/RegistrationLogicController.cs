using Microsoft.EntityFrameworkCore;
using RegistrationData;
using RegistrationData.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public List<Course> GetCourses(Func<Course, bool> predicate)
        {
            return Entities.Courses.Where(predicate).ToList();
        }

        public List<Course> GetCourses(Func<Course, int, bool> predicate)
        {
            return Entities.Courses.Where(predicate).ToList();
        }

        public Course GetCourseById(int id)
        {
            return Entities.Courses.FirstOrDefault(x => x.Id == id);
        }

        public List<string> GetPersonColumnNames()
        {
            var columns = new List<string>();

            var p = Entities.Model.FindEntityType("RegistrationData.Person");

            foreach (var item in p.GetProperties())
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

            if (p != null)
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
            var c = GetCourses(x => x.Title == course.Title && x.Category == x.Category).FirstOrDefault();

            if (c != null)
            {
                return 1;
            }

            Entities.Courses.Add(course);
            Entities.SaveChanges();

            return 0;
        }

        public void AddPeopleFromCSV(Stream fileStream, PersonConfig config)
        {
            using (var reader = new StreamReader(fileStream))
            {
                while (reader.Peek() != -1)
                {
                    var line = reader.ReadLine();
                    var pArgs = line.Split(';');

                    var Title = config.Title != null ? pArgs[(int)config.Title] : null;
                    Title = string.IsNullOrWhiteSpace(Title) ? null : Title;

                    var Gender = config.Gender != null ? pArgs[(int)config.Gender] : null;
                    Gender = string.IsNullOrWhiteSpace(Gender) ? null : Gender;



                    //Todo
                    //var tmp = pArgs[(int)config.SvNumber];
                    //var SvNumber = config.SvNumber != null ? int.Parse(tmp) : null;
                    

                    var person = new Person()
                    {
                        Name1 = pArgs[config.Name1],
                        Name2 = pArgs[config.Name2],
                        Title = Title,
                        Gender = Gender,
                        //SVNumber = SvNumber,
                        Function = "3"
                    };

                    var p = Entities.People.FirstOrDefault(x => x.Name1.Equals(person.Name1) && x.Name2.Equals(person.Name2));

                    if(p != null)
                    {
                        continue;
                    }

                    Entities.People.Add(person);

                }
            }
            Entities.SaveChanges();
        }
    }
}
