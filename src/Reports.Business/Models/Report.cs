namespace Reports.Business.Models
{
	public class Report
    {
		public Report(string filters)
		{
			Id = Guid.NewGuid();
			Filters = filters;
			CreatedAt = DateTime.Now;	
		}

		public Guid Id { get; set; }
		public string? Filters { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
