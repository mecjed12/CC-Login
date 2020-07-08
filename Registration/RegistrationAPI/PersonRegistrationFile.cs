using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RegistrationData;
using RegistrationLogic;
using System;
using System.Collections.Generic;

namespace RegistrationAPI
{
    public class PersonRegistrationFile
    {
        /// <summary>
        /// Use GetConfig() not Config
        /// </summary>
        public string Config { get; set; }
        //"{\"name1\":1,\"name2\":2}"
        //"{\"name1\":{\"value\":\"2\",\"label\":\"Spalte 3\"},\"name2\":{\"value\":\"3\",\"label\":\"Spalte 4\"}}"
        //"{\"name1\":\"2\",\"name2\":\"1\"}"

        public IFormFile File { get; set; }

        public PersonConfig GetConfig()
		{
			if(string.IsNullOrWhiteSpace(Config))
				return null;

			return JsonConvert.DeserializeObject<PersonConfig>(Config);
		}
	}
}
