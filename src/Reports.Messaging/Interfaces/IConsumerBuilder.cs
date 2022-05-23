using Confluent.Kafka;

namespace Reports.Messaging.Interfaces
{
	public interface IConsumerBuilder<T>
	{
		IConsumer<string, T> Build();
	}
}
