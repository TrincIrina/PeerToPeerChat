using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpPeerToPeerChat_CLI.Network
{
    // ISender - интерфейс отправки сообщений
    public interface ISender : IDisposable
    {
        // Send - метод отправки сообщение
        void Send(string message);
    }
}
