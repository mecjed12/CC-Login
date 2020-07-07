using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RegistrationData;
using RegistrationData.repo;
using RegistrationLogic;

namespace RegistrationAPI
{
    public class Program
    {
        private static DcvEntities Entities = new DcvEntities();
        public static RegistrationLogicController controller = new RegistrationLogicController(Entities);
        public static PersonRepository PersonRepo = new PersonRepository(Entities);
        public static CourseRepository CourseRepo = new CourseRepository();

        public static void Main(string[] args)
        {
            PersonRepo.InitRepository();
            CourseRepo.InitRepository();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
