using Reports.Core.Messaging.Interfaces;
using Reports.Core.Messaging.Topics;

namespace Reports.Core.Messaging.Messages
{
	[MessageTopic(TopicList.CONTATO)]
	public class ContatoReportMessage : IMessage
	{
		public int? TipoPessoa { get; set; }
		public int? PessoaSituacao { get; set; }
	}
}
