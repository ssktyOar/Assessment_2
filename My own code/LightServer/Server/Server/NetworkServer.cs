using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server.Server
{
    internal class NetworkServer
    {
        private readonly TcpListener server;

        private readonly Dictionary<long, Player> clients = new();

        private long id = 0;

        public NetworkServer(int port)
        {
            server = new(IPAddress.Any, port);
        }

        public void Start()
        {
            server.Start();
        }

        public void TryAccept()
        {
            TcpClient tcpClient;
            while (server.Pending())
            {
                while (clients.ContainsKey(id))
                {
                    id++;
                }
                tcpClient = server.AcceptTcpClient();
                lock (clients)
                {
                    clients.Add(id, new(id, tcpClient, tcpClient.GetStream()));
                }
                id++;
            }
        }


        public void SendState(long playerID, byte[] data)
        {
            if(clients.TryGetValue(playerID, out var client))
            {
                try
                {
                    client.stream.Write(data);
                    client.stream.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error when sending a message");
                    Console.WriteLine("Client ID: " + client.id.ToString());
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(e.HelpLink);
                    Console.WriteLine(e.Source);
                    // clients.Remove(playerID);
                }
            }
        }

        public void SendState(long[] playerIDs, byte[] data)
        {
            Task[] tasks = new Task[playerIDs.Length];
            for(int i = 0; i < playerIDs.Length; i++)
            {
                tasks[i] = Task.Run(() => 
                {
                    if (clients.TryGetValue(playerIDs[i], out var client))
                    {
                        try
                        {
                            client.stream.Write(data);
                            client.stream.Flush();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error when sending a message");
                            Console.WriteLine("Client ID: " + client.id.ToString());
                            Console.WriteLine(e.Message);
                            Console.WriteLine(e.StackTrace);
                            Console.WriteLine(e.HelpLink);
                            Console.WriteLine(e.Source);
                            // clients.Remove(playerIDs[i]);
                        }
                    }
                });
            }
            Task.WaitAll(tasks);
        }

        public bool TryReadMessage(long playerID, ref byte[] data, int count, int offset)
        {
            if (clients.TryGetValue(playerID, out var client))
            {
                try
                {
                    if (client.stream.DataAvailable)
                    {
                        client.stream.Read(data, offset, count);
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error when sending a message");
                    Console.WriteLine("Client ID: " + client.id.ToString());
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(e.HelpLink);
                    Console.WriteLine(e.Source);
                    // clients.Remove(playerID);
                }
            }
            return false;
        }

        public void Clean()
        {
            lock (clients)
            {
                foreach (var client in clients)
                {
                    try
                    {
                        if (!client.Value.client.Connected)
                        {
                            clients.Remove(client.Key);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error when deleting a player");
                        Console.WriteLine("Client ID: " + client.Value.id.ToString());
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                        Console.WriteLine(e.HelpLink);
                        Console.WriteLine(e.Source);
                        clients.Remove(client.Key);
                    }
                }
            }
        }
    }

    class Player
    {
        internal readonly long id;
        internal readonly TcpClient client;
        internal readonly NetworkStream stream;
        // internal short time;  

        public Player(long id, TcpClient client, NetworkStream stream)
        {
            this.id = id;
            this.client = client;
            this.stream = stream;
        }
    }
}
