using System;
using System.Collections.Generic;

namespace WebshopBackend.Models;

public partial class Inventory
{
    public short? Stock { get; set; }

    public int InventoryId { get; set; }

    public int FkProductId { get; set; }

    public virtual Product FkProduct { get; set; } = null!;
}
