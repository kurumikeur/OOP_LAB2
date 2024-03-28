using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApp
{
    public abstract class Server
    {
        public static string IP;
        protected IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(IP), 8888);
        protected Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public virtual void Start()
        {
            socket.Bind(ipPoint);
            Console.WriteLine("Server started");
        }
        public abstract Task Receive();
        public virtual string GetIP() { return IP; }
    }
    public class Server1 : Server
    {
        public static new string IP = "127.0.0.1";
        public override async Task Receive()
        {
            socket.Listen();
            
            while (true) 
            {
                var data = new byte[1024];
                var listener = await socket.AcceptAsync();
                listener.Receive(data);
                StringBuilder msg = new();
                do
                {
                    msg.Append(Encoding.UTF8.GetString(data));
                } while (listener.Available > 0);
                Console.WriteLine($"[Server 1] Received message: {msg}");
            }
        }
    }
    public class Server2 : Server
    {
        public static new string IP = "127.0.0.2";

        public override async Task Receive()
        {
            var data = new byte[1024];
            var listener = await socket.AcceptAsync();
            listener.Receive(data);
            StringBuilder msg = new();
            do
            {
                msg.Append(Encoding.UTF8.GetString(data));
            } while (listener.Available > 0);
            Console.WriteLine($"[Server 2] Received message: {msg}");
        }
    }

    public class Server3 : Server
    {
        public static new string IP = "127.0.0.3";

        public override async Task Receive()
        {
            var data = new byte[1024];
            var listener = await socket.AcceptAsync();
            listener.Receive(data);
            StringBuilder msg = new();
            do
            {
                msg.Append(Encoding.UTF8.GetString(data));
            } while (listener.Available > 0);
            Console.WriteLine($"[Server 3] Received message: {msg}");
        }
    }
}
