using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace ClientApp
{
    public class Client
    {
        static Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public async Task SendRequest(string destination)
        {
            Stopwatch timer = new Stopwatch();
            try
            {
                timer.Start();
                await client.ConnectAsync(destination, 8888);
                timer.Stop();
                Console.WriteLine("Got response in: {0} ms", timer.Elapsed.Milliseconds);
            }
            catch (SocketException)
            {
                Console.WriteLine("Connection failed");
            }

        }

    }
    record Data(string Name, int age);
}
