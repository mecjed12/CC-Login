using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace RegistrationAPI
{
    public class PersonRegistrationFile
    {
        public Dictionary<string, int> Config { get; set; }

        public IFormFile File { get; set; }

    }
}
