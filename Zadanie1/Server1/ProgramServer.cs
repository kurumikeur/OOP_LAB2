// See https://aka.ms/new-console-template for more information
using ServerApp;


Server1 newServ = new Server1();
newServ.Start();
await newServ.Receive();
newServ.Close();
