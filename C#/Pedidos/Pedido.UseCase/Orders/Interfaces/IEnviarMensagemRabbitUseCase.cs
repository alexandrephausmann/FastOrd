namespace Pedidos.UseCase.Orders.Interfaces
{
    public interface IEnviarMensagemRabbitUseCase
    {
        void EnviarMensagem<T>(T message);
    }
}
