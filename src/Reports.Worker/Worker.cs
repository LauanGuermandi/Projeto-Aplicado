using System.Text;
using Dapper;
using Npgsql;
using Reports.Core.Enums;
using Reports.Core.Interfaces;
using Reports.Core.Messaging.Messages;
using Reports.Worker.Data;
using Reports.Worker.Extensions;
using Reports.Worker.Models;

namespace Reports.Worker
{
	public class Worker : BackgroundService
    {
		private const string DefaultDirectory = @"C:\Relatorios";
		private readonly IConsumerAdapter<ContatoReportMessage> _consumer;
		private readonly DbConnection _db;

		public Worker(IConsumerAdapter<ContatoReportMessage> consumer, DbConnection db)
		{
			_consumer = consumer;
			_db = db;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var connection = _db.GetConnection();

			try
			{
				while (!stoppingToken.IsCancellationRequested)
				{
					var result = await _consumer.ConsumeAsync("Reports.Contato", stoppingToken);
					var message = result.Message.Value;

					var query = File.ReadAllText(Directory.GetCurrentDirectory() + "/Queries/RelatorioContato.sql");
					if (query == null)
						throw new FileLoadException("Erro ao obter conteúdo do arquivo de query.");

					var pessoaSituacao = message.PessoaSituacao ?? PessoaSituacao.Ativa;

					var pessoas = connection.Query<Contato>(query, new { PessoaSituacao = Convert.ToInt32(pessoaSituacao) });
					var csv = pessoas.ToCsv();
					CreateCsvFile(string.Concat(DefaultDirectory, $"\\RelatorioContato-{message.ReportId}.csv"), csv);
				}
			}
			catch (Exception)
			{
				connection.Dispose();
			}
		}

		private void CreateCsvFile(string fileName, string csvContent)
		{
			if (File.Exists(fileName))
				File.Delete(fileName);

			using (var fs = File.Create(fileName))
			{
				fs.Write(new UTF8Encoding(true).GetBytes(csvContent));
			}
		}
	}
}
