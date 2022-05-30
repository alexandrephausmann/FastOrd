using Pedidos.Domain.Entidades;
using Pedidos.Domain.EntidadesEF;
using System.Collections.Generic;

namespace Pedidos.Models.Request
{
    public class PedidoRequest
    {
        public TbPedido Pedido { get; set; }
        public List<TbItemPedido> ItensPedido { get; set; }
    }
}
