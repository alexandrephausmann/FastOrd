using Pedidos.Domain.EntidadesEF;
using Pedidos.Domain.Enums;

namespace Pedidos.Dados.Interface
{
    public interface IOrderStatusDAO
    {
        TbOrderStatus GetOrderStatusById(IdOrderStatus idOrderStatus);
    }
}
