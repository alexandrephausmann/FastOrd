﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Pedidos.Domain.EntidadesEF
{
    public partial class TbItemPedido
    {
        public int CodPedido { get; set; }
        public int CodItemPedido { get; set; }
        public int? CodProduto { get; set; }
        public int? Quantidade { get; set; }

        public virtual TbProduto CodProdutoNavigation { get; set; }
    }
}