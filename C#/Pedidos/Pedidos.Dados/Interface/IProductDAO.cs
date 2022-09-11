using Pedidos.Domain.EntidadesEF;
using System.Collections.Generic;

namespace Pedidos.Dados.Interface
{
    public interface IProductDAO
    {
        List<TbProduct> GetProducts();
        void CreateProduct(TbProduct product);
        void UpdateProduct(TbProduct product);
        void DeleteProduct(int id);
    }
}
