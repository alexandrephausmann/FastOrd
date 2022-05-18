using System.Text.Json.Serialization;

namespace Pedidos.Domain.Entidades
{
    public class ItemPedido
    {
        [JsonIgnore]
        public string CodPedido { get; set; }
        [JsonIgnore]
        public string CodItemPedido { get; set; }
        public string CodProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
