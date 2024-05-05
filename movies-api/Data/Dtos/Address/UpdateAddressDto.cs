using System.ComponentModel.DataAnnotations;

namespace movies_api.Data.Dtos.Address;

public class UpdateAddressDto
{
    [Required]
    public string PublicPlace { get; set; }
    [Required]

    public int Number;
}