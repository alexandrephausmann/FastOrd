using Pedidos.Domain.Entidades;
using System.Collections.Generic;

namespace Pedidos.Models.In
{
    public class PedidoIn
    {
        public Pedido Pedido { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
    }
}
