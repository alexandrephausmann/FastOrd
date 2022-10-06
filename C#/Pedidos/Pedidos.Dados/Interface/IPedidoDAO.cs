using Pedidos.Domain.Entidades;
using Pedidos.Domain.EntidadesEF;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Retorno;
using System.Collections.Generic;

namespace Pedidos.Dados.Interface
{
    public interface IPedidoDAO
    {
        int InserirPedido(TbOrder pedido);
        void InserirItensPedido(List<TbOrderItem> itensPedido);
        List<TbIntegrationProduct> RecuperarCodigoProdutoFastOrder(CodTipoIntegracao codTipoIntegracao);
        PedidosRetorno ConsultarPedidos(CodStatusPedido codStatusPedido);
        PedidosRetorno GetOrders();
    }
}
