using ServerApp;
using ClientApp;
using System.Diagnostics;

Stopwatch timer = new();
timer.Start();
Client newClient = new();
newClient.Connect(Server1.IP);
newClient.SendRequest(Server1.IP, "abasdxas");
newClient.SendRequest(Server1.IP, "..32189x\\/");
newClient.SendRequest(Server1.IP, "xdsa2");
newClient.SendRequest(Server1.IP, ":3:3:3");
timer.Stop();
Console.WriteLine($"Completed in: {timer.ElapsedMilliseconds} ms");
Console.ReadLine();

