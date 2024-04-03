using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientApp
{
    public class Client
    {
        public static string IP = "127.0.0.9";
        IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(IP), 8888);
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

        public void Connect(string destination)
        {
            Stopwatch timer = new Stopwatch();
            try
            {
                client.Connect(destination, 8888);
            }
            catch (SocketException)
            {
                Console.WriteLine("Connection failed");
            }

        }
        public void SendRequest(string destination, string msg)
        {
            Stopwatch timer = new Stopwatch();
            var data = Encoding.UTF8.GetBytes(msg);
            
            timer.Start();
            client.Send(data);
            Console.WriteLine("Message sent: " + msg);

            var buff = new byte[1024];
            client.Receive(buff);
            timer.Stop();
            Console.WriteLine("Message received: " + Encoding.UTF8.GetString(buff));
        }
    }
}
