using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBackend.Models;

[Table("payments")]
public class Payment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("payment_id")]
    public int PaymentId { get; set; }
    
    [Required]
    [Column("total_price")]
    public decimal TotalPrice { get; set; }

    [Required]
    [Column("fk_user_id")]
    public int FkUserId { get; set; }
    
    public User FkUser { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();

    public ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
}
