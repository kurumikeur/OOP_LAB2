// See https://aka.ms/new-console-template for more information
using ServerApp;


Server1 newServ = new();
newServ.Start();
await newServ.Receive();