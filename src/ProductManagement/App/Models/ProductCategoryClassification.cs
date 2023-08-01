using System;
using System.Collections.Generic;

namespace MittensBakery.ProductManagement.App.Models;

public partial class ProductCategoryClassification
{
    public int ProductId { get; set; }

    public int ProductCategoryId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ThruDate { get; set; }

    public bool PrimaryFlag { get; set; }

    public string? Comment { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ProductCategory ProductCategory { get; set; } = null!;
}
