using System;
using System.Collections.Generic;

namespace WebshopBackend.Models;

public partial class VGetProductAndInventory
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public int InventoryId { get; set; }

    public short? Stock { get; set; }
}
