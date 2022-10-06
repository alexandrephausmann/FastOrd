using Pedidos.Domain.Enums;
using Pedidos.Domain.Retorno;

namespace Pedidos.UseCase.Orders.Interfaces
{
    public interface IConsultarPedidosUseCase
    {
        PedidosRetorno ConsultarPedidos(CodStatusPedido codStatusPedido);
        PedidosRetorno GetOrders();
    }
}
