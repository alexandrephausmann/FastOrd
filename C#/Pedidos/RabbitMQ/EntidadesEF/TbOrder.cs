﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
namespace Pedidos.Domain.EntidadesEF
{
    public partial class TbOrder
    {
        public int IdOrder { get; set; }
        public string Withdrawal { get; set; }
        public int? IdIntegrationType { get; set; }
        public int? IdOrderStatus { get; set; }
        public string Road { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public int? HouseNumber { get; set; }
        public string ComplementaryData { get; set; }
        public string MobileNumber { get; set; }

        public virtual TbIntegrationType IdIntegrationTypeNavigation { get; set; }
    }
}