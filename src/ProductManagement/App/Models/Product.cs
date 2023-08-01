using System;
using System.Collections.Generic;

namespace MittensBakery.ProductManagement.App.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? IntroductionDate { get; set; }

    public DateTime? SalesDiscontinuationDate { get; set; }

    public DateTime? SupportDiscontinuationDate { get; set; }

    public string? Comment { get; set; }

    public virtual ICollection<ProductCategoryClassification> ProductCategoryClassifications { get; set; } = new List<ProductCategoryClassification>();
}
