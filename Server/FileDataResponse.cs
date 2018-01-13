using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class FileDataResponse : SocketClient
    {
        public FileDataResponse(Socket client, string[] data) : base(client, data)
        {

        }

        protected override bool AssemblyMessage()
        {
            if (!base.AssemblyMessage())
            {
                return false;
            }

            string filePath = @"../../test.txt";
            FileThread file = new FileThread();
            string str = file.GetFileString(filePath);

            m_BackMessage = "File ";
            m_BackMessage += "test.txt ";
            m_BackMessage += str;

            return true;
        }
    }
}
