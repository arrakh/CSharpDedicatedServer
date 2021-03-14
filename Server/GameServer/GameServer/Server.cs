using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace GameServer
{
    class Server
    {
        public static int MaxPlayers { get; private set; }

        public static Dictionary<int, Client> clients = new Dictionary<int, Client>();

        public static int Port { get; private set; }

        private static TcpListener tcpListener;

        public static void Start(int maxPlayer, int port)
        {
            MaxPlayers = maxPlayer;
            Port = port;

            Console.WriteLine("Starting server on " + Port);
            InitializeServerData();

            tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);

            Console.WriteLine("Server Started!");
        }

        private static void TCPConnectCallback(IAsyncResult result)
        {
            TcpClient client = tcpListener.EndAcceptTcpClient(result);
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);

            Console.WriteLine("Incoming connection from " + client.Client.RemoteEndPoint);

            for (int i = 1; i <= MaxPlayers; i++)
            {
                if(clients[i].tcp.socket == null)
                {
                    clients[i].tcp.Connect(client);
                    return;
                }
            }

            Console.WriteLine(client.Client.RemoteEndPoint + " failed to connect: Server Failed");
        }

        private static void InitializeServerData()
        {
            for (int i = 1; i <= MaxPlayers; i++)
            {
                clients.Add(i, new Client(i));
            }
        }

    }
}
