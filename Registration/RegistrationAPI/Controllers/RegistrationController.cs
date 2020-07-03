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
                //Program.controller.AddCourse(new Course() { Title = "Test Course", Category = "test", CreatedAt = DateTime.Today , ClassroomId = 3 });
                //Program.controller.AddPerson(new Person() { Name1= "Test", Name2= "Guy", Function = "", Active = true, DeletedInactive = false, NewsletterFlag = false, CreatedAt = DateTime.Today});
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
            //Debug.WriteLine(file.Order);

            using (var reader = new StreamReader(file.File.OpenReadStream()))
            {
                var content = reader.ReadToEnd();
                Debug.WriteLine(content);
            }

        }
    }
}
