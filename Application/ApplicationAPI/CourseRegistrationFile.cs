using ApplicationLogic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationAPI
{
	public class CourseRegistrationFile
	{
		/// <summary>
		/// Use GetConfig() not Config
		/// </summary>
		public string Config { get; set; }

		public IFormFile File { get; set; }

		public CourseConfig GetConfig()
		{
			if(string.IsNullOrWhiteSpace(Config))
				return null;

			return JsonConvert.DeserializeObject<CourseConfig>(Config);
		}

	}
}
