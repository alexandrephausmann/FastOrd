using Pedidos.Domain.Entidades;
using System.Collections.Generic;

namespace Pedidos.Domain.Response
{
    public class OrdersResponse
    {
        public OrdersResponse()
        {
            OrdersItems = new List<OrdersItems>();
            IdsOrder = new List<int>();
        }
        public List<OrdersItems> OrdersItems { get; set; }
        public List<int> IdsOrder { get; set; }
    }
}
