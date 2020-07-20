using ApplicationLogic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ApplicationData;

namespace ApplicationAPI
{
	public class Program
    {
        private static DcvEntities Entities = new DcvEntities();
        public static ApplicationLogicController controller = new ApplicationLogicController(Entities);

        public static void Main(string[] args)
        {
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
