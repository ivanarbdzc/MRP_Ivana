using System.Net;
using System.Text.RegularExpressions;
using MRP.Services;

namespace MRP.Controllers;

public class MediaController
{
    public void Handle(HttpListenerContext ctx)
    {
        string path = ctx.Request.Url.AbsolutePath.ToLower();
        string method = ctx.Request.HttpMethod;
        
        if (path == "/api/media" && method == "GET")
        {
            HttpHelper.SendNotImplemented(ctx.Response);
            return;
        }

        if (path == "/api/media" && method == "POST")
        {
            HttpHelper.SendNotImplemented(ctx.Response);
            return;
        }
        
        if (Regex.IsMatch(path, @"^/api/media/\d+$") && method == "GET")
        {
            HttpHelper.SendNotImplemented(ctx.Response);
            return;
        }
        
        if (Regex.IsMatch(path, @"^/api/media/\d+$") && method == "PUT")
        {
            HttpHelper.SendNotImplemented(ctx.Response);
            return;
        }
        
        if (Regex.IsMatch(path, @"^/api/media/\d+$") && method == "DELETE")
        {
            HttpHelper.SendNotImplemented(ctx.Response);
            return;
        }

        if (Regex.IsMatch(path, @"^/api/media/\d+/favorite$") && method == "POST")
        {
            HttpHelper.SendNotImplemented(ctx.Response);
            return;
        }
        
        if (Regex.IsMatch(path, @"^/api/media/\d+/favorite$") && method == "DELETE")
        {
            HttpHelper.SendNotImplemented(ctx.Response);
            return;
        }

        if (Regex.IsMatch(path, @"^/api/media/\d+/rate$") & method == "POST")
        {
            HttpHelper.SendNotImplemented(ctx.Response);
            return;
        }
        
        ctx.Response.StatusCode = 404;
        ctx.Response.Close();
    }
}