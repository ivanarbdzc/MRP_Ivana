using System.Net;
using System.Text.RegularExpressions;
using MRP.Services;

namespace MRP.Controllers;

public class RatingController
{
    public void Handle(HttpListenerContext ctx)
    {
        string path = ctx.Request.Url.AbsolutePath.ToLower();
        string method = ctx.Request.HttpMethod;
        
        if (Regex.IsMatch(path, @"^/api/ratings/\d+$") && method == "PUT")
        {
            HttpHelper.SendNotImplemented(ctx.Response);
            return;
        }
        
        if (Regex.IsMatch(path, @"^/api/ratings/\d+$") && method == "DELETE")
        {
            HttpHelper.SendNotImplemented(ctx.Response);
            return;
        }
        
        if (Regex.IsMatch(path, @"^/api/ratings/\d+/like$") && method == "POST")
        {
            HttpHelper.SendNotImplemented(ctx.Response);
            return;
        }

        if (Regex.IsMatch(path, @"^/api/ratings/\d+/confirm$") && method == "POST")
        {
            HttpHelper.SendNotImplemented(ctx.Response);
            return;
        }
        
        ctx.Response.StatusCode = 404;
        ctx.Response.Close();
    }
}