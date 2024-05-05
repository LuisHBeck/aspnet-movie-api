using AutoMapper;
using movies_api.Data.Dtos.Session;
using movies_api.Models;

namespace movies_api.Profiles;

public class SessionProfile : Profile
{
    public SessionProfile()
    {
        CreateMap<CreateSessionDto, Session>();
        CreateMap<Session, DetailingSessionDto>();
    }
}