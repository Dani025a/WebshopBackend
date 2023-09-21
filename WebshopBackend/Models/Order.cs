using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBackend.Models;

public partial class Order
{
    public DateOnly? Date { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("order_id")]
    public int OrderId { get; set; }
    [Required]
    [Column("fk_order_status")]
    public sbyte? FkOrderStatus { get; set; }
    [Required]
    [Column("fk_payment_id")]
    public int? FkPaymentId { get; set; }
    [Required]
    [Column("fk_user_")]
    public int? FkUserId { get; set; }

    public virtual OrderStatus? FkOrderStatusNavigation { get; set; }

    public virtual Payment? FkPayment { get; set; }

    public virtual User? FkUser { get; set; }

    public virtual ICollection<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();
}
