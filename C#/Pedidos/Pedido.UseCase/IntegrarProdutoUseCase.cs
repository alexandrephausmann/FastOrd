using Pedidos.Dados.Interface;
using Pedidos.Domain.Entidades;
using Pedidos.Domain.Enums;
using Pedidos.UseCase.Interfaces;
using System;
using System.Collections.Generic;

namespace Pedidos.UseCase
{
    public class IntegrarProdutoUseCase : IIntegrarProdutoUseCase
    {
        private readonly IPedidoDAO _pedidoDAO;
        public IntegrarProdutoUseCase(IPedidoDAO pedidoDAO)
        {
            _pedidoDAO = pedidoDAO;
        }

        public void RecuperarCodigoProdutoFastOrder(CodTipoIntegracao codTipoIntegracao, List<ItemPedido> itensPedido)
        {
            var relacaoCodigoExternoFastOrder = _pedidoDAO.RecuperarCodigoProdutoFastOrder(codTipoIntegracao);

            foreach (ItemPedido itemPedido in itensPedido)
            {
                if (relacaoCodigoExternoFastOrder.TryGetValue(itemPedido.CodProduto, out int resultado))
                {
                    itemPedido.CodProduto = resultado;
                }
                else
                {
                    Console.WriteLine($"O código de produto {itemPedido.CodProduto} não está mapeado no sistema.");
                }
            }
        }
    }
}
