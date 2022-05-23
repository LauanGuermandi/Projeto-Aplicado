using Microsoft.EntityFrameworkCore;
using Reports.Business.Models;

namespace Reports.Infrastruture.Context
{
	public class ReportsContext : DbContext
    {
		public DbSet<Report> Reports { get; set; }

		public ReportsContext(DbContextOptions<ReportsContext> context) : base(context) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var reportModelBuilder = modelBuilder.Entity<Report>();
			reportModelBuilder.HasKey(x => x.Id);
			reportModelBuilder.ToTable("REPORTS");
			base.OnModelCreating(modelBuilder);
		}

	}
}
