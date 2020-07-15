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
		public async void AddObjectsFromFile(string className, [FromForm] ApplicationFile file)
		{
			if (file.File != null && file.GetProperties() != null)
			{
				try
				{
					using var stream = file.File.OpenReadStream();
					Program.controller.AddObjectsFromCSV(stream, file.GetProperties(), className);
				}
				catch (InvalidTypeException e)
				{
					Console.WriteLine(e.Message);
					Console.WriteLine(e.InnerException);
					Response.StatusCode = 400;
					await Response.WriteAsync($"{className} is not a valid type");
				}catch(FormatException e)
				{
					Console.WriteLine(e.Message);
					Response.StatusCode = 401;
					await Response.WriteAsync("The file or properties are formated incorrectly");
				}catch(Exception e)
				{
					Console.WriteLine(e.Message);
					Response.StatusCode = 402;
					await Response.WriteAsync($"Something went wrong {e}");
				}
			}
			else
			{
				Response.StatusCode = 415;
				await Response.WriteAsync( "File or Properties is null");
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
