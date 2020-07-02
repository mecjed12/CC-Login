using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAPI
{
    public class PersonRegistrationFile
    {
        public int[] Order { get; set; }

        public IFormFile File { get; set; }

    }
}
