using Pedidos.Domain.Entidades;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Retorno;
using System.Collections.Generic;

namespace Pedidos.UseCase.Interfaces
{
    public interface IEnviarPedidoUseCase
    {

        void CriarPedido(Pedido pedido, List<ItemPedido> itemPedido);    
        void SendMessage<T>(T message);
    }
}
