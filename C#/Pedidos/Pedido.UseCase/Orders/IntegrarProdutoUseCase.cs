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

        public void RecuperarCodigoProdutoFastOrder(CodTipoIntegracao codTipoIntegracao, List<TbOrderItem> itensPedido)
        {
            var relacaoCodigoExternoFastOrder = _pedidoDAO.RecuperarCodigoProdutoFastOrder(codTipoIntegracao);

            foreach (TbOrderItem itemPedido in itensPedido)
            {
                var produto = relacaoCodigoExternoFastOrder.Find(prod => prod.IdExternalProduct == itemPedido.CodProduct);

                if (produto != null)
                {
                    itemPedido.CodProduct = produto.IdProductFastorder;
                }
                else
                {
                    throw new Exception($"O código de produto {itemPedido.CodProduct} não está mapeado no sistema.");
                }
            }
        }
    }
}
