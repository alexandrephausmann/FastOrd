﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Pedidos.Domain.EntidadesEF
{
    public partial class TbProduct
    {
        public TbProduct()
        {
            TbItemPedido = new HashSet<TbItemPedido>();
            TbProdutoIntegracao = new HashSet<TbProdutoIntegracao>();
        }

        public int? CodProduct { get; set; }
        public string DescProduct { get; set; }
        public double? ProductValue { get; set; }

        public virtual ICollection<TbItemPedido> TbItemPedido { get; set; }
        public virtual ICollection<TbProdutoIntegracao> TbProdutoIntegracao { get; set; }
    }
}