using movies_api.Data.Dtos.Address;
using movies_api.Data.Dtos.Session;

namespace movies_api.Data.Dtos.Cinema;

public class DetailingCinemaDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DetailingAddressDto Address { get; set; } 

    public ICollection<DetailingSessionDto> Sessions { get; set; }

}