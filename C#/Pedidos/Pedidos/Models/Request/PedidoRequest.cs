using Pedidos.Domain.Entidades;
using System.Collections.Generic;

namespace Pedidos.Models.Request
{
    public class PedidoRequest
    {
        public Pedido Pedido { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
    }
}
