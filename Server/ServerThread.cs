using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ServerThread
    {
        private Socket m_Server;
        private byte[] m_Data;
        private List<ClientManager> m_Clients;

        private static ServerThread m_Instance;
        public static ServerThread Instance { get { return m_Instance; } }

        public ServerThread(Socket server)
        {
            m_Server = server;
            m_Data = new byte[2048];
            m_Clients = new List<ClientManager>();
            m_Clients.Clear();

            m_Instance = this;
        }

        public void Start()
        {
            Thread t = new Thread(ReceiveMessage);
            t.Start();
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                Socket client = m_Server.Accept();
                ClientManager cm = new ClientManager(client);
                m_Clients.Add(cm);
            }
        }

        public void RemoveClient(ClientManager cm)
        {
            if (m_Clients.Contains(cm))
            {
                m_Clients.Remove(cm);
            }
        }
    }
}
