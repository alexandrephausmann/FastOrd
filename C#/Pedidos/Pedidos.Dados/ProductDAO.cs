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
    public class ProductDAO : IProductDAO
    {
        public IConfiguration _configuracao { get; }
        public ProductDAO(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public List<TbProduto> GetProducts()
        {
            var products = new List<TbProduto>();

            using (var db = new FastOrderContext(_configuracao))
            {
                products = db.TbProduto.ToList();
            }
            return products;
        }
    }
}
