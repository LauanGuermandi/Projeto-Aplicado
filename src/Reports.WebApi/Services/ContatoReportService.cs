using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Reports.Business;
using Reports.Business.Models;
using Reports.Core.Interfaces;
using Reports.Core.Messaging.Messages;
using Reports.WebApi.DTOs;

namespace Reports.WebApi.Services
{
	public class ContatoReportService : IContatoReportService
	{
		private const string DefaultDirectory = @"C:\Relatorios";

		private readonly IReportRepository _reportRepository;
		private readonly IProducerAdapter<ContatoReportMessage> _producer;

		public ContatoReportService(IReportRepository reportRepository, IProducerAdapter<ContatoReportMessage> producer)
		{
			_reportRepository = reportRepository;
			_producer = producer;
		}
		

		public async Task<Report> AddSolicitacaoRelatorioContato(ContatoFiltroDTO filtro)
		{
			var report = new Report(JsonSerializer.Serialize(filtro));
			_reportRepository.AddReport(report);
			_reportRepository.SaveChanges();

			var message = new ContatoReportMessage() { ReportId = report.Id, PessoaSituacao = filtro.PessoaSituacao };
			await _producer.ProduceAsync(message);
			return report;
		}

		public FileContentResult ObterArquivoRelatorio(Guid Id)
		{
			var result = new FileContentResult(File.ReadAllBytes(DefaultDirectory + $"\\RelatorioContato-{Id}.csv"), "text/csv")
			{
				FileDownloadName = "RelatorioContato.csv"
			};
			return result;
		}
	}
}
