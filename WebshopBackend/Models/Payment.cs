using System;
using System.Collections.Generic;

namespace WebshopBackend.Models;

public partial class Payment
{
    public decimal? TotalPrice { get; set; }

    public int? FkUserId { get; set; }

    public int PaymentId { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
}
