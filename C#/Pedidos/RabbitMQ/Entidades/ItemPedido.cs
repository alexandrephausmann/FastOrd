using System.Text.Json.Serialization;

namespace Pedidos.Domain.Entidades
{
    public class ItemPedido
    {
        [JsonIgnore]
        public int CodPedido { get; set; }
        [JsonIgnore]
        public int CodItemPedido { get; set; }
        public int CodProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
