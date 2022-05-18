using Pedidos.Domain.Entidades;
using System.Collections.Generic;

namespace RabbitMQ.Request
{
    public class PedidoIn
    {
        public Pedido Pedido { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
    }
}
