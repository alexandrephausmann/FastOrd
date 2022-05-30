using Pedidos.Domain.Entidades;
using Pedidos.Domain.EntidadesEF;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Retorno;
using System.Collections.Generic;

namespace Pedidos.Dados.Interface
{
    public interface IPedidoDAO
    {
        int InserirPedido(TbPedido pedido);
        void InserirItensPedido(List<TbItemPedido> itensPedido);
        List<TbProdutoIntegracao> RecuperarCodigoProdutoFastOrder(CodTipoIntegracao codTipoIntegracao);
        PedidosRetorno ConsultarPedidos(CodStatusPedido codStatusPedido);
    }
}
