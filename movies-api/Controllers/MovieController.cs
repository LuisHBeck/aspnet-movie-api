using Microsoft.AspNetCore.Mvc;
using movies_api.Models;

namespace movies_api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private static List<Movie> movies = new List<Movie>();
    private static int id = 1;

    [HttpPost]
    public void AddMovie([FromBody] Movie movie) {
        movie.Id = id++;
        movies.Add(movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 10) {  
        return movies.Skip(skip).Take(take); 
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        Movie? movie = movies.FirstOrDefault(movie => movie.Id == id);
        if(movie == null) return NotFound();
        return Ok(movie);
    }
}
