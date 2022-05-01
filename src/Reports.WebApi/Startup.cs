using Reports.WebApi.Configuration;
using Reports.Messaging.Configuration;

namespace Reports.WebApi
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
			=> services.AddMessagingConfiguration(Configuration)
					   .AddDependencyInjectionConfiguration()
					   .AddWebApiConfiguration()
			           .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
					   .AddSwagger("Reports.WebApi");

		public void Configure(WebApplication app)
			=> app.UseWebApiConfiguration()
				  .UseSwaggerWithUI();
	}
}

