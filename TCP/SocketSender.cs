using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TcpPeerToPeerChat_CLI.Network;

namespace TcpPeerToPeerChat_CLI.Tcp
{
    // SocketSender - реализация интерфейса отправки сообщений через сокеты
    public class SocketSender : ISender
    {
        private Socket socket;
        private int buffSize;

        public SocketSender(Socket socket, int buffSize)
        {
            this.socket = socket;
            this.buffSize = buffSize;
        }

        public void Send(string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            if (messageBytes.Length > buffSize)
            {
                throw new InvalidOperationException("too long message");
            }
            socket.Send(messageBytes);
        }

        public void Dispose()
        {
            socket.Dispose();
        }

    }
}
