using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using WebshopBackend.Dto;
using WebshopBackend.Interfaces;
using WebshopBackend.Models;

namespace WebshopBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CountryController : Controller
        {
            private readonly IAddressRepository _addressRepository;
            private readonly IMapper _mapper;

            public CountryController(IAddressRepository addressRepository, IMapper mapper)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
            }

            [HttpGet]
            [ProducesResponseType(200, Type = typeof(IEnumerable<Address>))]
            public IActionResult GetAddresses()
            {
                var addresses = _mapper.Map<List<AddressDto>>(_addressRepository.GetAddresses());

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(addresses);
            }

            [HttpGet("{addressid}")]
            [ProducesResponseType(200, Type = typeof(Address))]
            [ProducesResponseType(400)]
            public IActionResult GetAddress(int addressid)
            {
                if (!_addressRepository.AddressExists(addressid))
                    return NotFound();

                var address = _mapper.Map<AddressDto>(_addressRepository.GetAddress(addressid));

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(address);
            }
        }
    }
}