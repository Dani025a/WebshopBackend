using System;
using System.Collections.Generic;

namespace WebshopBackend.Models;

public partial class OrderStatus
{
    public string? Name { get; set; }

    public sbyte OrderStatusId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
