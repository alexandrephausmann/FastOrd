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

        public void RecuperarCodigoProdutoFastOrder(CodTipoIntegracao codTipoIntegracao, List<TbItemPedido> itensPedido)
        {
            var relacaoCodigoExternoFastOrder = _pedidoDAO.RecuperarCodigoProdutoFastOrder(codTipoIntegracao);

            foreach (TbItemPedido itemPedido in itensPedido)
            {
                var produto = relacaoCodigoExternoFastOrder.Find(prod => prod.CodProdutoExterno == itemPedido.CodProduto);

                if (produto != null)
                {
                    itemPedido.CodProduto = produto.CodProdutoFastorder;
                }
                else
                {
                    throw new Exception($"O código de produto {itemPedido.CodProduto} não está mapeado no sistema.");
                }
            }
        }
    }
}
