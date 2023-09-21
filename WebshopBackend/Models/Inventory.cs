using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBackend.Models;
[Table("inventory")]
public class Inventory
{
    [Required]
    [Column("stock")]
    public short? Stock { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("inventory_id")]
    public int InventoryId { get; set; }
    [Required]
    [Column("fk_product_id")]
    public int FkProductId { get; set; }

    public Product FkProduct { get; set; } = null!;
}
