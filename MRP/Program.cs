using MRP.Server;
using MRP.Controllers;

var userController = new UserController();
var mediaController = new MediaController();
var ratingController = new RatingController();
var leaderboardController = new LeaderboardController();

var router = new Router(userController, mediaController, ratingController, leaderboardController);
var server = new HttpRestServer(8080);

server.RequestReceived += router.Handle;

server.Run();