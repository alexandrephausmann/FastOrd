using Pedidos.Domain.EntidadesEF;
using Pedidos.Domain.Enums;
using System.Collections.Generic;

namespace Pedidos.UseCase.Orders.Interfaces
{
    public interface IIntegrarProdutoUseCase
    {
        void RecuperarCodigoProdutoFastOrder(CodTipoIntegracao codTipoIntegracao, List<TbItemPedido> itensPedido);
    }
}
