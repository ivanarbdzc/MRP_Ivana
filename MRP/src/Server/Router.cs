using System.Net;
using System.Text;
using MRP.Controllers;

namespace MRP.Server;

public class Router
{
    private readonly UserController _users;
    private readonly MediaController _media;
    private readonly RatingController _rating;
    private readonly LeaderboardController _leaderboard;

    public Router(UserController users, MediaController media, RatingController rating, LeaderboardController leaderboard)
    {
        _users = users;
        _media = media;
        _rating = rating;
        _leaderboard = leaderboard;
    }

    public void Handle(HttpListenerContext ctx)
    {
        string path = ctx.Request.Url.AbsolutePath.ToLower();
        string method = ctx.Request.HttpMethod;

        Console.WriteLine($"PATH: {path}, METHOD: {method}");
        
        if (path.StartsWith("/api/users"))
        {
            _users.Handle(ctx);
            return;
        }

        if (path.StartsWith("/api/media"))
        {
            _media.Handle(ctx);
            return;
        }

        if (path.StartsWith("/api/ratings"))
        {
            _rating.Handle(ctx);
            return;
        }

        if (path.StartsWith("/api/leaderboard"))
        {
            _leaderboard.Handle(ctx);
            return;
        }

        ctx.Response.StatusCode = 404;
        ctx.Response.Close();
    }
}   