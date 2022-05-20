using Pedidos.Domain.Entidades;

namespace Pedidos.Dados.Interface
{
    public interface IPedidoDAO
    {
        int InserirPedido(Pedido pedido);
        void InserirItensPedido(ItemPedido itemPedido);
    }
}
