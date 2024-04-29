using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TcpPeerToPeerChat_CLI.Network;

namespace TcpPeerToPeerChat_CLI.Tcp
{
    // SocketReceiver - реализация интерфейса получения сообщений через сокеты
    public class SocketReceiver : IReceiver
    {
        private Socket socket;
        private byte[] data;

        public SocketReceiver(Socket socket, int buffSize)
        {
            this.socket = socket;
            this.data = new byte[buffSize];
        }

        public void Dispose()
        {
            socket.Dispose();
        }

        public string Receive()
        {
            int buffRec = socket.Receive(data);
            return Encoding.UTF8.GetString(data, 0, buffRec);
        }
    }
}
