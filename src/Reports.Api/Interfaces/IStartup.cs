namespace Reports.Api.Interfaces
{
	public interface IStartup
	{
		IConfiguration Configuration { get; }
		void Configure(WebApplication app);
		void ConfigureServices(IServiceCollection services);
	}
}
