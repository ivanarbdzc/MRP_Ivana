namespace MRP.Services;

public static class TokenService
{
    
    private static Dictionary<string, string> tokens = new();

    // erzeugt ein token für einen benutzer
    public static string CreateToken(string username)
    {
        
        string token = Guid.NewGuid().ToString();

        tokens[token] = username; 

        return token;
    }

    // prüft ob token gültig ist
    public static string? GetUsername(string token)
    {
        if (tokens.TryGetValue(token, out string username))
            return username;

        return null;
    }
}