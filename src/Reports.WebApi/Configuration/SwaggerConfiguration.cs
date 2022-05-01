using Microsoft.OpenApi.Models;

namespace Reports.WebApi.Configuration
{
	public static class SwaggerConfiguration
	{
		public static IServiceCollection AddSwagger(this IServiceCollection services, string apiName, string version = "v1")
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc(version, new OpenApiInfo { Title = apiName, Version = version });
			});

			return services;
		}

		public static IApplicationBuilder UseSwaggerWithUI(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI();
			return app;
		}
	}
}
