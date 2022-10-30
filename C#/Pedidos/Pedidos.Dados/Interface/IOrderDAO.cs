using Pedidos.Domain.Entidades;
using Pedidos.Domain.EntidadesEF;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Response;
using System.Collections.Generic;

namespace Pedidos.Dados.Interface
{
    public interface IOrderDAO
    {
        int InserirPedido(TbOrder orderDetails);
        void InserirItensPedido(List<TbOrderItem> productItens);
        List<TbIntegrationProduct> RecuperarCodigoProdutoFastOrder(CodTipoIntegracao idIntegrationType);
        OrdersResponse ConsultarPedidos(IdOrderStatus idOrderStatus);
        OrdersResponse GetOrders();
        void ChangeOrderStatus(int idOrder, IdOrderStatus idOrderStatus);
    }
}
