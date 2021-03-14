using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
    class ServerSend
    {
        private static void SendTCPData(int toClientID, Packet packet)
        {
            packet.WriteLength();
            Server.clients[toClientID].tcp.SendData(packet);
        }

        private static void SendTCPDataToAll(Packet packet)
        {
            packet.WriteLength();
            for (int i = 0; i < Server.MaxPlayers; i++)
            {
                Server.clients[i].tcp.SendData(packet);
            }
        }

        private static void SendTCPDataToAll(int exceptClient, Packet packet)
        {
            packet.WriteLength();
            for (int i = 0; i < Server.MaxPlayers; i++)
            {
                if (i != exceptClient) Server.clients[i].tcp.SendData(packet);
            }
        }

        public static void Welcome(int toClientID, string msg)
        {
            using (Packet packet = new Packet((int)ServerPackets.welcome))
            {
                packet.Write(msg);
                packet.Write(toClientID);

                SendTCPData(toClientID, packet);
            }
        }
    }
}
