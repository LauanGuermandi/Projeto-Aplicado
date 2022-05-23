using Microsoft.EntityFrameworkCore;
using Reports.Business;
using Reports.Infrastruture.Context;
using Reports.Infrastruture.Repositories;
using Reports.WebApi.Services;

namespace Reports.WebApi.Configuration
{
	public static class DependencyInjectionConfiguration
	{
		public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
		{
			services.AddScoped<IReportRepository, ReportRepository>();
			services.AddScoped<IContatoReportService, ContatoReportService>();

			return services;
		}
	}
}
