using Reports.Business.Models;

namespace Reports.Business
{
	public interface IReportRepository
	{
		void AddReport(Report report);
		void SaveChanges();
	}
}
