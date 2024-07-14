using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    public static class DirectExchangeConsumer
    {
        public static void Recieve(IModel channel)
        {
            channel.ExchangeDeclare("direct-exchange", ExchangeType.Direct);
            channel.QueueDeclare(queue: "direct-exchange-queue",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");
            channel.QueueBind("direct-exchange-queue", "direct-exchange", "account.init");
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
            };
            channel.BasicConsume(queue: "direct-exchange-queue",
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}
