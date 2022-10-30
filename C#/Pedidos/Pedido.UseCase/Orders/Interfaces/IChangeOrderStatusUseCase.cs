using Pedidos.Domain.EntidadesEF;
using Pedidos.Domain.Enums;

namespace Pedidos.UseCase.Orders.Interfaces
{
    public interface IChangeOrderStatusUseCase
    {
        TbOrderStatus ChangeOrderStatus(int idOrder, IdOrderStatus idOrderStatus);
    }
}
