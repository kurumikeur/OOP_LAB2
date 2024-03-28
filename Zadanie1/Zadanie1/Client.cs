using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientApp
{
    public class Client
    {
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public async Task Connect(string destination)
        {
            Stopwatch timer = new Stopwatch();
            try
            {
                timer.Start();
                await client.ConnectAsync(destination, 8888);
                timer.Stop();
                Console.WriteLine("Connected in: {0} ms", timer.Elapsed.Milliseconds);
            }
            catch (SocketException)
            {
                Console.WriteLine("Connection failed");
            }

        }
        public async Task SendRequest(string destination, string msg)
        {
            Stopwatch timer = new Stopwatch();
            var data = Encoding.UTF8.GetBytes(msg);
            await client.SendAsync(data);
            Console.WriteLine("Message sent: " + msg);
        }
    }
}
