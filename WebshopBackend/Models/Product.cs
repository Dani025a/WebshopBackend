using System;
using System.Collections.Generic;

namespace WebshopBackend.Models;

public partial class Product
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int ProductId { get; set; }

    public int? FkCategoryId { get; set; }

    public string? Imageurl { get; set; }

    public virtual ICollection<ProductCategory> ProductCategory { get; set; } = new List<ProductCategory>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();
}
