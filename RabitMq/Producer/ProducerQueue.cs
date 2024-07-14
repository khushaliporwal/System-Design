using RabbitMQ.Client;
using System.Text;

namespace Producer
{
    public static class ProducerQueue
    {

        public static void Publish(IModel channel)
        {
            channel.QueueDeclare(queue: "Khushali",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            int cnt = 1;
            while (true)
            {
                string message = $"Hello Khushali! {cnt} Msg";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: "Khushali",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine($" [x] Sent {message}");
                Thread.Sleep(1000);
                cnt++;
            }
        }
    }
}
