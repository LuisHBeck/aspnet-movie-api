using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movies_api.Data;
using movies_api.Data.Dtos.Address;
using movies_api.Models;

namespace movies_api.Controllers;

[ApiController]
[Route("/addresses")]
public class AddressController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public AddressController(MovieContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddAdress([FromBody] CreateAddressDto addressDto)
    {
        Address address = _mapper.Map<Address>(addressDto);
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAddressById), new {id = address.Id}, address);
    }

    [HttpGet]
    public IEnumerable<DetailingAddressDto> GetAddresses([FromQuery] int skip = 0, [FromQuery] int take = 10) 
    {
        return _mapper.Map<List<DetailingAddressDto>>(_context.Addresses.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(int id)
    {
        Address? address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if(address == null) return NotFound();
        DetailingAddressDto adressDetails = _mapper.Map<DetailingAddressDto>(address);
        return Ok(adressDetails);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDto addressDto)
    {
        Address? address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if(address == null) return NotFound();
        _mapper.Map(addressDto, address);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        Address? address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if(address == null) return NotFound();
        _context.Remove(address);
        _context.SaveChanges();
        return NoContent();
    }
}