using Pedidos.UseCase.Interfaces;
using Pedidos.Domain.Entidades;
using System.Collections.Generic;
using Pedidos.Dados.Interface;
using Pedidos.Domain.Enums;
using System.Transactions;

namespace Pedidos.UseCase
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
        public void CriarPedido(Pedido pedido,List<ItemPedido> itensPedido)
        {        
            using (TransactionScope scope = new TransactionScope())
            {
                InserirPedido(pedido);
                if (pedido.CodTipoIntegracao == CodTipoIntegracao.Ifood)
                    _integrarProdutoUseCase.RecuperarCodigoProdutoFastOrder(CodTipoIntegracao.Ifood,itensPedido);
                InserirItensPedido(itensPedido, pedido.CodPedido);
                scope.Complete();
            }            
        }
        private void InserirPedido(Pedido pedido)
        {
            if (pedido.CodTipoIntegracao == 0)
                pedido.CodTipoIntegracao = CodTipoIntegracao.SemIntegracao;

            if (pedido.CodStatusPedido == 0)
                pedido.CodStatusPedido = CodStatusPedido.Realizado;

            pedido.CodPedido = _pedidoDAO.InserirPedido(pedido); 
        }

        private void InserirItensPedido(List<ItemPedido> itensPedido,int codigoPedido)
        {
            for (int i = 0; i < itensPedido.Count; i++)
             {
                 itensPedido[i].CodItemPedido = i + 1;
                 itensPedido[i].CodPedido = codigoPedido;
             }
            _pedidoDAO.InserirItensPedido(itensPedido);
        }
       
    }
}
