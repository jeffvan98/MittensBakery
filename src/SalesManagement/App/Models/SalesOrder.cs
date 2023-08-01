using System;
using System.Collections.Generic;

namespace MittensBakery.SalesManagement.App.Models;

public partial class SalesOrder
{
    public int SalesOrderId { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<SalesOrderLineItem> SalesOrderLineItems { get; set; } = new List<SalesOrderLineItem>();
}
