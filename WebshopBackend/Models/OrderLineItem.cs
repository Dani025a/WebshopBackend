using System;
using System.Collections.Generic;

namespace WebshopBackend.Models;

public partial class OrderLineItem
{

    public int? FkProductId { get; set; }

    public int? FkOrderId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
