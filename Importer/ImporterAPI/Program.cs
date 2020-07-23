using ImporterData;
using ImporterLogic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ImporterAPI
{
	public class Program
	{
		private static readonly DcvEntities Entities = new DcvEntities();
		public static ImporterLogicController controller = new ImporterLogicController(Entities);

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
