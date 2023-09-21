using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBackend.Models;
[Table("payment_details")]
public class PaymentDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("payment_detail_id")]
    public int PaymentDetailId { get; set; }
    
    [Required]
    [MaxLength(150)]
    [Column("card_number")]
    public string CardNumber { get; set; }

    [Required]
    [MaxLength(150)]
    [Column("transaction_number")]
    public string TransactionNumber { get; set; }
    
    [Required]
    [Column("fk_payment_id")]
    public int FkPaymentId { get; set; }

    public Payment FkPayment { get; set; }

}
