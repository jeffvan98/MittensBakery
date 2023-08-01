using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MittensBakery.SalesManagement.App.Models;

public partial class SalesManagementContext : DbContext
{
    public SalesManagementContext(DbContextOptions<SalesManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; } = default!;

    public virtual DbSet<Product> Products { get; set; } = default!;

    public virtual DbSet<SalesOrder> SalesOrders { get; set; } = default!;

    public virtual DbSet<SalesOrderLineItem> SalesOrderLineItems { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Description).HasMaxLength(128);
        });

        modelBuilder.Entity<SalesOrder>(entity =>
        {
            entity.ToTable("SalesOrder");

            entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrder_Customer");
        });

        modelBuilder.Entity<SalesOrderLineItem>(entity =>
        {
            entity.HasKey(e => new { e.SalesOrderId, e.SalesOrderLineItemId });

            entity.ToTable("SalesOrderLineItem");

            entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
            entity.Property(e => e.SalesOrderLineItemId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SalesOrderLineItemID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesOrderLineItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderLineItem_Product");

            entity.HasOne(d => d.SalesOrder).WithMany(p => p.SalesOrderLineItems)
                .HasForeignKey(d => d.SalesOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderLineItem_SalesOrder");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
