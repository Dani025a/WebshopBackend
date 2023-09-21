using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBackend.Models;
[Table("categories")]
public class Category
{
    [Required]
    [MaxLength(50)]
    [Column("name")]
    public string? Name { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("category_id")]
    public int CategoryId { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
