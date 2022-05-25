using Newtonsoft.Json;
using Pedidos.Dados.Interface;
using Pedidos.Domain.Entidades;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Retorno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Pedidos.Dados
{
    public class PedidoDAO : IPedidoDAO
    {
        SqlConnection sqlCon = null;
        String SqlconString = "Data Source=DESKTOP-3TBHR6V\\SQLEXPRESS;Initial Catalog=FastOrder;Integrated Security=false;Uid=sa;Pwd=ale123";//ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        public int InserirPedido(Pedido pedido)
        {
            var codigoProd = 0;
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("PR_I_TB_PEDIDO", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@RETIRADA", SqlDbType.NVarChar).Value = pedido.Retirada;
                sql_cmnd.Parameters.AddWithValue("@COD_TIPO_INTEGRACAO", SqlDbType.Int).Value = pedido.CodTipoIntegracao;
                sql_cmnd.Parameters.AddWithValue("@COD_STATUS_PEDIDO", SqlDbType.Int).Value = pedido.CodStatusPedido;
                sql_cmnd.Parameters.AddWithValue("@RUA", SqlDbType.NVarChar).Value = pedido.Rua;
                sql_cmnd.Parameters.AddWithValue("@BAIRRO", SqlDbType.NVarChar).Value = pedido.Bairro;
                sql_cmnd.Parameters.AddWithValue("@CEP", SqlDbType.NVarChar).Value = pedido.Cep;
                sql_cmnd.Parameters.AddWithValue("@NUM_RESIDENCIA", SqlDbType.Int).Value = pedido.NumResidencia;
                sql_cmnd.Parameters.AddWithValue("@DADO_COMPLEMENTAR", SqlDbType.NVarChar).Value = pedido.DadoComplementar;
                sql_cmnd.Parameters.AddWithValue("@NUM_CELULAR", SqlDbType.NVarChar).Value = pedido.NumCelular;
                codigoProd = int.Parse(sql_cmnd.ExecuteScalar().ToString());
                sqlCon.Close();
            }
            return codigoProd;
        }

        public void InserirItensPedido(List<ItemPedido> itensPedido)
        {

            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("PR_I_TB_ITEM_PEDIDO", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                string json = JsonConvert.SerializeObject(itensPedido);
                DataTable DtPedidos = JsonConvert.DeserializeObject<DataTable>(json);
                sql_cmnd.Parameters.AddWithValue("@Values", DtPedidos);

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }

        }

        public Dictionary<int, int> RecuperarCodigoProdutoFastOrder(CodTipoIntegracao codTipoIntegracao)
        {
            var relacaoCodigoExternoFastOrder = new Dictionary<int, int>();

            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("PR_S_TB_PRODUTO_INTEGRACAO", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@COD_TIPO_INTEGRACAO", SqlDbType.Int).Value = (int)codTipoIntegracao;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProdutoIntegracao produtoIntegracao = new ProdutoIntegracao
                        {
                            CodProdutoExterno = (int)reader["COD_PRODUTO_EXTERNO"],
                            CodProdutoFastOrder = (int)reader["COD_PRODUTO_FASTORDER"]
                        };
                        relacaoCodigoExternoFastOrder.Add(produtoIntegracao.CodProdutoExterno, produtoIntegracao.CodProdutoFastOrder);
                    }
                }                 

                sqlCon.Close();
            }
            return relacaoCodigoExternoFastOrder;
        }

        public PedidosRetorno ConsultarPedidos(CodStatusPedido codStatusPedido)
        {
            var pedidosRetorno = new PedidosRetorno();

            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("CONSULTAR_PEDIDOS", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@COD_STATUS", SqlDbType.Int).Value = (int)codStatusPedido;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    var pedidoItem = new PedidosItens();
                    var primeiroRegistro = true;

                    while (reader.Read())
                    {
                        var loop = true;
                        //Esse while serve para eu conseguir recuperar que o ultimo registro do banco foi lido
                        while (loop)
                        {                         
                            loop = reader.Read();
                            if (!loop)
                            {
                                //último registro
                                pedidosRetorno.PedidosItens.Add(pedidoItem);
                            }
                            else
                            {
                                //Não é o último registro
                                var codigoProduto = (int)reader["COD_PEDIDO"];
                                var existePedido = pedidosRetorno.CodigosPedidos.Any(codigo => codigo == codigoProduto);

                                if (!existePedido)
                                {
                                    if (!primeiroRegistro)
                                    {
                                        pedidosRetorno.PedidosItens.Add(pedidoItem);
                                        pedidoItem = new PedidosItens();
                                    }
                                    else
                                    {
                                        primeiroRegistro = false;
                                    }

                                    pedidosRetorno.CodigosPedidos.Add(codigoProduto);

                                    Pedido pedido = new Pedido
                                    {
                                        CodPedido = codigoProduto,
                                        Retirada = reader["RETIRADA"].ToString(),
                                        Rua = reader["RUA"].ToString(),
                                        Bairro = reader["BAIRRO"].ToString(),
                                        Cep = reader["CEP"].ToString(),
                                        NumResidencia = reader["NUM_RESIDENCIA"].ToString() == "" ? null : (int)reader["NUM_RESIDENCIA"],
                                        DadoComplementar = reader["DADO_COMPLEMENTAR"].ToString(),
                                        NumCelular = reader["NUM_CELULAR"].ToString()
                                    };
                                    pedidoItem.Pedido = pedido;
                                }

                                ItemPedido itemPedido = new ItemPedido
                                {
                                    CodItemPedido = reader["COD_ITEM_PEDIDO"].ToString() == "" ? 0 : (int)reader["COD_ITEM_PEDIDO"],
                                    CodProduto = reader["COD_PRODUTO"].ToString() == "" ? 0 : (int)reader["COD_PRODUTO"],
                                    DescProduto = reader["DESC_PRODUTO"].ToString(),
                                    Quantidade = reader["QUANTIDADE"].ToString() == "" ? 0 : (int)reader["QUANTIDADE"]
                                };
                                pedidoItem.ItensPedido.Add(itemPedido);
                            }
                        }                                      

                    }
                }

                sqlCon.Close();
            }

            return pedidosRetorno;
        }
    }
}
