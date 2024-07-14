using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer
{
    public static class DirectExchangePublisher
    {
        public static void Publish(IModel channel)
        {
            channel.ExchangeDeclare("direct-exchange",
                                 ExchangeType.Direct);
            int cnt = 1;
            while (true)
            {
                string message = $"Hello Khushali! {cnt} Msg";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "direct-exchange",
                                     routingKey: "account.init",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine($" [x] Sent {message}");
                Thread.Sleep(1000);
                cnt++;
            }
        }

    }
}
