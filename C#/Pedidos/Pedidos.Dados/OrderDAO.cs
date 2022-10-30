using Microsoft.Extensions.Configuration;
using Pedidos.Dados.Interface;
using Pedidos.Domain.Entidades;
using Pedidos.Domain.EntidadesEF;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Pedidos.Dados
{
    public class OrderDAO : IOrderDAO
    {
        public IConfiguration _configuracao { get; }
        public OrderDAO(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public int InserirPedido(TbOrder orderDetails)
        {
            int idOrder = 0;
            using (var db = new FastOrderContext(_configuracao))
            {
                db.TbOrder.Add(orderDetails);
                db.SaveChanges();
                idOrder = orderDetails.IdOrder;
            }
            return idOrder;
        }

        public void InserirItensPedido(List<TbOrderItem> productItens)
        {
            using (var db = new FastOrderContext(_configuracao))
            {
                db.TbOrderItem.AddRange(productItens);
                db.SaveChanges();
            }
        }

        public List<TbIntegrationProduct> RecuperarCodigoProdutoFastOrder(CodTipoIntegracao idIntegrationType)
        {
            var relacaoCodigoExternoFastOrder = new List<TbIntegrationProduct>();

            using (var db = new FastOrderContext(_configuracao))
            {
                relacaoCodigoExternoFastOrder = db.TbIntegrationProduct.Where(prod => prod.IdIntegrationType == (int?)idIntegrationType).ToList();
            }
            return relacaoCodigoExternoFastOrder;
        }

        public OrdersResponse ConsultarPedidos(IdOrderStatus idOrderStatus)
        {
            return GetOrdersByCod((int)idOrderStatus);
        }

        public OrdersResponse GetOrders()
        {
            return GetOrdersByCod(0);
        }

        private OrdersResponse GetOrdersByCod(int orderStatusCode)
        {
            var ordersResponse = new OrdersResponse();

            using (var db = new FastOrderContext(_configuracao))
            {
                List<Order> pedidos = new List<Order>();

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
                                   select new Order
                                   {
                                       CodPedido = pedido.IdOrder,
                                       Retirada = pedido.Withdrawal,
                                       IdOrderStatus = (IdOrderStatus)stsPedido.IdOrderStatus,
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
                                   select new Order
                                   {
                                       CodPedido = pedido.IdOrder,
                                       Retirada = pedido.Withdrawal,
                                       IdOrderStatus = (IdOrderStatus)stsPedido.IdOrderStatus,
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
                

                ordersResponse.IdsOrder = pedidos.Select(p => p.CodPedido).Distinct().ToList();


                foreach (int idOrder in ordersResponse.IdsOrder)
                {
                    var ordersItem = new OrdersItems();
                    var itensPedidos = (from orderItem in db.TbOrderItem
                                        join product in db.TbProduct
                                        on orderItem.CodProduct equals product.CodProduct
                                        where orderItem.IdOrder == idOrder
                                        select new OrderItem
                                        {
                                            CodItemPedido = orderItem.IdOrderItem,
                                            CodPedido = orderItem.IdOrder,
                                            Quantidade = (int)orderItem.Quantity,
                                            CodProduto = (int)product.CodProduct,
                                            DescProduto = product.DescProduct,
                                            ProductValue = product.ProductValue
                                        }).ToList();
                    ordersItem.OrderItems.AddRange(itensPedidos);
                    var totalValue = ordersItem.OrderItems.Sum(pedidoItem => pedidoItem.Quantidade * pedidoItem.ProductValue);
                    ordersItem.Order = pedidos.Find(pedido => pedido.CodPedido == idOrder);
                    ordersItem.Order.TotalValue = Math.Round(totalValue, 2);
                    ordersResponse.OrdersItems.Add(ordersItem);
                }

            }

            return ordersResponse;
        }

        public void ChangeOrderStatus(int idOrder, IdOrderStatus idOrderStatus)
        {
            using (var db = new FastOrderContext(_configuracao))
            {
                var order = db.TbOrder.First(order => order.IdOrder == idOrder);
                order.IdOrderStatus = (int)idOrderStatus;
                db.TbOrder.Update(order);
                db.SaveChanges();
            }
        
        }


    }
}
