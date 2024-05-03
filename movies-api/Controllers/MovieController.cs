using Microsoft.AspNetCore.Mvc;
using movies_api.Data;
using movies_api.Models;

namespace movies_api.Controllers;

[ApiController]
[Route("/movies")]
public class MovieController : ControllerBase
{

    private MovieContext _context;

    public MovieController(MovieContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie movie) {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), new {id = movie.Id}, movie); // http status 201 (created)
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 10) {  
        return _context.Movies.Skip(skip).Take(take); 
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        Movie? movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if(movie == null) return NotFound(); // http status 404 (not found)
        return Ok(movie); // http status 200 (ok with body)
    }
}
