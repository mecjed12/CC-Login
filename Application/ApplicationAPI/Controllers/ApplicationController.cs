using System.Collections.Generic;
using ApplicationData;
using Microsoft.AspNetCore.Mvc;
using ApplicationData.model;

namespace ApplicationAPI.Controllers
{
	[Route("[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        [HttpGet("attributes/{className}")]
        public List<MappableProperties> GetAttributes(string className)
        {
            return Program.controller.GetProperties(className);
        }

        [HttpGet("{id}")]
        public Person GetWithID(int id)
        {
            return Program.controller.GetPersonById(id);
        }

        [HttpPost("person")]
        public void AddPeopleFromFile([FromForm] PersonRegistrationFile file)
        {
            if(file.File != null && file.GetProperties() != null)
            {
                using(var stream = file.File.OpenReadStream())
                Program.controller.AddPeopleFromCSV(stream, file.GetProperties());
            }else
			{
                Response.StatusCode = 204;
			}
        }

        [HttpPost("course")]
        public void AddCoursesFromFile([FromForm] CourseRegistrationFile file)
        {
            if(file.File != null && file.Config != null)
            {
                using var stream = file.File.OpenReadStream();
                Program.controller.AddCoursesFromCSV(stream, file.GetConfig());
            }else
			{
                Response.StatusCode = 204;
			}
        }
    }
}
