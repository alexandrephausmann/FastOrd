﻿using Microsoft.Extensions.Configuration;
using Pedidos.Dados.Interface;
using Pedidos.Domain.EntidadesEF;
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

        public List<TbProduct> GetProducts()
        {
            var products = new List<TbProduct>();

            using (var db = new FastOrderContext(_configuracao))
            {
                products = db.TbProduct.ToList();
            }
            return products;
        }

        public TbProduct GetProductById(int id)
        {
            var product = new TbProduct();

            using (var db = new FastOrderContext(_configuracao))
            {
                product = db.TbProduct.Where(prod => prod.CodProduct == id).FirstOrDefault();
            }
            return product;
        }

        public void CreateProduct(TbProduct product)
        {
            using (var db = new FastOrderContext(_configuracao))
            {
                db.TbProduct.Add(product);
                db.SaveChanges();
            }
        }

        public void UpdateProduct(TbProduct product)
        {
            using (var db = new FastOrderContext(_configuracao))
            {
                db.TbProduct.Update(product);
                db.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {          
            using (var db = new FastOrderContext(_configuracao))
            {
                var product = db.TbProduct.First(p => p.CodProduct == id);
                db.TbProduct.Remove(product);
                db.SaveChanges();
            }
        }
    }
}
