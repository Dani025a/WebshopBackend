using System;
using System.Collections.Generic;

namespace WebshopBackend.Models;

public partial class Category
{
    public string? Name { get; set; }

    public int CategoryId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
