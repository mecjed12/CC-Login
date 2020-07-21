using ApplicationData;
using ApplicationLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApplicationAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ApplicationController : ControllerBase
	{
		[HttpGet]
		public List<ApplicationType> GetApplicationTypes()
		{
			return Program.controller.GetApplicationTypes();
		}

		[HttpGet("{className}/properties")]
		public List<MappableProperties> GetProperties(string className)
		{
			return Program.controller.GetProperties(className);
		}

		[HttpPost("{className}")] // Item1 = Lines, Item2 = AddedCount, Item3 = Errors
		public (int, int, Dictionary<int, Exception>) AddObjectsFromFile(string className, [FromForm] ApplicationFile file)
		{
			if (file.File != null && file.GetProperties() != null)
			{
				try
				{
					using var stream = file.File.OpenReadStream();
					var output = Program.controller.AddObjectsFromStream(stream, file.GetProperties(), className);
					if (output.Lines == 0)
					{
						Response.StatusCode = 400;
						return output;
					}
					if (output.AddedCount == 0)
					{
						Response.StatusCode = 400;
						return output;
					}

					Response.StatusCode = 201;
					return output;
				}
				catch (Exception e)
				{
					Response.StatusCode = 400;
					Response.WriteAsync(e.Message);
					return (0, 0, null);
				}
			}
			else
			{
				Response.StatusCode = 400;
				Response.WriteAsync("File or Properties is null");
				return (0, 0, null);
			}
		}
	}
}
