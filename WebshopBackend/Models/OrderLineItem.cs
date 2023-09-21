using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBackend.Models;
[Table("order_line_items")]
public class OrderLineItem
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

    public Order? FkOrder { get; set; }

    public Product? FkProduct { get; set; }
}
