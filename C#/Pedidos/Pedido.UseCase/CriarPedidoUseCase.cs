using Pedidos.UseCase.Interfaces;
using Pedidos.Domain.Entidades;
using System.Collections.Generic;
using Pedidos.Dados.Interface;
using Pedidos.Domain.Enums;
using System.Transactions;
using Pedidos.Domain.EntidadesEF;

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
        public void CriarPedido(TbPedido pedido,List<TbItemPedido> itensPedido)
        {        
            using (TransactionScope scope = new TransactionScope())
            {
                InserirPedido(pedido);
                if (pedido.CodTipoIntegracao == (int)CodTipoIntegracao.Ifood)
                    _integrarProdutoUseCase.RecuperarCodigoProdutoFastOrder(CodTipoIntegracao.Ifood,itensPedido);
                InserirItensPedido(itensPedido, pedido.CodPedido);
                scope.Complete();
            }            
        }
        private void InserirPedido(TbPedido pedido)
        {
            if (pedido.CodTipoIntegracao == null)
                pedido.CodTipoIntegracao = (int)CodTipoIntegracao.SemIntegracao;

            if (pedido.CodStatusPedido == null)
                pedido.CodStatusPedido = (int)CodStatusPedido.Realizado;

            pedido.CodPedido = _pedidoDAO.InserirPedido(pedido); 
        }

        private void InserirItensPedido(List<TbItemPedido> itensPedido,int codigoPedido)
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
