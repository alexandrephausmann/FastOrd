using Pedidos.Dados.Interface;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Retorno;
using Pedidos.UseCase.Interfaces;

namespace Pedidos.UseCase
{
    public class ConsultarPedidosUseCase : IConsultarPedidosUseCase
    {
        private readonly IPedidoDAO _pedidoDAO;
        public ConsultarPedidosUseCase(IPedidoDAO pedidoDAO)
        {
            _pedidoDAO = pedidoDAO;
        }

        public PedidosRetorno ConsultarPedidos(CodStatusPedido codStatusPedido)
        {
            return _pedidoDAO.ConsultarPedidos(codStatusPedido);
        }
    }
}
