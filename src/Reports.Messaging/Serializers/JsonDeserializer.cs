using System.Text;
using System.Text.Json;
using Confluent.Kafka;

namespace Reports.Messaging.Serializers
{
	public class JsonDeserializer<T> : IDeserializer<T>
	{
		public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
		{
			var value = JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(data));
			ArgumentNullException.ThrowIfNull(value);

			return value;
		}
	}
}
