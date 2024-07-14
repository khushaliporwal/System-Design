using RabbitMQ.Client;
using System.Text;

namespace Producer;

class Program
{

    static void Main(string[] args)
    {

        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        DirectExchangePublisher.Publish(channel);

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();

    }
}
