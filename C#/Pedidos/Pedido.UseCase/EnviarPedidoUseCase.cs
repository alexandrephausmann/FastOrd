using Pedidos.UseCase.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Pedidos.Domain.Entidades;
using System.Collections.Generic;
using Pedidos.Dados.Interface;
using Pedidos.Domain.Enums;

namespace Pedidos.UseCase
{
    public class EnviarPedidoUseCase : IEnviarPedidoUseCase
    {
        private readonly IPedidoDAO _pedidoDAO;
        public EnviarPedidoUseCase(IPedidoDAO pedidoDAO)
        {
            _pedidoDAO = pedidoDAO;
        }
        public int CriarPedido(Pedido pedido,List<ItemPedido> itensPedido)
        {
            var codigoPedido = InserirPedido(pedido);
            InserirItensPedido(itensPedido, codigoPedido);

            return codigoPedido;
        }

        private int InserirPedido(Pedido pedido)
        {
            if (pedido.CodTipoIntegracao == 0)
                pedido.CodTipoIntegracao = CodTipoIntegracao.SemIntegracao;

            if (pedido.CodStatusPedido == 0)
                pedido.CodStatusPedido = CodStatusPedido.Realizado;

            return _pedidoDAO.InserirPedido(pedido); 
        }

        private void InserirItensPedido(List<ItemPedido> itensPedido,int codigoPedido)
        {
            for (int i = 0; i < itensPedido.Count; i++)
            {
                itensPedido[i].CodItemPedido = i + 1;
                itensPedido[i].CodPedido = codigoPedido;
                _pedidoDAO.InserirItensPedido(itensPedido[i]);
            }
        }

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
