using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace movies_api.Models;

public class Address
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string PublicPlace { get; set; }

    [Required]
    public int Number { get; set; }

    public virtual Cinema Cinema { get; set; } // set 1:1 relationship
}