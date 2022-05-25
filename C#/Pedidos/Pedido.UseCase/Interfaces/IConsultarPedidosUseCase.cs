using Pedidos.Domain.Enums;
using Pedidos.Domain.Retorno;

namespace Pedidos.UseCase.Interfaces
{
    public interface IConsultarPedidosUseCase
    {
        PedidosRetorno ConsultarPedidos(CodStatusPedido codStatusPedido);
    }
}
