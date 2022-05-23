using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reports.Core.Interfaces;
using Reports.Messaging.Adapters;
using Reports.Messaging.Builders;
using Reports.Messaging.Interfaces;

namespace Reports.Messaging.Configuration
{
	public static class MessagingConfiguration
	{
		public static IServiceCollection AddMessagingConfigurationForProducer(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton(typeof(IProducerBuilder<>), typeof(ProducerBuilder<>));
			services.AddSingleton(typeof(IProducerAdapter<>), typeof(ProducerAdapter<>));
			services.Configure<ProducerConfig>(configuration.GetSection(nameof(ProducerConfig)));
			return services;
		}

		public static IServiceCollection AddMessagingConfigurationForConsumer(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton(typeof(IConsumerAdapter<>), typeof(ConsumerAdapter<>));
			//services.AddSingleton(typeof(IConsumerBuilder<>), typeof(ConsumerBuilder<>));
			services.Configure<ConsumerConfig>(configuration.GetSection(nameof(ConsumerConfig)));
			return services;
		}
	}
}
