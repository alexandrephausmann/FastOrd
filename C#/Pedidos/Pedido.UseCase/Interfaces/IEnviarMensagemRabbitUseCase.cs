namespace Pedidos.UseCase.Interfaces
{
    public interface IEnviarMensagemRabbitUseCase
    {
        void EnviarMensagem<T>(T message);
    }
}
