using AutoMapper;
using Reports.Core.Messaging.Messages;
using Reports.Core.Models;

namespace Reports.Application.Mapper
{
	public class ContatoMapperConfig : Profile
	{
		public ContatoMapperConfig()
			=> CreateMap<ContatoFiltros, ContatoReportMessage>();
	}
}
