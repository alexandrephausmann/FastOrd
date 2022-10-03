using Pedidos.Domain.EntidadesEF;
using System.Collections.Generic;

namespace Pedidos.UseCase.Products.Interfaces
{
    public interface IGetProductsUseCase
    {
        List<TbProduct> GetProducts();
        TbProduct GetProductById(int id);
    }
}
