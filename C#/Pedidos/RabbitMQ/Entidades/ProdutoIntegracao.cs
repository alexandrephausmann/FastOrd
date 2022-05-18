using Pedidos.Domain.Enums;

namespace Pedidos.Domain.Entidades
{
    public class ProdutoIntegracao
    {
        public int CodProdutoFastOrder { get; set; }
        public int CodProdutoExterno { get; set; }
        public CodTipoIntegracao CodTipoIntegracao { get; set; }
    }
}
