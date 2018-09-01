using Lidgren.Network;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace DrawBattles.Network
{
    public class AsyncServer
    {

        private NetServer _netServer;

        public event Action<string> ClientConnected;
        public event Action<string> ClientDisconected;
        public event Action<object, string> DataReceived;

        private Thread mainThread;

        public EndPoint EndPoint
        {
            get { return _netServer.Socket.LocalEndPoint; }
        }

        public AsyncServer(int port)
        {
            var config = new NetPeerConfiguration("CrazyRaid");
            config.Port = port;
            _netServer = new NetServer(config);
        }

        public void ThreadMethod()
        {
            while (mainThread.IsAlive)
            {
                ProcessMessages();
            }
        }

        public void Start()
        {
            _netServer.Start();
            mainThread = new Thread(new ThreadStart(ThreadMethod));
            mainThread.Start();
        }

        public void Stop()
        {
            mainThread.Abort();
            _netServer.Shutdown("bye");
        }

        public void Send(object client, string data)
        {
            NetConnection conn = (NetConnection)client;
            NetOutgoingMessage msg = _netServer.CreateMessage();
            msg.Write(data);
            _netServer.SendMessage(msg, conn, NetDeliveryMethod.ReliableOrdered);
        }

        public void Send(object client, Response data)
        {
            NetConnection conn = (NetConnection)client;
            NetOutgoingMessage msg = _netServer.CreateMessage();
            msg.Write(JsonConvert.SerializeObject(data));
            _netServer.SendMessage(msg, conn, NetDeliveryMethod.ReliableOrdered);
        }

        public void ProcessMessages()
        {
            NetIncomingMessage message;
            while ((message = _netServer.ReadMessage()) != null)
            {
                switch (message.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        var data = message.ReadString();
                        DataReceived?.Invoke(message.SenderConnection, data);
                        break;
                    case NetIncomingMessageType.StatusChanged:

                        switch (message.SenderConnection.Status)
                        {
                            case NetConnectionStatus.Connected:
                                ClientConnected?.Invoke(message.SenderConnection.RemoteHailMessage.ReadString());
                                break;
                            case NetConnectionStatus.Disconnected:
                                ClientDisconected?.Invoke(message.SenderConnection.RemoteHailMessage.ReadString());
                                break;
                        }
                        break;
                }
                _netServer.Recycle(message);
            }
        }

    }
}
