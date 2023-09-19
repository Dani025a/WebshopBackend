using System;
using System.Collections.Generic;

namespace WebshopBackend.Models;

public partial class Category
{
    public string? Name { get; set; }

    public int CategoryId { get; set; }

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}
