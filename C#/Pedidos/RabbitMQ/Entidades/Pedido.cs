using Pedidos.Domain.Enums;
using System.Text.Json.Serialization;

namespace Pedidos.Domain.Entidades
{
    public class Pedido
    {
        [JsonIgnore]
        public string CodPedido { get; set; }
        public char Retirada { get; set; }
        [JsonIgnore]
        public CodTipoIntegracao CodTipoIntegracao { get; set; }
        [JsonIgnore]
        public CodStatusPedido CodStatusPedido { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string DadoComplementar { get; set; }
        public string NumCelular { get; set; }
    }
}
