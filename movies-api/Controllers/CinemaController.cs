using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies_api.Data;
using movies_api.Data.Dtos.Cinema;
using movies_api.Models;

namespace movies_api.Controllers;

[ApiController]
[Route("/cinemas")]
public class CinemaController : ControllerBase
{

    private MovieContext _context;
    private IMapper _mapper;

    public CinemaController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCinemaById), new {id = cinema.Id}, cinema);
    }

    [HttpGet]
    public IEnumerable<DetailingCinemaDto> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        List<DetailingCinemaDto> cinemasList = _mapper.Map<List<DetailingCinemaDto>>(
            _context.Cinemas
                .Include(cinema => cinema.Address)
                .Skip(skip)
                .Take(take)
        );
        return cinemasList;
    }

    [HttpGet("{id}")]
    public IActionResult GetCinemaById(int id)
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if(cinema == null) return NotFound();
        DetailingCinemaDto cinemaDetails = _mapper.Map<DetailingCinemaDto>(cinema);
        return Ok(cinemaDetails);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if(cinema == null) return NotFound();
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DetelteCinema(int id)
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if(cinema == null) return NotFound();
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
}