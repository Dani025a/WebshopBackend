using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBackend.Models;

public partial class Address
{
    [Required]
    [MaxLength(40)]
    [Column("zip_code")]
    public string? ZipCode { get; set; }
    [Required]
    [MaxLength(40)]
    [Column("street_name")]
    public string? StreetName { get; set; }
    [Required]
    [Column("street_number")]
    public short? StreetNumber { get; set; }
    [Required]
    [MaxLength(40)]
    [Column("city")]
    public string? City { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("address_id")]
    public int AddressId { get; set; }
    [Required]
    [Column("fk_user_id")]
    public int? FkUserId { get; set; }

    public virtual User? FkUser { get; set; }
}
