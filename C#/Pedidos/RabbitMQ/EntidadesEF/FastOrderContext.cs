﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Pedidos.Domain.EntidadesEF
{
    public partial class FastOrderContext : DbContext
    {
        public IConfiguration _configuracao { get; }
        public FastOrderContext(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public FastOrderContext(DbContextOptions<FastOrderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbOrderItem> TbOrderItem { get; set; }
        public virtual DbSet<TbOrder> TbOrder { get; set; }
        public virtual DbSet<TbProduct> TbProduct { get; set; }
        public virtual DbSet<TbIntegrationProduct> TbIntegrationProduct { get; set; }
        public virtual DbSet<TbOrderStatus> TbOrderStatus { get; set; }
        public virtual DbSet<TbIntegrationType> TbIntegrationType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {      
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(_configuracao["ConnectionStrings:FastOrderDatabase"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<TbOrderItem>(entity =>
            {
                entity.HasKey(e => new { e.IdOrder, e.IdOrderItem })
                    .HasName("PK__ORDEM_I___391D2585A3052C65");

                entity.ToTable("TB_ORDEM_ITEM");

                entity.Property(e => e.IdOrder).HasColumnName("ID_ORDER");

                entity.Property(e => e.IdOrderItem).HasColumnName("ID_ORDEM_ITEM");

                entity.Property(e => e.CodProduct).HasColumnName("COD_PRODUCT");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

            });

            modelBuilder.Entity<TbOrder>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__TB_ORDER__302BFB8001D147DB");

                entity.ToTable("TB_ORDER");

                entity.Property(e => e.IdOrder).HasColumnName("ID_ORDER");

                entity.Property(e => e.District)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ZIP_CODE");

                entity.Property(e => e.IdOrderStatus).HasColumnName("ID_ORDER_STATUS");

                entity.Property(e => e.IdIntegrationType).HasColumnName("ID_INTEGRATION_TYPE");

                entity.Property(e => e.ComplementaryData)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMPLEMENTARY_DATA");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE_NUMBER");

                entity.Property(e => e.HouseNumber).HasColumnName("HOUSE_NUMBER");

                entity.Property(e => e.Withdrawal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WITHDRAWAL");

                entity.Property(e => e.Road)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROAD");

                entity.HasOne(d => d.IdIntegrationTypeNavigation)
                    .WithMany(p => p.TbOrder)
                    .HasForeignKey(d => d.IdIntegrationType)
                    .HasConstraintName("FK__TB_ORDER__COD_T__5629CD9C");
            });

            modelBuilder.Entity<TbProduct>(entity =>
            {
                entity.HasKey(e => e.CodProduct)
                    .HasName("PK__TB_PRODU__AAF2697D78854622");

                entity.ToTable("TB_PRODUCT");

                entity.Property(e => e.CodProduct).HasColumnName("COD_PRODUCT");

                entity.Property(e => e.DescProduct)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESC_PRODUCT");

                entity.Property(e => e.ProductValue).HasColumnName("PRODUCT_VALUE");
            });

            modelBuilder.Entity<TbIntegrationProduct>(entity =>
            {
                entity.HasKey(e => new { e.IdProductFastorder, e.IdExternalProduct })
                    .HasName("PK__TB_INTEG__16241E49A05B3575");

                entity.ToTable("TB_INTEGRATION_PRODUCT");

                entity.Property(e => e.IdProductFastorder).HasColumnName("ID_PRODUCT_FASTORDER");

                entity.Property(e => e.IdExternalProduct).HasColumnName("ID_EXTERNAL_PRODUCT");

                entity.Property(e => e.IdIntegrationType).HasColumnName("ID_INTEGRATION_TYPE");
            });

            modelBuilder.Entity<TbOrderStatus>(entity =>
            {
                entity.HasKey(e => e.IdOrderStatus)
                    .HasName("PK__TB_ORDER__F8783C0BA4925CD6");

                entity.ToTable("TB_ORDER_STATUS");

                entity.Property(e => e.IdOrderStatus).HasColumnName("ID_ORDER_STATUS");

                entity.Property(e => e.DescOrderStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESC_ORDER_STATUS");
            });

            modelBuilder.Entity<TbIntegrationType>(entity =>
            {
                entity.HasKey(e => e.IdIntegrationType)
                    .HasName("PK__TB_TIPO___E7CCB0D693C39163");

                entity.ToTable("TB_INTEGRATION_TYPE");

                entity.Property(e => e.IdIntegrationType).HasColumnName("ID_INTEGRATION_TYPE");

                entity.Property(e => e.DescIntegrationType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESC_INTEGRATION_TYPE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}