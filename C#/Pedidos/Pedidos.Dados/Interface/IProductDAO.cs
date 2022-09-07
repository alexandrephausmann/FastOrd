using Pedidos.Domain.Entidades;
using Pedidos.Domain.EntidadesEF;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Retorno;
using System.Collections.Generic;

namespace Pedidos.Dados.Interface
{
    public interface IProductDAO
    {
        List<TbProduto> GetProducts();
    }
}
