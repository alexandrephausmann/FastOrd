﻿using Pedidos.Domain.Entidades;
using Pedidos.Domain.EntidadesEF;
using System.Collections.Generic;

namespace Pedidos.Models.Request
{
    public class PedidoRequest
    {
        public TbOrder Pedido { get; set; }
        public List<TbOrderItem> ItensPedido { get; set; }
    }
}
