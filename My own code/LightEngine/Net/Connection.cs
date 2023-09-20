using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace LightEngine.Net
{
    public static class Connection
    {
        public static TcpListener StartListen(int port)
        {
            TcpListener tcpListener = new(IPAddress.Any, port);
            tcpListener.Start();
            return tcpListener;
        }
    }
}
