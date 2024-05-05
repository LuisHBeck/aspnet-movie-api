using System.ComponentModel.DataAnnotations;

namespace movies_api.Models;

public class Session 
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public int MovieId { get; set; }
    public virtual Movie Movie { get; set; } // set 1:n relationship


    public int? CinemaId { get; set; } // int? means this fiel can be null
    public virtual Cinema Cinema { get; set; } // set 1:n relationship
}