using Confluent.Kafka;
using Reports.Core.Interfaces;
using Reports.Core.Messaging.Interfaces;
using Reports.Messaging.Extensions;
using Reports.Messaging.Interfaces;

namespace Reports.Messaging.Adapters
{
	public class ProducerAdapter<T> : IProducerAdapter<T>, IDisposable where T : IMessage
	{
		private readonly IProducer<string, T> _producer;

		private bool _disposed = false;

		public ProducerAdapter(IProducerBuilder<T> producerBuilder)
			=> _producer = producerBuilder.Build();

		public async Task ProduceAsync(T message)
		{
			ArgumentNullException.ThrowIfNull(message);

			var topic = message.GetTopic();
			var messageToProduce = message.MakeMessage();
			await _producer.ProduceAsync(topic, messageToProduce);
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
				_producer.Dispose();

			_disposed = true;
		}

		~ProducerAdapter()
			=>Dispose(false);

		#endregion Disposible
	}
}
