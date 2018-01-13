using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class LoadResponse : SocketClient
    {
        public LoadResponse(Socket client, string[] data) : base(client, data)
        {

        }

        protected override bool AssemblyMessage()
        {
            if (!base.AssemblyMessage())
            {
                return false;
            }

            m_BackMessage = "RequestLogin fenge ";
            m_BackMessage += m_Data[1];
            m_BackMessage += " ";
            m_BackMessage += "Ending";

            return true;
        }
    }
}
