using System.Collections.Generic;
using Pedidos.Dados.Interface;
using Pedidos.Domain.Enums;
using System.Transactions;
using Pedidos.Domain.EntidadesEF;
using Pedidos.UseCase.Orders.Interfaces;

namespace Pedidos.UseCase.Orders
{
    public class CriarPedidoUseCase : ICriarPedidoUseCase
    {
        private readonly IPedidoDAO _pedidoDAO;
        private readonly IIntegrarProdutoUseCase _integrarProdutoUseCase;    
        public CriarPedidoUseCase(IPedidoDAO pedidoDAO, IIntegrarProdutoUseCase integrarProdutoUseCase)
        {
            _pedidoDAO = pedidoDAO;
            _integrarProdutoUseCase = integrarProdutoUseCase;
        }
        public void CriarPedido(TbOrder pedido,List<TbOrderItem> itensPedido)
        {        
            using (TransactionScope scope = new TransactionScope())
            {
                InserirPedido(pedido);
                if (pedido.IdIntegrationType == (int)CodTipoIntegracao.Ifood)
                    _integrarProdutoUseCase.RecuperarCodigoProdutoFastOrder(CodTipoIntegracao.Ifood,itensPedido);
                InserirItensPedido(itensPedido, pedido.IdOrder);
                scope.Complete();
            }            
        }
        private void InserirPedido(TbOrder pedido)
        {
            if (pedido.IdIntegrationType == null)
                pedido.IdIntegrationType = (int)CodTipoIntegracao.SemIntegracao;

            if (pedido.IdOrderStatus == null)
                pedido.IdOrderStatus = (int)CodStatusPedido.Realizado;

            pedido.IdOrder = _pedidoDAO.InserirPedido(pedido); 
        }

        private void InserirItensPedido(List<TbOrderItem> itensPedido,int codigoPedido)
        {
            for (int i = 0; i < itensPedido.Count; i++)
             {
                 itensPedido[i].IdOrderItem = i + 1;
                 itensPedido[i].IdOrder = codigoPedido;
             }
            _pedidoDAO.InserirItensPedido(itensPedido);
        }
       
    }
}
