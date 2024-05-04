using System.ComponentModel.DataAnnotations;

namespace movies_api.Data.Dtos;

public class UpdateMovieDto
{
    [Required]
    public string Title { get; set; }

    [Required]
    [StringLength(50)]
    public string Gender { get; set; }

    [Required]
    [Range(45, 600)]
    public int Duration { get; set; }
}