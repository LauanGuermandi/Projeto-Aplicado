using Confluent.Kafka;
using Reports.Core.Interfaces;
using Reports.Core.Messaging.Interfaces;
using Reports.Messaging.Interfaces;

namespace Reports.Messaging.Adapters
{
	public class ConsumerAdapter<T> : IConsumerAdapter<T> where T : IMessage
	{
		private readonly IConsumer<string, T> _consumer;

		private bool _disposed = false;

		public ConsumerAdapter(IConsumerBuilder<T> consumerBuilder)
			=> _consumer = consumerBuilder.Build();

		public async Task<ConsumeResult<string, T>> ConsumeAsync(string topic, CancellationToken cancellationToken)
		{
			_consumer.Subscribe(topic);
			return _consumer.Consume(cancellationToken);
		}

		#region Disposible

		public void Dispose()
		{
			GC.SuppressFinalize(this);
			Dispose(true);
		}

		protected void Dispose(bool disposing)
		{
			if (disposing && !_disposed)
				_consumer.Dispose();

			_disposed = true;
		}

		~ConsumerAdapter()
			=> Dispose(false);

		#endregion Disposible
	}
}
