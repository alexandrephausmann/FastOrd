
using Pedidos.Domain.Entidades;
using Pedidos.Domain.Enums;
using System.Collections.Generic;

namespace Pedidos.UseCase.Interfaces
{
    public interface IIntegrarProdutoUseCase
    {
        void RecuperarCodigoProdutoFastOrder(CodTipoIntegracao codTipoIntegracao, List<ItemPedido> itensPedido);
    }
}
