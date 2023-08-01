using System;
using System.Collections.Generic;

namespace MittensBakery.SalesManagement.App.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<SalesOrderLineItem> SalesOrderLineItems { get; set; } = new List<SalesOrderLineItem>();
}
