using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MittensBakery.ProductManagement.App.Models;

public partial class ProductManagementContext : DbContext
{
    public ProductManagementContext(DbContextOptions<ProductManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MarketInterest> MarketInterests { get; set; } = default!;

    public virtual DbSet<PartyType> PartyTypes { get; set; } = default!;

    public virtual DbSet<Product> Products { get; set; } = default!;

    public virtual DbSet<ProductCategory> ProductCategories { get; set; } = default!;

    public virtual DbSet<ProductCategoryClassification> ProductCategoryClassifications { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MarketInterest>(entity =>
        {
            entity.HasKey(e => new { e.ProductCategoryId, e.PartyTypeId, e.FromDate });

            entity.ToTable("MarketInterest");

            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.PartyTypeId).HasColumnName("PartyTypeID");
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.ThruDate).HasColumnType("date");

            entity.HasOne(d => d.PartyType).WithMany(p => p.MarketInterests)
                .HasForeignKey(d => d.PartyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MarketInterest_PartyType");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.MarketInterests)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MarketInterest_ProductCategory");
        });

        modelBuilder.Entity<PartyType>(entity =>
        {
            entity.ToTable("PartyType");

            entity.Property(e => e.PartyTypeId).HasColumnName("PartyTypeID");
            entity.Property(e => e.Descrption).HasMaxLength(512);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Comment).HasMaxLength(2048);
            entity.Property(e => e.IntroductionDate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.SalesDiscontinuationDate).HasColumnType("date");
            entity.Property(e => e.SupportDiscontinuationDate).HasColumnType("date");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductCategory");

            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.Description).HasMaxLength(2048);

            entity.HasMany(d => d.ProductCategories).WithMany(p => p.ProductSubcategories)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCategoryRollup",
                    r => r.HasOne<ProductCategory>().WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductCategoryRollup_ProductCategory"),
                    l => l.HasOne<ProductCategory>().WithMany()
                        .HasForeignKey("ProductSubcategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductCategoryRollup_ProductSubcategory"),
                    j =>
                    {
                        j.HasKey("ProductCategoryId", "ProductSubcategoryId");
                        j.ToTable("ProductCategoryRollup");
                        j.IndexerProperty<int>("ProductCategoryId").HasColumnName("ProductCategoryID");
                        j.IndexerProperty<int>("ProductSubcategoryId").HasColumnName("ProductSubcategoryID");
                    });

            entity.HasMany(d => d.ProductSubcategories).WithMany(p => p.ProductCategories)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCategoryRollup",
                    r => r.HasOne<ProductCategory>().WithMany()
                        .HasForeignKey("ProductSubcategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductCategoryRollup_ProductSubcategory"),
                    l => l.HasOne<ProductCategory>().WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductCategoryRollup_ProductCategory"),
                    j =>
                    {
                        j.HasKey("ProductCategoryId", "ProductSubcategoryId");
                        j.ToTable("ProductCategoryRollup");
                        j.IndexerProperty<int>("ProductCategoryId").HasColumnName("ProductCategoryID");
                        j.IndexerProperty<int>("ProductSubcategoryId").HasColumnName("ProductSubcategoryID");
                    });
        });

        modelBuilder.Entity<ProductCategoryClassification>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.ProductCategoryId, e.FromDate });

            entity.ToTable("ProductCategoryClassification");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.Comment).HasMaxLength(2048);
            entity.Property(e => e.ThruDate).HasColumnType("date");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.ProductCategoryClassifications)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCategoryClassification_ProductCategory");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCategoryClassifications)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCategoryClassification_Product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
