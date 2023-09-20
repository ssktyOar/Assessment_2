using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using UnityEngine;

public class ClientAccepter : MonoBehaviour
{
    TcpClient server;
    NetworkStream stream;
    private string serverIP = @"192.168.1.72";
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists("IP.txt"))
        {
            serverIP = File.ReadAllText("IP.txt");
            Debug.Log(serverIP);
        }
        server = new(serverIP, 7000);
        stream = server.GetStream();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
