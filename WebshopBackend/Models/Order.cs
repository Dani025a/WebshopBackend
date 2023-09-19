using System;
using System.Collections.Generic;

namespace WebshopBackend.Models;

public partial class Order
{
    public DateOnly? Date { get; set; }

    public int OrderId { get; set; }

    public sbyte? FkOrderStatus { get; set; }

    public int? FkPaymentId { get; set; }

    public int? FkUserId { get; set; }

    public virtual OrderStatus? FkOrderStatusNavigation { get; set; }

    public virtual Payment? FkPayment { get; set; }

    public virtual User? FkUser { get; set; }

    public virtual ICollection<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();
}
