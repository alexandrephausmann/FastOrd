using Pedidos.Domain.Entidades;
using System.Collections.Generic;

namespace Pedidos.UseCase.Interfaces
{
    public interface ICriarPedidoUseCase
    {
        void CriarPedido(Pedido pedido, List<ItemPedido> itemPedido);         
    }
}
