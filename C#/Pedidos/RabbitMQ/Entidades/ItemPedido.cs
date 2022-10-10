using System.Text.Json.Serialization;


namespace Pedidos.Domain.Entidades
{
    public class ItemPedido
    {
        public int CodPedido { get; set; }
        public int CodItemPedido { get; set; }
        public int CodProduto { get; set; }
        public string DescProduto { get; set; }
        public int Quantidade { get; set; }
        public double ProductValue { get; set; }

    }
}
