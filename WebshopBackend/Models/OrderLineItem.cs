using System;
using System.Collections.Generic;

namespace WebshopBackend.Models;

public partial class OrderLineItem
{
    public ulong MyRowId { get; set; }

    public int? FkProductId { get; set; }

    public int? FkOrderId { get; set; }

    public virtual Order? FkOrder { get; set; }

    public virtual Product? FkProduct { get; set; }
}
