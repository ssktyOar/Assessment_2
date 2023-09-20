using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Server
{
    internal class NetworkClient
    {
        TcpClient server;
        NetworkStream stream;

        // @"192.168.1.72";
        private readonly string serverIP = "127.0.0.1";

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public NetworkClient()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
            if (File.Exists("IP.txt"))
            {
                serverIP = File.ReadAllText("IP.txt");
                Console.WriteLine(serverIP);
            }
        }

        internal void Start()
        {
            try
            {
                server = new(serverIP, 7000);
                stream = server.GetStream();
                stream.Write(BitConverter.GetBytes(1f));
                stream.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when connecting to server");
                Console.WriteLine("Current exception type: " + e.GetType().Name);
                Console.WriteLine("Exception full type: " + e.GetType().FullName);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.HelpLink);
                Console.WriteLine(e.Source);
            }
        }

        internal bool ReadData(ref byte[] data)
        {
            try
            {
                if (stream.DataAvailable)
                {
                    stream.Read(data, 0, data.Length);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when reading data");
                Console.WriteLine("Current exception type: " + e.GetType().Name);
                Console.WriteLine("Exception full type: " + e.GetType().FullName);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.HelpLink);
                Console.WriteLine(e.Source);
            }
            return false;
        }
    }
}
