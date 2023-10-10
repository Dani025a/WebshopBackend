
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebshopBackend.Dto;
using WebshopBackend.Interfaces;
using WebshopBackend.Models;
using WebshopBackend.Repositories;

namespace WebshopBackend.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        [HttpGet("")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Address>))]
        public IActionResult GetAddresses()
        {
            var adresses = _mapper.Map<List<AddressDto>>(_addressRepository.GetAddresses());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(adresses);
        }

        [HttpGet("{addressId}")]
        [ProducesResponseType(200, Type = typeof(Address))]
        [ProducesResponseType(400)]
        public IActionResult GetAddress(int addressId)
        {
            if (!_addressRepository.AddressExists(addressId))
                return NotFound();

            var address = _mapper.Map<AddressDto>(_addressRepository.GetAddress(addressId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(address);
        }

        [HttpGet("user/{userid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Address))]
        public IActionResult GetAddressOfAnUser(int userid)
        {
            var address = _mapper.Map<AddressDto>(
                _addressRepository.GetAddressByUser(userid));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(address);
        }

        [HttpPost("")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAddress([FromBody] AddressDto addressCreate)
        {
            if (addressCreate == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var addressMap = _mapper.Map<Address>(addressCreate);

            if (!_addressRepository.CreateAddress(addressMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{addressId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int addressId, [FromBody] AddressDto updatedAddress)
        {
            if (updatedAddress == null)
                return BadRequest(ModelState);

            if (addressId != updatedAddress.AddressId)
                return BadRequest(ModelState);

            if (!_addressRepository.AddressExists(addressId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var addressMap = _mapper.Map<Address>(updatedAddress);

            if (!_addressRepository.UpdateAddress(addressMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{addressId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAddress(int addressId)
        {
            if (!_addressRepository.AddressExists(addressId))
            {
                return NotFound();
            }

            var addressToDelete = _addressRepository.GetAddress(addressId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_addressRepository.DeleteAddress(addressToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
