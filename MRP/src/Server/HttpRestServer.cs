using System.Net;

namespace MRP.Server;

public class HttpRestServer : IDisposable
{
    private readonly HttpListener _listener;
    
    // konstruktor, öffnet mit allen hostnamen (localhost z.B.) port 8080 
    // das / für alle pfade
    public HttpRestServer(int port = 8080)
    {
        _listener = new HttpListener();
        _listener.Prefixes.Add($"http://+:{port}/");
    }

    public bool Running { get; private set; }
    
    // man kann methoden auf dieses event hängen
    public event Action<HttpListenerContext>? RequestReceived;

    public void Run()
    {
        if (Running) return;

        _listener.Start();
        Running = true;

        Console.WriteLine("Server running...");

        while (Running)
        {
            // context objekt mit allen infos von der request
            var context = _listener.GetContext();
            
            // async request handling, task damit der server nicht blockt
            _ = Task.Run(() =>
            {
                //ruft alle registrierten methods auf mit dem context, wenn eine neue request da ist
                RequestReceived?.Invoke(context);
            });
        }
    }

    // resourcen freigeben
    public void Dispose()
    {
        _listener.Stop();
        _listener.Close();
    }
}