using Pedidos.Domain.EntidadesEF;

namespace Pedidos.UseCase.Products.Interfaces
{
    public interface ICreateProductUseCase
    {
        void CreateProduct(TbProduct product);
    }
}
