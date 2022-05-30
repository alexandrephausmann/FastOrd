using Pedidos.Domain.EntidadesEF;
using System.Collections.Generic;

namespace Pedidos.Domain.Entidades
{
    public class PedidosItens
    {
        public PedidosItens()
        {
            ItensPedido = new List<ItemPedido>();
        }
        public Pedido Pedido { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
    }
}
