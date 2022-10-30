using Pedidos.Domain.Enums;

namespace Pedidos.Models.Request
{
    public class ChangeStatusRequest
    {
        public int IdOrder { get; set; }
        public IdOrderStatus IdOrderStatus { get; set; }
    }
}
