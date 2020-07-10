using System.Collections.Generic;
using ApplicationData;
using Microsoft.AspNetCore.Mvc;
using ApplicationData.model;
using System;

namespace ApplicationAPI.Controllers
{
	[Route("[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        [HttpGet]
        public List<string> GetApplicationTypes()
		{
            return Program.controller.GetTypeNames();
		}

        [HttpGet("props/{className}")]
        public List<MappableProperties> GetProperties(string className)
        {
            return Program.controller.GetProperties(className);
        }

        [HttpPost("person")]
        public void AddPeopleFromFile([FromForm] PersonRegistrationFile file)
        {
            if(file.File != null && file.GetProperties() != null)
            {
				using var stream = file.File.OpenReadStream();
				Program.controller.AddPeopleFromCSV(stream, file.GetProperties());
			}
			else
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
