using Pedidos.Dados.Interface;
using Pedidos.Domain.EntidadesEF;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Response;
using Pedidos.UseCase.Orders.Interfaces;

namespace Pedidos.UseCase.Orders
{
    public class ChangeOrderStatusUseCase : IChangeOrderStatusUseCase
    {
        private readonly IOrderDAO _orderDAO;
        private readonly IOrderStatusDAO _orderStatusDAO;
        public ChangeOrderStatusUseCase(IOrderDAO orderDAO, IOrderStatusDAO orderStatusDAO)
        {
            _orderDAO = orderDAO;
            _orderStatusDAO = orderStatusDAO;
        }

        public TbOrderStatus ChangeOrderStatus(int idOrder, IdOrderStatus idOrderStatus)
        {
            _orderDAO.ChangeOrderStatus(idOrder, idOrderStatus);
            return _orderStatusDAO.GetOrderStatusById(idOrderStatus);
        }
    }
}
