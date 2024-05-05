using System.ComponentModel.DataAnnotations;

namespace movies_api.Data.Dtos.Session;

public class CreateSessionDto 
{
    [Required]
    public int MovieId { get; set; }

    [Required]
    public int CinemaId { get; set; }
}