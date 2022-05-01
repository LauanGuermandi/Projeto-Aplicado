using Reports.Core.Models;

namespace Reports.Application.Interfaces
{
	public interface IContatoReportService
    {
        Task AddSolicitacaoRelatorioContato(ContatoFiltros filtros);
    }
}
