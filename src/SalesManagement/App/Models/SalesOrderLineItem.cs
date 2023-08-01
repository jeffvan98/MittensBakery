using System;
using System.Collections.Generic;

namespace MittensBakery.SalesManagement.App.Models;

public partial class SalesOrderLineItem
{
    public int SalesOrderId { get; set; }

    public int SalesOrderLineItemId { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual SalesOrder SalesOrder { get; set; } = null!;
}
