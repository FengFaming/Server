using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// 返回状态
    /// </summary>
    public enum BackStage
    {
        Success,
        Failure,
        UnKnown
    }

    public class SocketClient
    {
        /// <summary>
        /// 用户名
        /// </summary>
        protected string m_UserName;

        /// <summary>
        /// 协议链
        /// </summary>
        protected Socket m_ClientSocket;

        /// <summary>
        /// 数据链
        /// </summary>
        protected string[] m_Data;

        protected string m_BackMessage;

        public SocketClient(Socket socket, string[] data)
        {
            this.m_UserName = string.Empty;
            m_ClientSocket = socket;
            m_Data = data;
            m_BackMessage = string.Empty;

            AnalyzeMessage();
            AssemblyMessage();
            SendClient();
        }

        /// <summary>
        /// 分析消息
        /// </summary>
        /// <returns></returns>
        protected virtual bool AnalyzeMessage()
        {
            if (m_Data.Length <= 0)
                return false;

            return true;
        }

        /// <summary>
        /// 组合返回消息
        /// </summary>
        /// <returns></returns>
        protected virtual bool AssemblyMessage()
        {
            if (m_Data.Length <= 0)
                return false;

            return true;
        }

        /// <summary>
        /// 下发消息
        /// </summary>
        /// <returns></returns>
        private bool SendClient()
        {
            if (m_ClientSocket == null)
                return false;

            Console.WriteLine("下发消息 : " + m_BackMessage);
            m_ClientSocket.Send(Encoding.UTF8.GetBytes(m_BackMessage));
            return true;
        }

        /// <summary>
        /// 关闭协议链
        /// </summary>
        /// <returns></returns>
        protected virtual bool CloseClient()
        {
            return false;
        }
    }
}
