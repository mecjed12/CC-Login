using System.Collections.Generic;
using ApplicationData;
using Microsoft.AspNetCore.Mvc;
using ApplicationData.model;
using System;
using ApplicationLogic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

namespace ApplicationAPI.Controllers
{
	[EnableCors]
	[Route("[controller]")]
	[ApiController]
	public class ApplicationController : ControllerBase
	{

		//TODO change this 
		[HttpGet]
		public List<Type> GetApplicationTypes()
		{
			return Program.controller.GetApplicationTypes();
		}

		[HttpGet("properties/{className}")]
		public List<MappableProperties> GetProperties(string className)
		{
			return Program.controller.GetProperties(className);
		}

		[HttpPost("{className}")]
		public void AddObjectsFromFile(string className, [FromForm] ApplicationFile file)
		{
			if (file.File != null && file.GetProperties() != null)
			{
				try
				{
					using var stream = file.File.OpenReadStream();
					Program.controller.AddObjectsFromCSV(stream, file.GetProperties(), className);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					Response.StatusCode = 400;
					Response.WriteAsync(e.Message);
				}
			}
			else
			{
				Response.StatusCode = 415;
				Response.WriteAsync("File or Properties is null");
			}
		}

		//     [HttpPost("person")]
		//     public void AddPeopleFromFile([FromForm] PersonRegistrationFile file)
		//     {
		//         if(file.File != null && file.GetProperties() != null)
		//         {
		//	using var stream = file.File.OpenReadStream();
		//	Program.controller.AddPeopleFromCSV(stream, file.GetProperties());
		//}
		//else
		//{
		//             Response.StatusCode = 204;
		//}
		//     }

		//     [HttpPost("course")]
		//     public void AddCoursesFromFile([FromForm] CourseRegistrationFile file)
		//     {
		//         if(file.File != null && file.Config != null)
		//         {
		//             using var stream = file.File.OpenReadStream();
		//             Program.controller.AddCoursesFromCSV(stream, file.GetConfig());
		//         }else
		//{
		//             Response.StatusCode = 204;
		//}
		//     }
	}
}
