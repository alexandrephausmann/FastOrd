using Newtonsoft.Json;
using Pedidos.Dados.Interface;
using Pedidos.Domain.Entidades;
using Pedidos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
    }
}
