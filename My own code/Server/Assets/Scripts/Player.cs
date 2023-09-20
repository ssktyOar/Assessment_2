using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Player : MonoBehaviour
{
    internal TcpClient tcpClient;
    internal NetworkStream stream;
    
    public Player(TcpClient client)
    {
        tcpClient = client;
        stream = tcpClient.GetStream();
    }
    internal byte[] data;

    internal void AcceptInfo(ref byte[] data)
    {

    }
}
