using System;
using System.Collections.Generic;

namespace MittensBakery.ProductManagement.App.Models;

public partial class ProductCategory
{
    public int ProductCategoryId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<MarketInterest> MarketInterests { get; set; } = new List<MarketInterest>();

    public virtual ICollection<ProductCategoryClassification> ProductCategoryClassifications { get; set; } = new List<ProductCategoryClassification>();

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public virtual ICollection<ProductCategory> ProductSubcategories { get; set; } = new List<ProductCategory>();
}
