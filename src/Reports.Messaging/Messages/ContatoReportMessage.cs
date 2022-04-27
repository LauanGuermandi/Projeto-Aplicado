using Reports.Messaging.Interfaces;
using Reports.Messaging.Topics;

namespace Reports.Messaging.Messages
{
	[MessageTopic(TopicList.CONTATO)]
	public class ContatoReportMessage : IMessage
	{
		public int? TipoPessoa { get; set; }
		public bool? Status { get; set; }
	}
}
