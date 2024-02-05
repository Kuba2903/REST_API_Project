using System;
using System.Collections.Generic;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Data;

public partial class ShopContext : DbContext
{
    public ShopContext()
    {
    }

    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HP;Initial Catalog=shop;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.Sku }).HasName("PK__inventor__3ADF894B7403557B");

            entity.ToTable("inventory");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Sku)
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sku");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("manufacturer");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.ShipCost).HasColumnName("ship_cost");
            entity.Property(e => e.ShipTime)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ship_time");
            entity.Property(e => e.Unit)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("unit");

            entity.HasOne(d => d.Product).WithOne(p => p.Inventory)
                .HasForeignKey<Inventory>(d => new { d.ProductId, d.Sku })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__inventory__267ABA7A");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Sku }).HasName("PK__prices__4FCE1C81A6EB1BC4");

            entity.ToTable("prices");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Sku)
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sku");
            entity.Property(e => e.NetPrice).HasColumnName("net_price");
            entity.Property(e => e.PriceAfterDiscount).HasColumnName("price_after_discount");
            entity.Property(e => e.PriceAfterDiscountLogisticUnit).HasColumnName("price_after_discount_logistic_unit");
            entity.Property(e => e.VatRate).HasColumnName("vat_rate");

            entity.HasOne(d => d.Product).WithOne(p => p.Price)
                .HasForeignKey<Price>(d => new { d.Id, d.Sku })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__prices__29572725");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Sku }).HasName("PK__products__4FCE1C81D999A31F");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Sku)
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sku");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.DefaultImage)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("default_image");
            entity.Property(e => e.Ean)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ean");
            entity.Property(e => e.IsAvailable).HasColumnName("is_available");
            entity.Property(e => e.IsVendor).HasColumnName("is_vendor");
            entity.Property(e => e.IsWire).HasColumnName("is_wire");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ProducerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("producer_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
