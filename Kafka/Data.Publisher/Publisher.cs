using Confluent.Kafka;
using System.Runtime.CompilerServices;

namespace Data.Publisher
{
    public class Publisher : IPublisher
    {
        private readonly IProducer<Null, string> producer;

        public Publisher(IProducer<Null, string> producer)
        {
            this.producer = producer;
        }

        public async Task ProduceAsync(string msg) => await producer.ProduceAsync("test-topic",
                new Message<Null, string> { Value = msg });
    }
}
