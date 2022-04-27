using System.Text;
using System.Text.Json;
using Confluent.Kafka;
using Reports.Messaging.Interfaces;

namespace Reports.Messaging.Serializers
{
	public class JsonSerializer<T> : ISerializer<T> where T : IMessage
	{
		public byte[] Serialize(T data, SerializationContext context)
			=> Encoding.ASCII.GetBytes(JsonSerializer.Serialize<T>(data));
	}
}
