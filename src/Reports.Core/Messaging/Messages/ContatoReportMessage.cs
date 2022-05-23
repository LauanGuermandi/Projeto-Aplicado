using Reports.Core.Enums;
using Reports.Core.Messaging.Interfaces;
using Reports.Core.Messaging.Topics;

namespace Reports.Core.Messaging.Messages
{
	[MessageTopic(TopicList.CONTATO)]
	public class ContatoReportMessage : IMessage
	{
		public Guid ReportId { get; set; }
		public PessoaSituacao? PessoaSituacao { get; set; }
	}
}
