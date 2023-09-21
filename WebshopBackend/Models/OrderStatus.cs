using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBackend.Models;

[Table("order_status")]
public partial class OrderStatus
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("order_status_id")]
    public short? OrderStatusId { get; set; }
    
    [Required]
    public Enum Name { get; set; }
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
