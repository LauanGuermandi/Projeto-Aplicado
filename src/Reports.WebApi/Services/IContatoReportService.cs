using Microsoft.AspNetCore.Mvc;
using Reports.Business.Models;
using Reports.WebApi.DTOs;

namespace Reports.WebApi.Services
{
	public interface IContatoReportService
	{
		Task<Report> AddSolicitacaoRelatorioContato(ContatoFiltroDTO filtro);
		FileContentResult ObterArquivoRelatorio(Guid Id);
	}
}
