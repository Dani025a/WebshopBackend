using WebshopBackend.Models;

namespace WebshopBackend.Interfaces
{
    public interface IAddressRepository
    {
        ICollection<Address> GetAddresses();
        Address GetAddress(int addressid);
        bool AddressExists(int addressId);
        Address GetAddressByUser(int userId);
        bool CreateAddress(Address address);
        bool UpdateAddress(Address address);
        bool Save();
    }
}
