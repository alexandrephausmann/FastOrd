using Pedidos.Domain.Entidades;
using Pedidos.Domain.EntidadesEF;
using System.Collections.Generic;

namespace Pedidos.Models.In
{
    public class PedidoIn
    {
        public TbOrder OrderDetails { get; set; }
        public List<TbOrderItem> ProductItens { get; set; }
    }
}
