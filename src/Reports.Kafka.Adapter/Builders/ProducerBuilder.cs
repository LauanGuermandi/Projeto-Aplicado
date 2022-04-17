using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Reports.Kafka.Adapter.Interfaces;
using Reports.Kafka.Adapter.Serializers;

namespace Reports.Kafka.Adapter.Builders
{
	public class ProducerBuilder<T> : IProducerBuilder<T> where T : IMessage
	{
		private readonly ProducerConfig _producerConfig;

		public ProducerBuilder(IOptions<ProducerConfig> producerConfig)
				=> _producerConfig = producerConfig?.Value ?? throw new ArgumentNullException(nameof(producerConfig));

		public IProducer<string, T> Build()
			=> new ProducerBuilder<string, T>(_producerConfig)
			.SetValueSerializer(new JsonSerializer<T>())
			.Build();
	}
}
