using Lidgren.Network;
using Newtonsoft.Json;
using System;
using System.Threading;

namespace DrawBattles.Network
{
    public class AsyncClient
    {
        private NetClient _client;

        public event Action ClientConnected;
        public event Action ClientDisconected;
        public event Action<string> DataReceived;


        private Thread mainThread;

        public AsyncClient()
        {
            var config = new NetPeerConfiguration("CrazyRaid");
            _client = new NetClient(config);
            _client.Start();
        }

        public void Send(byte[] data)
        {
            NetOutgoingMessage msg = _client.CreateMessage();
            msg.Write(data);
            _client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
        }
        public void Send(string data)
        {
            NetOutgoingMessage msg = _client.CreateMessage();
            msg.Write(data);
            _client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
        }

        public void Send(Request request)
        {
            NetOutgoingMessage msg = _client.CreateMessage();
            msg.Write(JsonConvert.SerializeObject(request));
            _client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
        }

        public void Connect(string address, int port, string clientKey)
        {
            var netConnection = _client.Connect(address, port, _client.CreateMessage(clientKey));
            if (netConnection != null)
            {
                ClientConnected?.Invoke();
            }
            mainThread = new Thread(new ThreadStart(ThreadMethod));
            mainThread.Start();
        }

        public void ThreadMethod()
        {
            while (mainThread.IsAlive)
            {
                ProcessMessages();
            }
        }

        public void Disconnect(string message = "bye")
        {
            _client.Disconnect("bye");
            ClientDisconected?.Invoke();
            mainThread.Abort();
        }

        
        public void ProcessMessages()
        {
            NetIncomingMessage message;
            while ((message = _client.ReadMessage()) != null)
            {
                switch (message.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        DataReceived?.Invoke(message.ReadString());
                        break;
                    
                }
                _client.Recycle(message);
            }
        }
        
    }
}
