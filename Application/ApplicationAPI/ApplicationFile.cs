using ApplicationData;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApplicationAPI
{
	public class ApplicationFile
    {
		/// <summary>
		/// Use GetProperties() not Properties
		/// </summary>
		public string Properties { get; set; }

		public IFormFile File { get; set; }

		public List<MappableProperties> GetProperties()
		{
			if(string.IsNullOrWhiteSpace(Properties))
				return null;

			return JsonConvert.DeserializeObject<List<MappableProperties>>(Properties);
		}
	}
}
