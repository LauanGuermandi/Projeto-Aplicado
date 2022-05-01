using Microsoft.AspNetCore.Mvc;
using Reports.WebApi.Controllers.Base;
using Reports.Application.Interfaces;
using Reports.Core.Models;

namespace Reports.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ReportsController : ApiController
    {
        private readonly IContatoReportService _contatoReportService;
		public ReportsController(IContatoReportService contatoReportService) 
            => _contatoReportService = contatoReportService;

		[HttpPost]
        [Route("contato")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddSolicitacaoRelatorioContato(ContatoFiltros filtros)
        {
            await _contatoReportService.AddSolicitacaoRelatorioContato(filtros);
            return ResponseAsAccept();
        }
    }
}
