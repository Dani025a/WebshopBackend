using AutoMapper;
using WebshopBackend.Data;
using WebshopBackend.Interfaces;
using WebshopBackend.Models;
using System.Diagnostics.Metrics;

namespace WebshopBackend.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly WebshopContext _context;
        private readonly IMapper _mapper;

        public AddressRepository(WebshopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool AddressExists(int addressid)
        {
            return _context.Addresses.Any(a => a.AddressId == addressid);
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

        public ICollection<Address> GetAddresses()
        {
            return _context.Addresses.ToList();
        }

        public Address GetAddress(int addressid)
        {
            return _context.Addresses.Where(a => a.AddressId == addressid).FirstOrDefault();
        }

        public Address GetAddressByUser(int userid)
        {
            return _context.Users.Where(u => u.UserId == userid).Select(c => c.Address).FirstOrDefault();
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