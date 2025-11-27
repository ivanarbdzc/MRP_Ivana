using MRP.Server;
using MRP.Controllers;

var userController = new UserController();
var router = new Router(userController);
var server = new HttpRestServer(8080);

server.RequestReceived += router.Handle;

server.Run();