namespace Pedidos.UseCase.Interfaces
{
    public interface IEnviarPedidoUseCase
    {
        void SendMessage<T>(T message);
    }
}
