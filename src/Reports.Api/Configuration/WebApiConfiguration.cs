namespace Reports.Api.Configuration
{
	public static class WebApiConfiguration
	{
		public static IServiceCollection AddWebApiConfiguration(this IServiceCollection services)
		{
			services.AddControllers();
			services.AddRouting(options =>
			{
				options.LowercaseUrls = true;
				options.LowercaseQueryStrings = true;
			});

			return services;
		}

		public static IApplicationBuilder UseWebApiConfiguration(this IApplicationBuilder app)
		{
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			return app;
		}
	}
}
