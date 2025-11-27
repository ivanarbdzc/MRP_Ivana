using System.Net;
using System.Text;
using MRP.Controllers;

namespace MRP.Server;

public class Router
{
    private readonly UserController _users;

    public Router(UserController users)
    {
        _users = users;
    }

    public void Handle(HttpListenerContext ctx)
    {
        string path = ctx.Request.Url.AbsolutePath.ToLower();
        string method = ctx.Request.HttpMethod;
        
        //Test endpoint
        if (path == "/test")
        {
            byte[] buffer = Encoding.UTF8.GetBytes("test");
            ctx.Response.OutputStream.Write(buffer, 0, buffer.Length);
            ctx.Response.Close();
            return;
        }
        
        if (path.StartsWith("/users/"))
        {
            _users.Handle(ctx);
            return;
        }
        
        ctx.Response.StatusCode = 404;
        ctx.Response.Close();
    }
    
}   