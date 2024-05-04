namespace movies_api.Data.Dtos.Movie;

public class DetailingMovieDto
{
    public int Id { get; set;}

    public string Title { get; set;}

    public string Gender { get; set;}

    public int Duration { get; set;}

    public DateTime requestTime { get; set; } = DateTime.Now;
}