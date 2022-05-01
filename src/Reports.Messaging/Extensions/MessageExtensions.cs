using System.Text;
using Confluent.Kafka;
using Reports.Core.Messaging.Interfaces;
using Reports.Core.Messaging.Topics;

namespace Reports.Messaging.Extensions
{
	public static class MessageExtensions
	{
		public static Message<string, T> MakeMessage<T>(this T message, string aggregateId = "") where T : IMessage
		{
			var messageType = message.GetType().AssemblyQualifiedName ?? string.Empty;
			var key = aggregateId ?? Guid.NewGuid().ToString();

			return new Message<string, T>
			{
				Key = key,
				Value = message,
				Headers = new Headers
				{
					{ "message-type", Encoding.UTF8.GetBytes(messageType) }
				}
			};
		}

		public static string GetTopic(this IMessage message)
			=> Attribute.GetCustomAttributes(message.GetType())
			  .OfType<MessageTopicAttribute>()
			  .Single()
			  .Topic;
	}
}
