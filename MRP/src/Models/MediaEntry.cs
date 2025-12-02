namespace MRP.Models;

public class MediaEntry
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string MediaType { get; set; } = ""; // movie, series, game
    public int ReleaseYear { get; set; }
    public List<string> Genres { get; set; } = new();
    public int AgeRestriction { get; set; }
}