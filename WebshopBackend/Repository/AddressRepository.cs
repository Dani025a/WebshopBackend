using System.Diagnostics.Metrics;
using WebshopBackend.Data;
using WebshopBackend.Interfaces;
using WebshopBackend.Models;

namespace WebshopBackend.Repositoy
{
    public class AddressRepository : IAddressRepository
    {
        private readonly WebshopContext _context;

        public AddressRepository(WebshopContext context)
        {
            _context = context;
        }
        public bool AddressExists(int addressId)
        {
            return _context.Addresses.Any(a => a.AddressId == addressId);
        }

        public bool CreateAddress(Address address)
        {
            _context.Add(address);
            return Save();
        }

        public Address GetAddress(int addressid)
        {
            return _context.Addresses.Where(a => a.AddressId == addressid).FirstOrDefault();
        }

        public Address GetAddressByUser(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId).Select(a => a.Address).FirstOrDefault();

        }

        public ICollection<Address> GetAddresses()
        {
            return _context.Addresses.ToList();

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAddress(Address address)
        {
            _context.Update(address);
            return Save();
        }
    }
}
