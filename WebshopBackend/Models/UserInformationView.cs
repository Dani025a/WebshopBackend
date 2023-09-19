using System;
using System.Collections.Generic;

namespace WebshopBackend.Models;

public partial class UserInformationView
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? ZipCode { get; set; }

    public string? StreetName { get; set; }

    public short? StreetNumber { get; set; }

    public string? City { get; set; }
}
