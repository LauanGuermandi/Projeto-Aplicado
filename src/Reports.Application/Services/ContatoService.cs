using Reports.Application.Interfaces;
using Reports.Core.Interfaces;
using Reports.Core.Models;

namespace Reports.Application.Services
{
	public class ContatoService : IContatoService
	{
		private readonly IProducerAdapter<> _producerAdapter;

		public Task AddSolicitacaoRelatorioContato(ContatoFiltros filtros)
		{
			
		}
	}
}
