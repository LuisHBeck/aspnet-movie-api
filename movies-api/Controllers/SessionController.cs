using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movies_api.Data;
using movies_api.Data.Dtos.Session;
using movies_api.Models;

namespace movies_api.Controllers;

[ApiController]
[Route("/sessions")]
public class SessionController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public SessionController(MovieContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddSession([FromBody] CreateSessionDto sessionDto)
    {
        Session session = _mapper.Map<Session>(sessionDto);
        _context.Add(session);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetSessionById), new 
            {movieId = session.MovieId, cinemaId = session.CinemaId}, 
            session
        );
    }

    [HttpGet]
    public IEnumerable<DetailingSessionDto> GetSessions([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<DetailingSessionDto>>(_context.Sessions.Skip(skip).Take(take));
    }

    [HttpGet("{movieId}/{cinemaId}")]
    public IActionResult GetSessionById(int movieId, int cinemaId)
    {
        Session? session = _context.Sessions.FirstOrDefault(
            session => session.MovieId == movieId && 
            session.CinemaId == cinemaId
        );
        if(session == null) return NotFound();
        DetailingSessionDto sessionDto = _mapper.Map<DetailingSessionDto>(session);
        return Ok(sessionDto);
    }
}