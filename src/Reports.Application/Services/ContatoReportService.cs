using AutoMapper;
using Reports.Application.Interfaces;
using Reports.Core.Interfaces;
using Reports.Core.Messaging.Messages;
using Reports.Core.Models;

namespace Reports.Application.Services
{
	public class ContatoReportService : IContatoReportService
	{
		private readonly IProducerAdapter<ContatoReportMessage> _producer;
		private readonly IMapper _mapper;

		public ContatoReportService(IProducerAdapter<ContatoReportMessage> producer, IMapper mapper)
		{
			_producer = producer;
			_mapper = mapper;
		}

		public async Task AddSolicitacaoRelatorioContato(ContatoFiltros filtros)
		{
			var message = _mapper.Map<ContatoReportMessage>(filtros);
			await _producer.ProduceAsync(message);
		}
	}
}
