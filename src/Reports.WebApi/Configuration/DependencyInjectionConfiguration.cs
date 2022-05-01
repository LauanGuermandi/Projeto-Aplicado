using Reports.Application.Interfaces;
using Reports.Application.Services;

namespace Reports.WebApi.Configuration
{
	public static class DependencyInjectionConfiguration
	{
		public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
		{
			services.AddScoped<IContatoReportService, ContatoReportService>();
			return services;
		}
	}
}
