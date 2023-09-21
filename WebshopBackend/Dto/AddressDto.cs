namespace WebshopBackend.Dto
{
    public class AddressDto
    {
        public string? ZipCode { get; set; }

        public string? StreetName { get; set; }

        public short? StreetNumber { get; set; }

        public string? City { get; set; }

        public int AddressId { get; set; }
    }
}
