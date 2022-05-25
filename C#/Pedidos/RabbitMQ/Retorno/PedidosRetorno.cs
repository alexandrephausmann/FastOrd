using Pedidos.Domain.Entidades;
using System.Collections.Generic;

namespace Pedidos.Domain.Retorno
{
    public class PedidosRetorno
    {
        public PedidosRetorno()
        {
            PedidosItens = new List<PedidosItens>();
            CodigosPedidos = new List<int>();
        }
        public List<PedidosItens>  PedidosItens { get; set; }
        public List<int> CodigosPedidos { get; set; }
    }
}
