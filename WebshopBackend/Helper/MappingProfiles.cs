using AutoMapper;
using WebshopBackend.Dto;
using WebshopBackend.Models;

namespace WebshopBackend.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<Address, AddressDto>();
        }
    }
}