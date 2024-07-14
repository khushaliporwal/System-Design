using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Consumer
{
    internal class ConsumerQueue
    {
        public static void Recieve(IModel channel)
        {
            channel.QueueDeclare(queue: "Khushali",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
            };
            channel.BasicConsume(queue: "Khushali",
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}
