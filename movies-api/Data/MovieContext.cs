using Microsoft.EntityFrameworkCore;
using movies_api.Models;

namespace movies_api.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options)
        : base(options)
    {
        
    }

    public DbSet<Movie> Movies { get; set;}
}