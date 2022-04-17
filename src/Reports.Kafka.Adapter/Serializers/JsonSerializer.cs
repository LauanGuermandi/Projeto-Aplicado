using System.Text;
using System.Text.Json;
using Confluent.Kafka;
using Reports.Kafka.Adapter.Interfaces;

namespace Reports.Kafka.Adapter.Serializers
{
	public class JsonSerializer<T> : ISerializer<T> where T : IMessage
	{
		public byte[] Serialize(T data, SerializationContext context)
			=> Encoding.ASCII.GetBytes(JsonSerializer.Serialize<T>(data));
	}
}
