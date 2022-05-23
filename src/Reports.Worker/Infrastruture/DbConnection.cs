using System.Data;
using Npgsql;

namespace Reports.Worker.Data
{
	public class DbConnection : IDisposable
	{
		private readonly NpgsqlConnection _connection;

		public DbConnection(IConfiguration config)
			=> _connection = new NpgsqlConnection(config.GetConnectionString("PROJETOAPLICADO"));

		public NpgsqlConnection GetConnection()
		{
			OpenConnection();
			return _connection;
		}

		public void OpenConnection()
		{
			if (_connection.State != ConnectionState.Open
				&& _connection.State != ConnectionState.Connecting)
			{
				_connection.Open();
			}
		}

		#region Disposible

		public void Dispose()
		{
			GC.SuppressFinalize(this);
			_connection.Dispose();
		}

		#endregion Disposible
	}
}
