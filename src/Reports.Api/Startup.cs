using Reports.Api.Configuration;

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

		public void ConfigureServices(IServiceCollection services)
			=> services.AddWebApiConfiguration()
					   .AddSwagger("Reports.Api");

		public void Configure(WebApplication app)
			=> app.UseWebApiConfiguration()
				  .UseSwaggerWithUI();
	}
}

