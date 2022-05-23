using Microsoft.AspNetCore.Mvc;
using Reports.Business.Models;
using Reports.WebApi.Controllers.Base;
using Reports.WebApi.DTOs;
using Reports.WebApi.Services;

namespace Reports.WebApi.Controllers
{
	[ApiController]
    [Route("v1/[controller]")]
    public class ReportsController : ApiController
    {
        private readonly IContatoReportService _contatoReportService;
		public ReportsController(IContatoReportService contatoReportService) 
            => _contatoReportService = contatoReportService;

		[HttpGet]
		[Route("Contato")]
		[ProducesResponseType(StatusCodes.Status202Accepted)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> ObterArquivoRelatorio(Guid Id)
		{
			var report = _contatoReportService.ObterArquivoRelatorio(Id);
			return Ok(report);
		}

		[HttpPost]
        [Route("contato")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddSolicitacaoRelatorioContato(ContatoFiltroDTO filtros)
        {
            var report = await _contatoReportService.AddSolicitacaoRelatorioContato(filtros);
            return CreatedAtAction(nameof(ObterArquivoRelatorio), new { Id = report.Id }, report);
        }
    }
}
