using Pedidos.Domain.EntidadesEF;
using System.Collections.Generic;

namespace Pedidos.Domain.Entidades
{
    public class OrdersItems
    {
        public OrdersItems()
        {
            OrderItems = new List<OrderItem>();
        }
        public Order Order { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
