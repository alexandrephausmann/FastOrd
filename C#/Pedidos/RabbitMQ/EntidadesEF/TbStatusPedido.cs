﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Pedidos.Domain.EntidadesEF
{
    public partial class TbStatusPedido
    {
        public TbStatusPedido()
        {
            TbPedido = new HashSet<TbPedido>();
        }

        public int CodStatusPedido { get; set; }
        public string DescStatusPedido { get; set; }

        public virtual ICollection<TbPedido> TbPedido { get; set; }
    }
}