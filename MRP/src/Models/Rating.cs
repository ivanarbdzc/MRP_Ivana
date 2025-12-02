namespace MRP.Models;

public class Rating
{
    public int Id { get; set; }
    public int MediaId { get; set; }
    public string Username { get; set; } = "";
    public int Stars { get; set; } // 1–5
    public string Comment { get; set; } = "";
    public DateTime Timestamp { get; set; }
    public bool Confirmed { get; set; } = false;
    public int LikeCount { get; set; } = 0;
}