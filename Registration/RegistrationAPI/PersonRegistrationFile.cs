using Microsoft.AspNetCore.Http;

namespace RegistrationAPI
{
    public class PersonRegistrationFile
    {
        public int[] Order { get; set; }

        public IFormFile File { get; set; }

    }
}
