using AutoMapper;
using movies_api.Data.Dtos.Movie;
using movies_api.Models;

namespace movies_api.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<UpdateMovieDto, Movie>();
        CreateMap<Movie, UpdateMovieDto>();
        CreateMap<Movie, DetailingMovieDto>();
    }
}