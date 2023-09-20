using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;

public class ServerSender : MonoBehaviour
{
    private readonly byte[] codeBytes = BitConverter.GetBytes(4689057803456780);
    readonly TcpListener tcpListener = new(IPAddress.Any, 7000);
    private readonly Dictionary<long, Player> players = new();
    private readonly Dictionary<long, SyncObject> objects = new();
    private readonly List<byte> info = new();
    private byte[] data;
    private long currentID;
    private byte[] locDat;
    private int length;
    readonly List<Task> tasks = new();

    // Start is called before the first frame update
    void Start()
    {
        tcpListener.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        foreach(SyncObject s in objects.Values)
        {
            info.AddRange(s.GetInfo());
        }
        Task.WaitAll(tasks.ToArray());
        tasks.Clear();
        data = info.ToArray();
        foreach(Player player in players.Values)
        {
            tasks.Add(Task.Run(() => SendMessage(player)));
        }

        Player p;
        Task.WaitAll(tasks.ToArray());
        tasks.Clear();
        while (tcpListener.Pending())
        {
            try
            {
                p = new(tcpListener.AcceptTcpClient());
                while (players.ContainsKey(currentID))
                {
                    currentID++;
                }
                players.Add(currentID, p);
                p.stream.Write(BitConverter.GetBytes(currentID));
                p.stream.Flush();
                currentID++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.HelpLink);
                Console.WriteLine(e.HResult);
            }
        }
    }

    private void SendMessage(Player player)
    {
        try
        {
            if (player.stream.DataAvailable)
            {
                player.data = new byte[10000];
                player.stream.Read(player.data, 0, 10000);
            }
            player.stream.Write(data);
            player.stream.Flush();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            Console.WriteLine(e.Source);
            Console.WriteLine(e.HelpLink);
            Console.WriteLine(e.HResult);
        }
    }

    internal byte[] GetKey()
    {
        return codeBytes;
    }

    internal void ApplyInfo(byte[] data)
    {
        lock (info)
        {
            info.AddRange(data);
        }
    }
}
