namespace Reports.Api
{
	public class Startup : Interfaces.IStartup
	{
		public IWebHostEnvironment WebHostEnvironment;
		public IConfiguration Configuration { get; }

		public Startup(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
		{
			Configuration = configuration;
			WebHostEnvironment = webHostEnvironment;
		}

		public void Configure(WebApplication app)
		{

		}
		public void ConfigureServices(IServiceCollection services)
		{

		}
	}
}
