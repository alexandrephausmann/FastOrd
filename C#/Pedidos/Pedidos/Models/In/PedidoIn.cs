using Pedidos.Domain.Entidades;
using Pedidos.Domain.EntidadesEF;
using System.Collections.Generic;

namespace Pedidos.Models.In
{
    public class PedidoIn
    {
        public TbPedido Pedido { get; set; }
        public List<TbItemPedido> ItensPedido { get; set; }
    }
}
