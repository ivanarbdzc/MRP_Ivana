using System.Net;
using System.Text.RegularExpressions;
using MRP.Services;

namespace MRP.Controllers;

public class LeaderboardController
{
    public void Handle(HttpListenerContext ctx)
    {
        string path = ctx.Request.Url.AbsolutePath.ToLower();
        string method = ctx.Request.HttpMethod;
        
        if (path == "/api/leaderboard" && method == "GET")
        {
            HttpHelper.SendNotImplemented(ctx.Response);
            return;
        }
        
        ctx.Response.StatusCode = 404;
        ctx.Response.Close();
    }
}