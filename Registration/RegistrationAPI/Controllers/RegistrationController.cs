using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using RegistrationData;
using RegistrationData.model;

namespace RegistrationAPI.Controllers
{
    [Route("registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        [HttpGet]
        public List<string> Get()
        {
            return Program.controller.GetPersonColumnNames();
        }
        
        [HttpGet("Test")]
        public int Test()
        {
            return 0;
        }
        
        [HttpGet("{id}")]
        public Person GetWithID(int id)
        {
            return Program.controller.GetPersonById(id);
        }

        [HttpPost("Person")]
        public void AddPeopleFromFile([FromForm] PersonRegistrationFile file)
        {
            if(file.File != null)
            {
                using var stream = file.File.OpenReadStream();
                Program.controller.AddPeopleFromCSV(stream, file.GetConfig());
            }else
			{
                Response.StatusCode = 400;
			}
        }

        [HttpPost("Course")]
        public void AddCoursesFromFile([FromForm] CourseRegistrationFile file)
        {
            if(file.File != null)
            {
                using var stream = file.File.OpenReadStream();
                Program.controller.AddCoursesFromCSV(stream, file.GetConfig());
            }else
			{
                Response.StatusCode = 400;
			}
        }
    }
}
