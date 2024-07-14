namespace Consumer;
using RabbitMQ.Client;
class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        DirectExchangeConsumer.Recieve(channel);

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}
