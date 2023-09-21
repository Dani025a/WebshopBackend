using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBackend.Models;

public partial class OrderLineItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("my_row_id")]
    public ulong MyRowId { get; set; }

    [Required]
    [Column("fk_product_id")]
    public int? FkProductId { get; set; }

    [Required]
    [Column("fk_order_id")]
    public int? FkOrderId { get; set; }

    public virtual Order? FkOrder { get; set; }

    public virtual Product? FkProduct { get; set; }
}
