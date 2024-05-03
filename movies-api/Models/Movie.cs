using System.ComponentModel.DataAnnotations;
using movies_api.Data.Dtos;

namespace movies_api.Models;

public class Movie
{   
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title field is required")]
    public string Title { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "gender field can't exceed 50 characters")]
    public string Gender { get; set; }

    [Required]
    [Range(45,600)]
    public int Duration { get; set; }
}
