using System;
using System.Collections.Generic;

namespace WebshopBackend.Models;

public partial class Address
{
    public string? ZipCode { get; set; }

    public string? StreetName { get; set; }

    public short? StreetNumber { get; set; }

    public string? City { get; set; }

    public int AddressId { get; set; }

    public int? FkUserId { get; set; }

    public virtual User User { get; set; }
}
