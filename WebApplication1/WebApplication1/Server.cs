using System.Net;
using System.Net.Sockets;

namespace ServerApp
{
    public class Server
    {
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public async void Start() 
        {  
            socket.Bind(ipPoint);
            socket.Listen();
            using Socket client = await socket.AcceptAsync();
        }
        public string GetIP()
        {
            return ipPoint.ToString();
        }
    }
}
