using Microsoft.AspNetCore.Mvc;
using Reports.Api.Controllers.Base;
using Reports.Application.Interfaces;
using Reports.Core.Models;

namespace Reports.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ReportsController : ApiController
    {
        private readonly IContatoService _reportsService;
		public ReportsController(IContatoService reportsService) 
            => _reportsService = reportsService;

		[HttpPost]
        [Route("contato")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddSolicitacaoRelatorioContato(ContatoFiltros filtros)
        {
            await _reportsService.AddSolicitacaoRelatorioContato(filtros);
            return ResponseAsAccept();
        }
    }
}
