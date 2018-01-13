using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ClientManager
    {
        private Socket m_Client;
        private Thread m_Thread;
        private byte[] m_Data;

        public ClientManager(Socket socket)
        {
            m_Client = socket;
            m_Thread = new Thread(ReceiveMessage);
            m_Data = new byte[2048];
            m_Thread.Start();
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    int bytes = m_Client.Receive(m_Data);
                    string s = Encoding.UTF8.GetString(m_Data, 0, bytes);
                    Console.WriteLine(s);
                    string[] p = s.Split(' ');
                    if (p.Length > 0)
                    {
                        switch (p[0])
                        {
                            case "RequestLogin":
                                new LoadResponse(m_Client, p);
                                break;
                            case "Test":
                                new TestResponse(m_Client, p);
                                break;
                            case "File":
                                new FileDataResponse(m_Client, p);
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    CloseClient();
                }
            }
        }

        private void CloseClient()
        {
            Console.WriteLine("Close");
            ServerThread.Instance.RemoveClient(this);
            m_Client = null;
            m_Thread.Abort();
        }
    }
}
