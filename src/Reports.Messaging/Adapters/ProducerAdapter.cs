using Confluent.Kafka;
using Reports.Core.Interfaces;
using Reports.Messaging.Extensions;
using Reports.Messaging.Interfaces;

namespace Reports.Messaging.Adapters
{
	public class ProducerAdapter<T> : IProducerAdapter<T>, IDisposable where T : IMessage
	{
		private readonly Lazy<IProducer<string, T>> _producer;

		private bool _disposed = false;

		public ProducerAdapter(IProducerBuilder<T> producerBuilder)
			=> _producer = new Lazy<IProducer<string, T>>(() => producerBuilder.Build());

		public async Task ProduceAsync(T message)
		{
			var topic = message.GetTopic();
			var messageToProduce = message.MakeMessage();
			await _producer.Value.ProduceAsync(topic, messageToProduce);
		}

		#region Disposible

		public void Dispose()
		{
			GC.SuppressFinalize(this);
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && !_disposed && _producer.IsValueCreated)
				_producer.Value.Dispose();

			_disposed = true;
		}

		~ProducerAdapter()
			=>Dispose(false);

		#endregion Disposible
	}
}
