namespace MRP.Models;

public class User
{
    public int Id { get; set; }

    // login Credentials
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";

    // profile info
    public string Email { get; set; } = "";
    public string FavoriteGenre { get; set; } = "";
}