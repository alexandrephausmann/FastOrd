using Pedidos.Domain.EntidadesEF;

namespace Pedidos.UseCase.Products.Interfaces
{
    public interface IUpdateProductUseCase
    {
        void UpdateProduct(TbProduct product);
    }
}
