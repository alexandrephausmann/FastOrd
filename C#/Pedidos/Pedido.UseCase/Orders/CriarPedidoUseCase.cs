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
        public void CriarPedido(TbOrder orderDetails, List<TbOrderItem> productItens)
        {        
            using (TransactionScope scope = new TransactionScope())
            {
                if (orderDetails == null)
                    orderDetails = new TbOrder();

                InserirPedido(orderDetails);
                if (orderDetails.IdIntegrationType == (int)CodTipoIntegracao.Ifood)
                    _integrarProdutoUseCase.RecuperarCodigoProdutoFastOrder(CodTipoIntegracao.Ifood, productItens);
                InserirItensPedido(productItens, orderDetails.IdOrder);
                scope.Complete();
            }            
        }
        private void InserirPedido(TbOrder orderDetails)
        {
            if (orderDetails.IdIntegrationType == null)
                orderDetails.IdIntegrationType = (int)CodTipoIntegracao.SemIntegracao;

            if (orderDetails.IdOrderStatus == null)
                orderDetails.IdOrderStatus = (int)CodStatusPedido.Realizado;

            orderDetails.IdOrder = _pedidoDAO.InserirPedido(orderDetails); 
        }

        private void InserirItensPedido(List<TbOrderItem> productItens, int idOrder)
        {
            for (int i = 0; i < productItens.Count; i++)
             {
                productItens[i].IdOrderItem = i + 1;
                productItens[i].IdOrder = idOrder;
             }
            _pedidoDAO.InserirItensPedido(productItens);
        }
       
    }
}
