using Pedidos.Domain.EntidadesEF;
using System.Collections.Generic;

namespace Pedidos.Dados.Interface
{
    public interface IProductDAO
    {
        List<TbProduct> GetProducts();
        TbProduct GetProductById(int id);
        void CreateProduct(TbProduct product);
        void UpdateProduct(TbProduct product);
        void DeleteProduct(int id);
    }
}
