using Pedidos.Dados.Interface;
using Pedidos.UseCase.Products.Interfaces;

namespace Pedidos.UseCase.Products
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductDAO _productDAO;
        public DeleteProductUseCase(IProductDAO productDAO)
        {
            _productDAO = productDAO;
        }

        public void DeleteProduct(int id)
        {
            _productDAO.DeleteProduct(id);
        }
    }
}
