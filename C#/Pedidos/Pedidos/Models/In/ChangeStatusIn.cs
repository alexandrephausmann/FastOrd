using Pedidos.Domain.Enums;

namespace Pedidos.Models.In
{
    public class ChangeStatusIn
    {
        public int IdOrder { get; set; }
        public IdOrderStatus IdOrderStatus { get; set; }
    }
}
