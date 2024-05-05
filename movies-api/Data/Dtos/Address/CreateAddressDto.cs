using System.ComponentModel.DataAnnotations;

namespace movies_api.Data.Dtos.Address;

public class CreateAddressDto
{
    [Required]
    public String PublicPlace { get; set; }

    [Required]
    public int Number { get; set; }
}