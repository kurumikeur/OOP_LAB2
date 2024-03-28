using ServerApp;
using ClientApp;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

Server newServ = new();
newServ.Start();
Client newClient = new();
newClient.SendRequest(newServ.GetIP());

app.Run();
