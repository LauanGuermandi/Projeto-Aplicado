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
		public static IServiceCollection AddMessagingConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped(typeof(IProducerBuilder<>), typeof(ProducerBuilder<>));
			services.AddScoped(typeof(IProducerAdapter<>), typeof(ProducerAdapter<>));
			services.Configure<ProducerConfig>(configuration.GetSection(nameof(ProducerConfig)));
			return services;
		}
	}
}
