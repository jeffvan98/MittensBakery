using System;
using System.Collections.Generic;

namespace MittensBakery.SalesManagement.App.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}
