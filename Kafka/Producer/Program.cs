using System;
using Confluent.Kafka;
class Program
{
    static void Main(string[] args)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };
        using var producer = new ProducerBuilder<Null, string>(config).Build();

        var topic = "test-topic";
        int cnt = 1;
        while (true)
        {
            var message = new Message<Null, string> { Value = $"Hello, Kafka! {cnt++}" };
            producer.Produce(topic, message, deliveryReport =>
            {
                Console.WriteLine(deliveryReport.Message.Value);
            });
            Thread.Sleep(1000);
        }
    }
}