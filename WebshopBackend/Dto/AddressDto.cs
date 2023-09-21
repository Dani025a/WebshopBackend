using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebshopBackend.Models;

namespace WebshopBackend.Dto
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public string ZipCode { get; set; }
        public string StreetName { get; set; }
        public short StreetNumber { get; set; }
        public string City { get; set; }

    }
}

