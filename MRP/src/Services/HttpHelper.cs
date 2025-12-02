using System.Net;
using System.Text;

namespace MRP.Services;

public static class HttpHelper
{
    //methode für noch nciht implementierte Endpoints, damit diese auch was zurückgeben
    public static void SendNotImplemented(HttpListenerResponse response)
    {
        response.StatusCode = 501;
        byte[] bytes = Encoding.UTF8.GetBytes("{\"message\": \"Not implemented yet\"}");
        response.ContentType = "application/json";
        response.ContentLength64 = bytes.Length;

        response.OutputStream.Write(bytes, 0, bytes.Length);
        response.Close();
    }
}