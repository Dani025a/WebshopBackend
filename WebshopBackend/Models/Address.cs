using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBackend.Models;

[Table("address")]
public class Address
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("address_id")]
    public int AddressId { get; set; }
    [Required]
    [MaxLength(40)]
    [Column("street_name")]
    public string StreetName { get; set; }

    [Required]
    [MaxLength(40)]
    [Column("street_number")]
    public string StreetNumber { get; set; }

    [Required]
    [MaxLength(40)]
    [Column("zip_code")]
    public string ZipCode { get; set; }

    [Required]
    [MaxLength(40)]
    [Column("city")]
    public string City { get; set; }

    [Required]
    [Column("fk_user_id")]
    public int FkUserId { get; set; }

    public User? FkUser { get; set; }
}
