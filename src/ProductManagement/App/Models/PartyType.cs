using System;
using System.Collections.Generic;

namespace MittensBakery.ProductManagement.App.Models;

public partial class PartyType
{
    public int PartyTypeId { get; set; }

    public string Descrption { get; set; } = null!;

    public virtual ICollection<MarketInterest> MarketInterests { get; set; } = new List<MarketInterest>();
}
