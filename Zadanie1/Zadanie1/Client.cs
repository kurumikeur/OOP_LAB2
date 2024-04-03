using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientApp
{
    public class ClientAsync
    {
        public static string IP = "127.0.0.9";
        IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(IP), 8888);
        Socket clientAsync = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

        public async Task Connect(string destination)
        {
            Stopwatch timer = new Stopwatch();
            try
            {
                await clientAsync.ConnectAsync(destination, 8888);
                Console.WriteLine("Connected in: {0} ms", timer.Elapsed.Milliseconds);
            }
            catch (SocketException)
            {
                Console.WriteLine("Connection failed");
            }

        }
        public async Task<bool> SendRequest(string destination, string msg)
        {
            Thread.Sleep(1000);
            var data = Encoding.UTF8.GetBytes(msg);
            await clientAsync.SendAsync(data);
            Console.WriteLine("Message sent: " + msg);
            var buff = new byte[1024];
            await clientAsync.ReceiveAsync(buff);
            Console.WriteLine("Message received: " + Encoding.UTF8.GetString(buff));
            return true;
        }
    }
}
