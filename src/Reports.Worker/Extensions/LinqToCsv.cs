using System.Text;

namespace Reports.Worker.Extensions
{
	public static class LinqToCsv
	{
		public static string ToCsv<T>(this IEnumerable<T> items)
			where T : class
		{
			var csvBuilder = new StringBuilder();
			var properties = typeof(T).GetProperties();
			foreach (var item in items)
			{
				var line = string.Join(",", properties.Select(p => p.GetValue(item, null).ToCsvValue()).ToArray());
				csvBuilder.AppendLine(line);
			}
			return csvBuilder.ToString();
		}

		private static string ToCsvValue<T>(this T item)
			=> string.Format("{0}", item);
	}
}
