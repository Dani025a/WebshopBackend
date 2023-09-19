using System;
using System.Collections.Generic;

namespace WebshopBackend.Models;

public partial class PaymentDetail
{
    public string? CardNumber { get; set; }

    public int? TransactionNumber { get; set; }

    public int PaymentDetailId { get; set; }

    public int? FkPaymentId { get; set; }

    public virtual Payment? Payment { get; set; }
}
