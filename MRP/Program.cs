using System.Net;
using MRP.Controllers;
using MRP.Server;

// //kurzes test program.cs um zu sehen ob der server funktioniert bisher
// var server = new HttpRestServer();
//
// server.RequestReceived += (HttpListenerContext ctx) =>
// {
//     string message = "Hello World!";
//     byte[] buffer = System.Text.Encoding.UTF8.GetBytes(message);
//     
//     ctx.Response.StatusCode = 200;
//     ctx.Response.ContentType = "text/plain";
//     ctx.Response.OutputStream.Write(buffer, 0, buffer.Length);
//     ctx.Response.Close();
//
// };

var userController = new UserController();
var router = new Router(userController);
var server = new HttpRestServer();

server.RequestReceived += router.Handle;

server.Run();