using Microsoft.EntityFrameworkCore;
using RegistrationData;
using RegistrationData.model;
using System;
using System.Collections.Generic;
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

        public List<Person> GetPeople(Func<Person, bool> predicate)
        {
            return Entities.People.Where(predicate).ToList();
        }
        
        public List<Person> GetPeople(Func<Person, int, bool> predicate)
        {
            return Entities.People.Where(predicate).ToList();
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
            var p = GetPeople(x => x.Name1.Equals(person.Name1) && x.Name2.Equals(person.Name2)).FirstOrDefault();

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
            var c = GetCourses(x => x.Title == course.Title && x.Category == x.Category).FirstOrDefault();

            if(c != null)
            {
                return 1;
            }

            Entities.Courses.Add(course);
            Entities.SaveChanges();

            return 0;
        }


    }
}
