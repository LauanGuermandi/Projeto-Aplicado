using Microsoft.EntityFrameworkCore;
using Reports.Infrastruture.Context;
using Reports.Messaging.Configuration;
using Reports.WebApi.Configuration;

namespace Reports.WebApi
{
	public class Startup : Interfaces.IStartup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
			=> Configuration = configuration;

		public void ConfigureServices(IServiceCollection services)
			=> services.AddMessagingConfigurationForProducer(Configuration)
					   .AddDependencyInjectionConfiguration()
					   .AddWebApiConfiguration()
					   .AddDbContext<ReportsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ReportsConnectionString")))
					   .AddSwagger("Reports.WebApi");

		public void Configure(WebApplication app)
			=> app.UseWebApiConfiguration()
				  .UseSwaggerWithUI();
	}
}

