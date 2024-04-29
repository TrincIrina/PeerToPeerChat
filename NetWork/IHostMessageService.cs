using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpPeerToPeerChat_CLI.Network
{
    // IHostMessageService - интерфейс объекта для общения по сети
    public interface IHostMessageService : IDisposable
    {
        // EstablishConnection - установить соединение
        void EstablishConnection();

        // ShutdownConnection - разорвать соединение
        void ShutdownConnection();

        // Свойства для получения объектов для отправки/получения сообщений
        ISender Sender { get; }
        IReceiver Receiver { get; }

        // 
        string CurrentEndpointStr { get; }
        string RemoteEndpointStr { get; }
    }
}
