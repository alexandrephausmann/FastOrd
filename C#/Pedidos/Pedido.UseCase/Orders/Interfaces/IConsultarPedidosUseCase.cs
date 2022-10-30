using Pedidos.Domain.Enums;
using Pedidos.Domain.Response;

namespace Pedidos.UseCase.Orders.Interfaces
{
    public interface IConsultarPedidosUseCase
    {
        OrdersResponse ConsultarPedidos(IdOrderStatus idOrderStatus);
        OrdersResponse GetOrders();
    }
}
