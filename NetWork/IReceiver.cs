using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpPeerToPeerChat_CLI.Network
{
    // IReceiver - интерфейс получения сообщений
    public interface IReceiver : IDisposable
    {
        // Receive - получить сообщение
        string Receive();
    }
}
