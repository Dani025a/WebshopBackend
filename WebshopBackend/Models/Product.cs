using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBackend.Models;

[Table("products")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("product_id")]
    public int ProductId { get; set; }
    
    [Required]
    [MaxLength(40)]
    [Column("name")]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(40)]
    [Column("description")]
    public string Description { get; set; }

    [Required]
    [Column("price")]
    public decimal Price { get; set; }
    
    [Required]
    [Column("fk_category_id")]
    public int FkCategoryId { get; set; }

    [MaxLength(255)]
    public string Imageurl { get; set; }

    public Category FkCategory { get; set; }

    public Inventory Inventory { get; set; }

    public ICollection<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();
}
