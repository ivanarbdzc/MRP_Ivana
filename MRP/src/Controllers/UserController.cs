using System.Net;
using System.Text;
using System.Text.Json;
using MRP.Models;

namespace MRP.Controllers;

public class UserController
{
    public void Handle(HttpListenerContext ctx)
    {
        string path = ctx.Request.Url.AbsolutePath.TrimEnd('/').ToLower();
        string method = ctx.Request.HttpMethod;

        if (path == "/users/register" && method == "POST")
        {
            HandleRegister(ctx);
            return;
        }

        if (path == "/users/login" && method == "POST")
        {
            HandleLogin(ctx);
            return;
        }

        ctx.Response.StatusCode = 404;
        ctx.Response.Close();
    }

    // Register
    private void HandleRegister(HttpListenerContext ctx)
    {
        var data = ReadJson<RegisterRequest>(ctx.Request);

        SendJson(ctx.Response, new 
        {
            success = true,
            message = "User registered",
            username = data.username
        });
    }

    // Login
    private void HandleLogin(HttpListenerContext ctx)
    {
        var data = ReadJson<RegisterRequest>(ctx.Request);

        SendJson(ctx.Response, new 
        {
            success = true,
            message = "Login OK",
            username = data.username
        });
    }

    // Json Parsing
    private T ReadJson<T>(HttpListenerRequest request)
    {
        using var reader = new StreamReader(request.InputStream, Encoding.UTF8);
        string body = reader.ReadToEnd();

        return JsonSerializer.Deserialize<T>(body)!;
    }

    // Json Response
    private void SendJson(HttpListenerResponse response, object obj)
    {
        string json = JsonSerializer.Serialize(obj);

        byte[] bytes = Encoding.UTF8.GetBytes(json);

        response.ContentType = "application/json";
        response.ContentLength64 = bytes.Length;

        response.OutputStream.Write(bytes, 0, bytes.Length);
        response.Close();
    }
}
