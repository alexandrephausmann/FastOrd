using Pedidos.Dados.Interface;
using Pedidos.Domain.EntidadesEF;
using Pedidos.UseCase.Products.Interfaces;

namespace Pedidos.UseCase.Products
{
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductDAO _productDAO;
        public UpdateProductUseCase(IProductDAO productDAO)
        {
            _productDAO = productDAO;
        }

        public void UpdateProduct(TbProduct product)
        {
           _productDAO.UpdateProduct(product);
        }
    }
}
