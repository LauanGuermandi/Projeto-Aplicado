using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Reports.Messaging.Interfaces;
using Reports.Messaging.Serializers;

namespace Reports.Messaging.Builders
{
	public class ConsumerBuilder<T> : IConsumerBuilder<T>
	{
		private readonly ConsumerConfig _consumerConfig;

		public ConsumerBuilder(IOptions<ConsumerConfig> consumerConfig)
				=> _consumerConfig = consumerConfig.Value;

		public IConsumer<string, T> Build()
			=> new ConsumerBuilder<string, T>(_consumerConfig)
				.SetValueDeserializer(new JsonDeserializer<T>())
				.Build();
	}
}
