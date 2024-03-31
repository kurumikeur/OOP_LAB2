using ServerApp;
using ClientApp;


Client newClient = new();
await newClient.Connect(Server1.IP);
await newClient.SendRequest(Server1.IP, "abasdxas");
Console.ReadLine();


