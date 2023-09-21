using WebshopBackend.Models;
using System.Diagnostics.Metrics;

namespace WebshopBackend.Interfaces
{
    public interface IAddressRepository
    {
        ICollection<Address> GetAddresses();
        Address GetAddress(int addressid);
        bool AddressExists(int addressid);
        bool CreateAddress(Address address);
        bool UpdateAddress(Address address);
        bool DeleteAddress(Address address);
        bool Save();
        Address GetAddressByUser(int userid);

    }
}