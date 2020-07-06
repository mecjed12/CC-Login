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

        public IFormFile File { get; set; }

        public PersonConfig GetConfig()
        {
            if(!string.IsNullOrWhiteSpace(Config))
            {
                return JsonConvert.DeserializeObject<PersonConfig>(Config);
            }
            return null;
        }
    }
}
