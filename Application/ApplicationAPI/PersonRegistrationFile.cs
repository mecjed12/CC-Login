using ApplicationData;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ApplicationLogic;
using System;
using System.Collections.Generic;

namespace ApplicationAPI
{
	public class PersonRegistrationFile
    {
		//public string Config { get; set; }
		//"{\"name1\":1,\"name2\":2}"
		//"{\"name1\":{\"value\":\"2\",\"label\":\"Spalte 3\"},\"name2\":{\"value\":\"3\",\"label\":\"Spalte 4\"}}"
		//"{\"name1\":\"2\",\"name2\":\"1\"}"

		//public string Base64String { get; set; }

		/// <summary>
		/// Use GetProperties() not Properties
		/// </summary>
		public string Properties { get; set; }

		public IFormFile File { get; set; }

		//Convert to base64
		//77u/SMO2cmJldDtHb3R0ZTswMy4wNS4xOTk4O23DpG5ubGljaGU7VGVzdFN0cmHDn2UgMTtUZXN0T3J0Ozk5OTk7VGVzdExhbmQNCkfDpG5pO1RydHo7MDUuMDYuMjAwMTttw6RubmxpY2hlO1Rlc3RTdHJhw59lIDI7VGVzdE9ydDs5OTk5O1Rlc3RMYW5kDQpLYXJzdGluO0hpbGU7MjAuMDIuMTk5NDt3ZWlibGljaDtUZXN0U3RyYcOfZSAzO1Rlc3RPcnQ7OTk5OTtUZXN0TGFuZA0K

		//public PersonConfig GetConfig()
		//{
		//	if(string.IsNullOrWhiteSpace(Config))
		//		return null;

		//	return JsonConvert.DeserializeObject<PersonConfig>(Config);
		//}

		public List<MappableProperties> GetProperties()
		{
			if(string.IsNullOrWhiteSpace(Properties))
				return null;

			return JsonConvert.DeserializeObject<List<MappableProperties>>(Properties);
		}
	}
}
