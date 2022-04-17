namespace Reports.Core.Interfaces
{
	public interface IProducerAdapter<T>
	{
		Task ProduceAsync(T message);
	}
}
