using ApplicationData;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApplicationAPI
{
	public class PersonRegistrationFile
    {
		//TODO base64 ???
		//public string Base64String { get; set; }

		/// <summary>
		/// Use GetProperties() not Properties
		/// </summary>
		public string Properties { get; set; }

		public IFormFile File { get; set; }

		//Convert to base64
		//77u/SMO2cmJldDtHb3R0ZTswMy4wNS4xOTk4O23DpG5ubGljaGU7VGVzdFN0cmHDn2UgMTtUZXN0T3J0Ozk5OTk7VGVzdExhbmQNCkfDpG5pO1RydHo7MDUuMDYuMjAwMTttw6RubmxpY2hlO1Rlc3RTdHJhw59lIDI7VGVzdE9ydDs5OTk5O1Rlc3RMYW5kDQpLYXJzdGluO0hpbGU7MjAuMDIuMTk5NDt3ZWlibGljaDtUZXN0U3RyYcOfZSAzO1Rlc3RPcnQ7OTk5OTtUZXN0TGFuZA0K


		public List<MappableProperties> GetProperties()
		{
			if(string.IsNullOrWhiteSpace(Properties))
				return null;

			return JsonConvert.DeserializeObject<List<MappableProperties>>(Properties);
		}
	}
}
