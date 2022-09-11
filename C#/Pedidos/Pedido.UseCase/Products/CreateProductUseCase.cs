using Pedidos.Dados.Interface;
using Pedidos.Domain.EntidadesEF;
using Pedidos.UseCase.Products.Interfaces;

namespace Pedidos.UseCase.Products
{
    public class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly IProductDAO _productDAO;
        public CreateProductUseCase(IProductDAO productDAO)
        {
            _productDAO = productDAO;
        }
        public void CreateProduct(TbProduct product)
        {
            _productDAO.CreateProduct(product);
        }
    }
}
