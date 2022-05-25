﻿using Pedidos.Domain.Entidades;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Retorno;
using System.Collections.Generic;

namespace Pedidos.Dados.Interface
{
    public interface IPedidoDAO
    {
        int InserirPedido(Pedido pedido);
        void InserirItensPedido(List<ItemPedido> itensPedido);
        Dictionary<int, int> RecuperarCodigoProdutoFastOrder(CodTipoIntegracao codTipoIntegracao);
        PedidosRetorno ConsultarPedidos(CodStatusPedido codStatusPedido);
    }
}
