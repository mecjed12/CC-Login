using ApplicationLogic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ApplicationAPI
{
	public class CourseRegistrationFile
	{
		//TODO update this

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
