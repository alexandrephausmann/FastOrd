using Microsoft.Extensions.Configuration;
using Pedidos.Dados.Interface;
using Pedidos.Domain.Entidades;
using Pedidos.Domain.EntidadesEF;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Retorno;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Pedidos.Dados
{
    public class PedidoDAO : IPedidoDAO
    {
        public IConfiguration _configuracao { get; }
        public PedidoDAO(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public int InserirPedido(TbOrder pedido)
        {
            int codPedido = 0;
            using (var db = new FastOrderContext(_configuracao))
            {
                db.TbOrder.Add(pedido);
                db.SaveChanges();
                codPedido = pedido.IdOrder;
            }
            return codPedido;
        }

        public void InserirItensPedido(List<TbOrderItem> itensPedido)
        {
            using (var db = new FastOrderContext(_configuracao))
            {
                db.TbOrderItem.AddRange(itensPedido);
                db.SaveChanges();
            }
        }

        public List<TbIntegrationProduct> RecuperarCodigoProdutoFastOrder(CodTipoIntegracao codTipoIntegracao)
        {
            var relacaoCodigoExternoFastOrder = new List<TbIntegrationProduct>();

            using (var db = new FastOrderContext(_configuracao))
            {
                relacaoCodigoExternoFastOrder = db.TbIntegrationProduct.Where(prod => prod.IdIntegrationType == (int?)codTipoIntegracao).ToList();
            }
            return relacaoCodigoExternoFastOrder;
        }

        public PedidosRetorno ConsultarPedidos(CodStatusPedido codStatusPedido)
        {
            return GetOrdersByCod((int)codStatusPedido);
        }

        public PedidosRetorno GetOrders()
        {
            return GetOrdersByCod(0);
        }

        private PedidosRetorno GetOrdersByCod(int orderStatusCode)
        {
            var pedidosRetorno = new PedidosRetorno();

            using (var db = new FastOrderContext(_configuracao))
            {
                List<Pedido> pedidos = new List<Pedido>();

                if(orderStatusCode == 0)
                {
                    pedidos = (from pedido in db.TbOrder
                                   join itPedido in db.TbOrderItem
                                   on pedido.IdOrder equals itPedido.IdOrder
                                   join stsPedido in db.TbOrderStatus
                                   on pedido.IdOrderStatus equals stsPedido.IdOrderStatus
                                   join produto in db.TbProduct
                                   on itPedido.CodProduct equals produto.CodProduct
                                   join integraProduto in db.TbIntegrationType
                                   on pedido.IdIntegrationType equals integraProduto.IdIntegrationType
                                   select new Pedido
                                   {
                                       CodPedido = pedido.IdOrder,
                                       Retirada = pedido.Withdrawal,
                                       CodStatusPedido = (CodStatusPedido)stsPedido.IdOrderStatus,
                                       DescStatusPedido = stsPedido.DescOrderStatus,
                                       CodTipoIntegracao = (CodTipoIntegracao)stsPedido.IdOrderStatus,
                                       DescTipoIntegracao = integraProduto.DescIntegrationType,
                                       Bairro = pedido.District,
                                       Cep = pedido.ZipCode,
                                       Rua = pedido.Road,
                                       NumResidencia = pedido.HouseNumber,
                                       DadoComplementar = pedido.ComplementaryData,
                                       NumCelular = pedido.MobileNumber
                                   }
                              ).ToList();
                }
                else{
                    pedidos = (from pedido in db.TbOrder
                                   join itPedido in db.TbOrderItem
                                   on pedido.IdOrder equals itPedido.IdOrder
                                   join stsPedido in db.TbOrderStatus
                                   on pedido.IdOrderStatus equals stsPedido.IdOrderStatus
                                   join produto in db.TbProduct
                                   on itPedido.CodProduct equals produto.CodProduct
                                   join integraProduto in db.TbIntegrationType
                                   on pedido.IdIntegrationType equals integraProduto.IdIntegrationType
                                   where stsPedido.IdOrderStatus == orderStatusCode
                                   select new Pedido
                                   {
                                       CodPedido = pedido.IdOrder,
                                       Retirada = pedido.Withdrawal,
                                       CodStatusPedido = (CodStatusPedido)stsPedido.IdOrderStatus,
                                       DescStatusPedido = stsPedido.DescOrderStatus,
                                       CodTipoIntegracao = (CodTipoIntegracao)stsPedido.IdOrderStatus,
                                       DescTipoIntegracao = integraProduto.DescIntegrationType,
                                       Bairro = pedido.District,
                                       Cep = pedido.ZipCode,
                                       Rua = pedido.Road,
                                       NumResidencia = pedido.HouseNumber,
                                       DadoComplementar = pedido.ComplementaryData,
                                       NumCelular = pedido.MobileNumber
                                   }
                             ).ToList();
                }
                

                pedidosRetorno.CodigosPedidos = pedidos.Select(p => p.CodPedido).Distinct().ToList();


                foreach (int codigoPedido in pedidosRetorno.CodigosPedidos)
                {
                    var pedidoItem = new PedidosItens();
                    var itensPedidos = (from itemPedido in db.TbOrderItem
                                        join produto in db.TbProduct
                                        on itemPedido.CodProduct equals produto.CodProduct
                                        where itemPedido.IdOrder == codigoPedido
                                        select new ItemPedido
                                        {
                                            CodItemPedido = itemPedido.IdOrderItem,
                                            CodPedido = itemPedido.IdOrder,
                                            Quantidade = (int)itemPedido.Quantity,
                                            CodProduto = (int)produto.CodProduct,
                                            DescProduto = produto.DescProduct
                                        }).ToList();
                    pedidoItem.ItensPedido.AddRange(itensPedidos);
                    pedidoItem.Pedido = pedidos.Find(pedido => pedido.CodPedido == codigoPedido);
                    pedidosRetorno.PedidosItens.Add(pedidoItem);
                }

            }

            return pedidosRetorno;
        }


    }
}
