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
    }
}
