using System.ComponentModel.DataAnnotations;

namespace movies_api.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public int AddressId { get; set; }
    public virtual Address Address { get; set; } // set 1:1 relationship
}