using AutoMapper;
using movies_api.Data.Dtos.Cinema;
using movies_api.Models;

namespace movies_api.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema, UpdateCinemaDto>();

        CreateMap<Cinema, DetailingCinemaDto>()
            .ForMember(cinemaDto => cinemaDto.Address,
                opt => opt.MapFrom(cinema => cinema.Address)
            )
            .ForMember(cinemaDto => cinemaDto.Sessions,
                opt => opt.MapFrom(cinema => cinema.Sessions)
            );
    }
}