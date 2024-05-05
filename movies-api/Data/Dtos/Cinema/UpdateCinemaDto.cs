using System.ComponentModel.DataAnnotations;

namespace movies_api.Data.Dtos.Cinema;

public class UpdateCinemaDto
{   
    [Required]
    public string Name { get; set; }
}