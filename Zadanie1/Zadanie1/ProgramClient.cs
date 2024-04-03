using ServerApp;
using ClientApp;
using System.Diagnostics;

Stopwatch timer = new();
timer.Start();
ClientAsync newClient = new();
await newClient.Connect(Server1.IP);
timer.Stop();
await newClient.SendRequest(Server1.IP, "abasdxas");
await newClient.SendRequest(Server1.IP, "..32189x\\/");
await newClient.SendRequest(Server1.IP, "xdsa2");
var t2 = await newClient.SendRequest(Server1.IP, ":3:3:3");
timer.Stop();
Console.WriteLine($"Completed in: {timer.ElapsedMilliseconds} ms");
Console.ReadLine();

