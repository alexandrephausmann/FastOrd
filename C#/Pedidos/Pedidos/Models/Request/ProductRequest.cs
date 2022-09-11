using Pedidos.Domain.EntidadesEF;

namespace Pedidos.Models.Request
{
    public class ProductRequest
    {
        public int? CodProduct { get; set; }
        public string DescProduct { get; set; }
        public double? ProductValue { get; set; }
    }
}
