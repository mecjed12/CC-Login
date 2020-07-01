using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationData;

namespace RegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegistrationController : ControllerBase
    {

        [HttpGet]
        public Person Get()
        {
            using var entities = new PersonEntities();
            return entities.People.First();
        }



        [HttpPost]
        public void Post(IFormFile file)
        {
            
            Debug.WriteLine(file.FileName);

        }

    }
}
