using Confluent.Kafka;
using Reports.Core.Interfaces;
using Reports.Messaging.Adapters;
using Reports.Messaging.Builders;
using Reports.Messaging.Interfaces;
using Reports.Worker;
using Reports.Worker.Data;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
		var configuration = context.Configuration;
		services.Configure<ConsumerConfig>(configuration.GetSection(nameof(ConsumerConfig)));
		services.AddSingleton<DbConnection>();
		services.AddSingleton(typeof(IConsumerBuilder<>), typeof(ConsumerBuilder<>));
		services.AddSingleton(typeof(IConsumerAdapter<>), typeof(ConsumerAdapter<>));
		services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
