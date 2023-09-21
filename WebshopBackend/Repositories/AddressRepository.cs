using WebshopBackend.Data;
using WebshopBackend.Interfaces;
using WebshopBackend.Models;

namespace WebshopBackend.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly WebshopContext _context;

        public AddressRepository(WebshopContext context)
        {
            _context = context;
        }

        public bool CreateAddress(Address address)
        {
            _context.Add(address);
            return Save();
        }

        public bool DeleteAddress(Address address)
        {
            _context.Remove(address);
            return Save();
        }

        public Address GetAddress(int addressid)
        {
            return _context.Addresses.Where(a => a.AddressId == addressid).FirstOrDefault();
        }


        public ICollection<Address> GetAddresses()
        {
            return _context.Addresses.ToList();
        }


        public bool AddressExists(int addressid)
        {
            return _context.Addresses.Any(a => a.AddressId == addressid);
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

        public Address GetAddressByUser(int userid)
        {
            return _context.Users.Where(u => u.UserId == userid).Select(a => a.Address).FirstOrDefault();
        }
    }
}