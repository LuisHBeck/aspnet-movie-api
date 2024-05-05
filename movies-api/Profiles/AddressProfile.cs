using AutoMapper;
using movies_api.Data.Dtos.Address;
using movies_api.Models;

namespace movies_api.Profiles;

public class AdressProfile : Profile
{
    public AdressProfile()
    {
        CreateMap<CreateAddressDto, Address>();
        CreateMap<UpdateAddressDto, Address>();
        CreateMap<Address, UpdateAddressDto>();
        CreateMap<Address, DetailingAddressDto>();
    }
}