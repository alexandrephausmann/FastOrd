using Pedidos.Dados.Interface;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Response;
using Pedidos.UseCase.Orders.Interfaces;

namespace Pedidos.UseCase.Orders
{
    public class ConsultarPedidosUseCase : IConsultarPedidosUseCase
    {
        private readonly IOrderDAO _orderDAO;
        public ConsultarPedidosUseCase(IOrderDAO orderDAO)
        {
            _orderDAO = orderDAO;
        }

        public OrdersResponse ConsultarPedidos(IdOrderStatus idOrderStatus)
        {
            return _orderDAO.ConsultarPedidos(idOrderStatus);
        }

        public OrdersResponse GetOrders()
        {
            return _orderDAO.GetOrders();
        }
    }
}
