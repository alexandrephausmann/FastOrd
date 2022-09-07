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

        public List<TbProduto> GetProducts()
        {
            return _productDAO.GetProducts();
        }
    }
}
