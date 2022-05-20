using Pedidos.Dados.Interface;
using Pedidos.Domain.Entidades;
using System;
using System.Collections.Generic;
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

        public void InserirItensPedido(ItemPedido itemPedido)
        {

            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("PR_I_TB_ITEM_PEDIDO", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@COD_PEDIDO", SqlDbType.Int).Value = itemPedido.CodPedido;
                sql_cmnd.Parameters.AddWithValue("@COD_ITEM_PEDIDO", SqlDbType.Int).Value = itemPedido.CodItemPedido;
                sql_cmnd.Parameters.AddWithValue("@COD_PRODUTO", SqlDbType.Int).Value = itemPedido.CodProduto;
                sql_cmnd.Parameters.AddWithValue("@QUANTIDADE", SqlDbType.Int).Value = itemPedido.Quantidade;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }

        }
    }
}
