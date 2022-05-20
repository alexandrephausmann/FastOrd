using Pedidos.Domain.Enums;
using System.Text.Json.Serialization;

namespace Pedidos.Domain.Entidades
{
    public class Pedido
    {
        [JsonIgnore]
        public int CodPedido { get; set; }
        public string Retirada { get; set; }
        [JsonIgnore]
        public CodTipoIntegracao CodTipoIntegracao { get; set; }
        [JsonIgnore]
        public CodStatusPedido CodStatusPedido { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int NumResidencia { get; set; }
        public string DadoComplementar { get; set; }
        public string NumCelular { get; set; }
    }
}
