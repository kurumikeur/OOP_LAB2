using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApp
{
    public abstract class Server
    {
        public static string IP;
        protected IPEndPoint ipPoint;
        protected Socket socket;

        public abstract void Start();
        public abstract Task Receive();
        public abstract string GetIP();
        public abstract void Close();
    }
    public class Server1 : Server
    {
        public static new string IP = "127.0.0.1";
        protected new IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
        protected new Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        public override void Start()
        {
            socket.Bind(ipPoint);
            Console.WriteLine("Server started");
        }
        public override async Task Receive()
        {
            socket.Listen();
            var listener = socket.Accept();
            while (true)
            {
                var data = new byte[1024];
                int bytes =  listener.Receive(data);
                StringBuilder msg = new();
                do
                {
                    msg.Append(Encoding.UTF8.GetString(data, 0 , bytes));
                } while (listener.Available > 0);
                //Изменение полученного сообщения и отправка обратно на клиент
                Console.WriteLine($"[Server 1] Received message: {msg}");
                msg.Append(listener.GetHashCode().ToString());
                msg.Append(" [Server 1]");
                listener.Send(Encoding.UTF8.GetBytes(msg.ToString()));
                Console.WriteLine(msg.ToString());
            }
        }
        public override void Close() {
            socket.Dispose();
        }
        public override string GetIP() { return IP; }
    }
    //public class Server2 : Server
    //{
    //    public static new string IP = "127.0.0.2";
    //    protected new IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(IP), 8888);
    //    protected new Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    //    public override void Start()
    //    {
    //        socket.Bind(ipPoint);
    //        Console.WriteLine("Server started");
    //    }
    //    public override async Task Receive()
    //    {
    //        var data = new byte[1024];
    //        var listener =  socket.AcceptAsync();
    //        listener.Receive(data);
    //        StringBuilder msg = new();
    //        do
    //        {
    //            msg.Append(Encoding.UTF8.GetString(data));
    //        } while (listener.Available > 0);
    //        Console.WriteLine($"[Server 2] Received message: {msg}");
    //    }
    //    public override void Close()
    //    {
    //        socket.Dispose();
    //    }
    //    public override string GetIP() { return IP; }
    //}

    //public class Server3 : Server
    //{
    //    public static new string IP = "127.0.0.3";
    //    protected new IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(IP), 8888);
    //    protected new Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    //    public override void Start()
    //    {
    //        socket.Bind(ipPoint);
    //        Console.WriteLine("Server started");
    //    }
    //    public override async Task Receive()
    //    {
    //        var data = new byte[1024];
    //        var listener =  socket.AcceptAsync();
    //        listener.Receive(data);
    //        StringBuilder msg = new();
    //        do
    //        {
    //            msg.Append(Encoding.UTF8.GetString(data));
    //        } while (listener.Available > 0);
    //        Console.WriteLine($"[Server 3] Received message: {msg}");
    //    }
    //    public override void Close()
    //    {
    //        socket.Dispose();
    //    }
    //    public override string GetIP() { return IP; }
    //}
}
