using System.Net;

namespace MRP.Controllers;

public class UserController
{
    public void Handle(HttpListenerContext ctx)
    {
        string path = ctx.Request.Url.AbsolutePath.ToLower();
        string method = ctx.Request.HttpMethod;

        //Hier später register login
        ctx.Response.StatusCode = 404;
        ctx.Response.Close();
    }
}