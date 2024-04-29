using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TcpPeerToPeerChat_CLI.Network;

namespace TcpPeerToPeerChat_CLI.Tcp
{
    // PassiveSocketMessageService - сервис для взаимодействия в пассивном режиме
    public class PassiveSocketMessageService : IHostMessageService
    {
        private Socket server;
        private Socket client;
        public ISender Sender { get; private set; }

        public IReceiver Receiver { get; private set; }

        public string CurrentEndpointStr { get; private set; }
        public string RemoteEndpointStr { get; private set; }

        public PassiveSocketMessageService(string serverIpPortStr)
        {            
            string[] strsData = serverIpPortStr.Split(':');
            string serverIpStr = strsData[0];
            int serverPort = Convert.ToInt32(strsData[1]);
            
            server = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.IP
            );            
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Parse(serverIpStr), serverPort);
            
            server.Bind(serverEndpoint);
            server.Listen(1);            
            CurrentEndpointStr = serverIpPortStr;
        }
        public void EstablishConnection()
        {
            client = server.Accept(); //сервер начнет ждать входящее подключение
            RemoteEndpointStr = client.RemoteEndPoint.ToString();
            Sender = new SocketSender(client, 1024);
            Receiver = new SocketReceiver(client, 1024);
        }

        public void ShutdownConnection()
        {
            client.Shutdown(SocketShutdown.Both);   // завершить общение в 2 стороны            
        }

        public void Dispose()
        {
            server.Dispose();
            client.Dispose();
        }
    }
}
