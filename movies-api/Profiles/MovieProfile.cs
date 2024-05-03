using AutoMapper;
using movies_api.Data.Dtos;
using movies_api.Models;

namespace movies_api.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
    }
}