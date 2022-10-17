using Pedidos.Domain.Entidades;
using Pedidos.Domain.EntidadesEF;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Retorno;
using System.Collections.Generic;

namespace Pedidos.Dados.Interface
{
    public interface IPedidoDAO
    {
        int InserirPedido(TbOrder orderDetails);
        void InserirItensPedido(List<TbOrderItem> productItens);
        List<TbIntegrationProduct> RecuperarCodigoProdutoFastOrder(CodTipoIntegracao idIntegrationType);
        PedidosRetorno ConsultarPedidos(CodStatusPedido codStatusPedido);
        PedidosRetorno GetOrders();
    }
}
