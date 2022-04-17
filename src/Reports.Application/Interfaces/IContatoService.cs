using Reports.Core.Models;

namespace Reports.Application.Interfaces
{
	public interface IContatoService
    {
        Task AddSolicitacaoRelatorioContato(ContatoFiltros filtros);
    }
}
