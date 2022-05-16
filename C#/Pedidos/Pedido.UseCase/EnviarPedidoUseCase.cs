using Pedidos.UseCase.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Pedidos.UseCase
{
    public class EnviarPedidoUseCase : IEnviarPedidoUseCase
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "pedidos",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var json = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "",
                                     routingKey: "pedidos",
                                     basicProperties: null,
                                     body: body);
            }

        }
    }
}
