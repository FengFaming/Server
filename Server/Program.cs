using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        public static void Main(string[] args)
        {
            byte[] data = new byte[2048];
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpServer.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6789));
            tcpServer.Listen(100);

            ServerThread server = new ServerThread(tcpServer);
            server.Start();

            string filePath = @"../../test.txt";
            FileThread file = new FileThread();
            string str = file.GetFileString(filePath);
            Console.WriteLine(str);
        }
    }
}
