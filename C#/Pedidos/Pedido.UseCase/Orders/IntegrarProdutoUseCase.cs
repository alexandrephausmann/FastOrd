using Pedidos.Dados.Interface;
using Pedidos.Domain.Entidades;
using Pedidos.Domain.EntidadesEF;
using Pedidos.Domain.Enums;
using Pedidos.UseCase.Orders.Interfaces;
using System;
using System.Collections.Generic;

namespace Pedidos.UseCase.Orders
{
    public class IntegrarProdutoUseCase : IIntegrarProdutoUseCase
    {
        private readonly IPedidoDAO _pedidoDAO;
        public IntegrarProdutoUseCase(IPedidoDAO pedidoDAO)
        {
            _pedidoDAO = pedidoDAO;
        }

        public void RecuperarCodigoProdutoFastOrder(CodTipoIntegracao idIntegrationType, List<TbOrderItem> productItens)
        {
            var relacaoCodigoExternoFastOrder = _pedidoDAO.RecuperarCodigoProdutoFastOrder(idIntegrationType);

            foreach (TbOrderItem productItem in productItens)
            {
                var produto = relacaoCodigoExternoFastOrder.Find(prod => prod.IdExternalProduct == productItem.CodProduct);

                if (produto != null)
                {
                    productItem.CodProduct = produto.IdProductFastorder;
                }
                else
                {
                    throw new Exception($"O código de produto {productItem.CodProduct} não está mapeado no sistema.");
                }
            }
        }
    }
}
