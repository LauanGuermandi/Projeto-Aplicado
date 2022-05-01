using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Reports.Core.Messaging.Interfaces;
using Reports.Messaging.Interfaces;
using Reports.Messaging.Serializers;

namespace Reports.Messaging.Builders
{
	public class ProducerBuilder<T> : IProducerBuilder<T> where T : IMessage
	{
		private readonly ProducerConfig _producerConfig;

		public ProducerBuilder(IOptions<ProducerConfig> producerConfig)
				=> _producerConfig = producerConfig.Value;

		public IProducer<string, T> Build()
			=> new ProducerBuilder<string, T>(_producerConfig)
				.SetValueSerializer(new JsonSerializer<T>())
				.Build();
	}
}
