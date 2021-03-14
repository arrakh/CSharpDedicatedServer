using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    //It's important to read the packet in the same order as server
    public static void Welcome(Packet packet)
    {
        string msg = packet.ReadString();
        int myId = packet.ReadInt();

        Debug.Log("Server messaged: " + msg);
        Client.Instance.myId = myId;

        ClientSend.WelcomeReceived();
    }
}
