using Confluent.Kafka;

namespace Reports.Core.Interfaces
{
	public interface IConsumerAdapter<T>
	{
		Task<ConsumeResult<string, T>> ConsumeAsync(string topic, CancellationToken cancellationToken);
	}
}
