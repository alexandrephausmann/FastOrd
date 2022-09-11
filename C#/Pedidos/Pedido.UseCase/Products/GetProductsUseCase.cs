using Pedidos.Dados.Interface;
using Pedidos.Domain.EntidadesEF;
using Pedidos.UseCase.Products.Interfaces;
using System.Collections.Generic;

namespace Pedidos.UseCase.Products
{
    public class GetProductsUseCase : IGetProductsUseCase
    {
        private readonly IProductDAO _productDAO;
        public GetProductsUseCase(IProductDAO productDAO)
        {
            _productDAO = productDAO;
        }

        public List<TbProduct> GetProducts()
        {
            return _productDAO.GetProducts();
        }

        public void CreateProduct(TbProduct product)
        {
            _productDAO.CreateProduct(product);
        }

        public void UpdateProduct(TbProduct product)
        {
           _productDAO.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productDAO.DeleteProduct(id);
        }
    }
}
