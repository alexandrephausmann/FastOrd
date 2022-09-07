using Pedidos.Domain.Entidades;
using Pedidos.Domain.EntidadesEF;
using System.Collections.Generic;

namespace Pedidos.UseCase.Orders.Interfaces
{
    public interface ICriarPedidoUseCase
    {
        void CriarPedido(TbPedido pedido, List<TbItemPedido> itemPedido);         
    }
}
