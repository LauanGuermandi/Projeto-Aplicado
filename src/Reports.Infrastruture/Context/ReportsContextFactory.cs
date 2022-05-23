using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Reports.Infrastruture.Context
{
	public class ReportsContextFactory : IDesignTimeDbContextFactory<ReportsContext>
	{
		public ReportsContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder()
			   .SetBasePath(Directory.GetCurrentDirectory())
			   .AddJsonFile("appsettings.json", true, true)
			   .Build();

			var builder = new DbContextOptionsBuilder<ReportsContext>();
			builder.UseSqlServer(configuration.GetConnectionString("ReportsConnectionString"));

			return new ReportsContext(builder.Options);
		}
	}
}
