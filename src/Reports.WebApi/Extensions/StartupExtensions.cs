using IStartup = Reports.WebApi.Interfaces.IStartup;

namespace Reports.WebApi.Extensions
{
	public static class StartupExtensions
	{
		public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder) where TStartup : IStartup
		{
			var startup = webAppBuilder.MakeStartup<TStartup>();

			startup.ConfigureServices(webAppBuilder.Services);

			var app = webAppBuilder.Build();
			startup.Configure(app);
			app.Run();

			return webAppBuilder;
		}

		private static IStartup MakeStartup<TStartup>(this WebApplicationBuilder webAppBuilder) where TStartup : IStartup
		{
			var startup = Activator.CreateInstance(typeof(TStartup), webAppBuilder.Configuration) as IStartup;
			ArgumentNullException.ThrowIfNull(startup);

			return startup;
		}
	}
}
