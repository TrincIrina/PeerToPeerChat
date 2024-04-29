using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TcpPeerToPeerChat_CLI.Network;

namespace TcpPeerToPeerChat_CLI.Tcp
{
    // ActiveSocketMessageService - сервис для взаимодействия в активном режиме
    public class ActiveSocketMessageService : IHostMessageService
    {
        private Socket client;
        IPEndPoint serverEndpoint;
        public ISender Sender { get; private set; }
        public IReceiver Receiver { get; private set; }

        public string CurrentEndpointStr { get; private set; }
        public string RemoteEndpointStr { get; private set; }

        public ActiveSocketMessageService(string serverIpPortStr)
        {
            string[] strsData = serverIpPortStr.Split(':');
            string serverIpStr = strsData[0];
            int serverPort = Convert.ToInt32(strsData[1]);
            
            client = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
            );            
            serverEndpoint = new IPEndPoint(IPAddress.Parse(serverIpStr), serverPort);
            RemoteEndpointStr = serverIpPortStr;
        }

        public void EstablishConnection()
        {
            client.Connect(serverEndpoint);
            CurrentEndpointStr = client.LocalEndPoint.ToString();
            Sender = new SocketSender(client, 1024);
            Receiver = new SocketReceiver(client, 1024);
        }

        public void ShutdownConnection()
        {
            client.Shutdown(SocketShutdown.Both);
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
