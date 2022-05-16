using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.UseCase.Interfaces
{
    public interface IEnviarPedidoUseCase
    {
        void SendMessage<T>(T message);
    }
}
