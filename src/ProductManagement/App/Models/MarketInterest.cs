using System;
using System.Collections.Generic;

namespace MittensBakery.ProductManagement.App.Models;

public partial class MarketInterest
{
    public int ProductCategoryId { get; set; }

    public int PartyTypeId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ThruDate { get; set; }

    public virtual PartyType PartyType { get; set; } = null!;

    public virtual ProductCategory ProductCategory { get; set; } = null!;
}
