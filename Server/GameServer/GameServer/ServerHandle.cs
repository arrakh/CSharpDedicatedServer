using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
    class ServerHandle
    {
        public static void WelcomeReceived(int fromClient, Packet packet)
        {
            int clientID = packet.ReadInt();
            string username = packet.ReadString();

            Console.WriteLine(Server.clients[fromClient].tcp.socket.Client.RemoteEndPoint + " Connected Successfully with username " + username);
            if (fromClient != clientID) Console.WriteLine($"ID {fromClient} has assumed the wrong client ID {clientID}");
            //Should send player to game
        }
    }
}
