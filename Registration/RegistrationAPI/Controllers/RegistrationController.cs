using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationData;
using RegistrationData.model;
using RegistrationData.repo;

namespace RegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegistrationController : ControllerBase
    {

        [HttpGet]
        public List<Person> Get()
        {
            return Program.controller.GetPeople();
        }
        
        [HttpGet("{id}")]
        public Person GetWithID(int id)
        {
            return Program.controller.GetPersonById(id);
        }

        [HttpPost("person")]
        public void Post(PersonRegistrationFile file)
        {
            
            Debug.WriteLine(file.File.FileName);
            Debug.WriteLine(file.Order);

        }
    }
}
