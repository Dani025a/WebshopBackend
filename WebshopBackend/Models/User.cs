using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBackend.Models;

[Table("users")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("user_id")]
    public int UserId { get; set; }
    
    [Required]
    [MaxLength(40)]
    [Column("first_name")]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(40)]
    [Column("last_name")]
    public string? LastName { get; set; }

    [Required]
    [MaxLength(40)]
    [Column("password")]
    public string? Password { get; set; }

    [Required]
    [MaxLength(40)]
    [Column("email")]
    public string? Email { get; set; }

    [Required]
    [MaxLength(40)]
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    public Address Address { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
