using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using RegistrationData;
using RegistrationData.model;

namespace RegistrationAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class RegistrationController : ControllerBase
    {

        [HttpGet]
        public List<string> Get()
        {
            return Program.controller.GetPersonColumnNames();
        }
        
        [HttpGet("Test")]
        public int Test()
        {
            return 0;
        }
        
        [HttpGet("{id}")]
        public Person GetWithID(int id)
        {
            return Program.controller.GetPersonById(id);
        }

        [HttpPost("person")]
        public void Post([FromForm] PersonRegistrationFile file)
        {
            Debug.WriteLine(file.GetConfig());

            using (var stream = file.File.OpenReadStream())
            {
                Program.controller.AddPeopleFromCSV(stream, file.GetConfig());
            }
        }
    }
}
