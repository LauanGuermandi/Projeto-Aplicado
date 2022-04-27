using Confluent.Kafka;

namespace Reports.Messaging.Interfaces
{
	public interface IProducerBuilder<T>
	{
		public IProducer<string, T> Build();
	}
}
