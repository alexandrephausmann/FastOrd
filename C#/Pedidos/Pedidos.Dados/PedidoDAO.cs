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

        public int InserirPedido(TbPedido pedido)
        {
            int codPedido = 0;
            using (var db = new FastOrderContext(_configuracao))
            {
                db.TbPedido.Add(pedido);
                db.SaveChanges();
                codPedido = pedido.CodPedido;
            }
            return codPedido;
        }

        public void InserirItensPedido(List<TbItemPedido> itensPedido)
        {
            using (var db = new FastOrderContext(_configuracao))
            {
                db.TbItemPedido.AddRange(itensPedido);
                db.SaveChanges();
            }
        }

        public List<TbProdutoIntegracao> RecuperarCodigoProdutoFastOrder(CodTipoIntegracao codTipoIntegracao)
        {
            var relacaoCodigoExternoFastOrder = new List<TbProdutoIntegracao>();

            using (var db = new FastOrderContext(_configuracao))
            {
                relacaoCodigoExternoFastOrder = db.TbProdutoIntegracao.Where(prod => prod.CodTipoIntegracao == (int?)codTipoIntegracao).ToList();
            }
            return relacaoCodigoExternoFastOrder;
        }

        public PedidosRetorno ConsultarPedidos(CodStatusPedido codStatusPedido)
        {
            var pedidosRetorno = new PedidosRetorno();

            using (var db = new FastOrderContext(_configuracao))
            {
                var pedidos = (from pedido in db.TbPedido
                               join itPedido in db.TbItemPedido
                               on pedido.CodPedido equals itPedido.CodPedido
                               join stsPedido in db.TbStatusPedido
                               on pedido.CodStatusPedido equals stsPedido.CodStatusPedido
                               join produto in db.TbProduct
                               on itPedido.CodProduto equals produto.CodProduct
                               join integraProduto in db.TbTipoIntegracao
                               on pedido.CodTipoIntegracao equals integraProduto.CodTipoIntegracao
                               where stsPedido.CodStatusPedido == (int)codStatusPedido
                               select new Pedido
                               {
                                  CodPedido = pedido.CodPedido,
                                  Retirada = pedido.Retirada,
                                  CodStatusPedido = (CodStatusPedido)stsPedido.CodStatusPedido,
                                  DescStatusPedido = stsPedido.DescStatusPedido,
                                  CodTipoIntegracao = (CodTipoIntegracao)stsPedido.CodStatusPedido,
                                  DescTipoIntegracao = integraProduto.DescTipoIntegracao,
                                  Bairro = pedido.Bairro,
                                  Cep = pedido.Cep,
                                  Rua = pedido.Rua,
                                  NumResidencia = pedido.NumResidencia,
                                  DadoComplementar = pedido.DadoComplementar,
                                  NumCelular = pedido.NumCelular
                               }
                              ).ToList();

                pedidosRetorno.CodigosPedidos = pedidos.Select(p => p.CodPedido).Distinct().ToList();


                foreach(int codigoPedido in pedidosRetorno.CodigosPedidos)
                {
                    var pedidoItem = new PedidosItens();
                    var itensPedidos = (from itemPedido in db.TbItemPedido
                                       join produto in db.TbProduct
                                       on itemPedido.CodProduto equals produto.CodProduct
                                        where itemPedido.CodPedido == codigoPedido
                                       select new ItemPedido
                                       {
                                           CodItemPedido = itemPedido.CodItemPedido,
                                           CodPedido = itemPedido.CodPedido,
                                           Quantidade = (int)itemPedido.Quantidade,
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
