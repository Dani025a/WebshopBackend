using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBackend.Models;

[Table("order_status")]
public class OrderStatus
{
    public enum OrderStatusEnum
    {
        [Display(Name = "Order received")]
        OrderReceived,
    
        [Display(Name = "In Progress")]
        InProgress,
    
        [Display(Name = "Order delivered")]
        OrderDelivered
    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("order_status_id")]
    public short OrderStatusId { get; set; }
    
    [Required]
    [Column("name", TypeName = "ENUM('Order received', 'In Progress', 'Order delivered')")]
    public OrderStatusEnum Name { get; set; }
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
