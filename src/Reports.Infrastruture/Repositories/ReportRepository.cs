using Reports.Business;
using Reports.Business.Models;
using Reports.Infrastruture.Context;

namespace Reports.Infrastruture.Repositories
{
	public class ReportRepository : IReportRepository
	{
		private readonly ReportsContext _context;
		public ReportRepository(ReportsContext context)
			=> _context = context;

		public void AddReport(Report report)
			=> _context.Reports.Add(report);

		public void SaveChanges()
			=> _context.SaveChanges();
	}
}
