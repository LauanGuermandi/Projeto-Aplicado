using Confluent.Kafka;

namespace Reports.Kafka.Adapter.Interfaces
{
	public interface IProducerBuilder<T>
	{
		public IProducer<string, T> Build();
	}
}
