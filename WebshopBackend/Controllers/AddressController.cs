using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebshopBackend.Interfaces;

namespace WebshopBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository,
            IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
    }
}