using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using movies_api.Data;
using movies_api.Data.Dtos.Movie;
using movies_api.Models;

namespace movies_api.Controllers;

[ApiController]
[Route("/movies")]
public class MovieController : ControllerBase
{

    private MovieContext _context;
    private IMapper _mapper;

    // dependencies injection
    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto) {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), new {id = movie.Id}, movie); // http status 201 (created)
    }

    [HttpGet]
    public IEnumerable<DetailingMovieDto> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 10) {  
        return _mapper.Map<List<DetailingMovieDto>>(_context.Movies.Skip(skip).Take(take).ToList()); 
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        Movie? movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if(movie == null) return NotFound(); // http status 404 (not found)
        DetailingMovieDto movieDetails = _mapper.Map<DetailingMovieDto>(movie); // return dto
        return Ok(movieDetails); // http status 200 (ok with body)
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto) {
        Movie? movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if(movie == null) return NotFound();
        _mapper.Map(movieDto, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateMoviePartial(
        int id, 
        [FromBody] JsonPatchDocument<UpdateMovieDto> movieDtoPartial
    ) {
        Movie? movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if(movie == null) return NotFound();

        UpdateMovieDto movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);
        movieDtoPartial.ApplyTo(movieToUpdate, ModelState);

        if(!TryValidateModel(movieToUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(movieToUpdate, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id) {
        Movie? movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if(movie == null) return NotFound();
        _context.Remove(movie);
        _context.SaveChanges();
        return NoContent();
    }
}
