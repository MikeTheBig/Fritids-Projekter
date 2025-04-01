namespace Backend.Models
{
public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int DurationInMinutes { get; set; }
    public List<Show> Shows { get; set; } = new();
}
}