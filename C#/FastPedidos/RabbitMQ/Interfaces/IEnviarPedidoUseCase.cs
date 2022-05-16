using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Interfaces
{
    public interface IEnviarPedidoUseCase
    {
        void SendMessage<T>(T message);
    }
}
