using Pedidos.Domain.Entidades;
using System.Collections.Generic;

namespace Pedidos.UseCase.Interfaces
{
    public interface IEnviarPedidoUseCase
    {

        void CriarPedido(Pedido pedido, List<ItemPedido> itemPedido);
        void SendMessage<T>(T message);
    }
}
