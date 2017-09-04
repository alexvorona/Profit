using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UdpLibrary;

namespace ConsoleServer
{
    class Program
    {
        private static UdpServer _server;
        static void Main(string[] args)
        {
            try
            {
                _server = new UdpServer();
                Thread thread = new Thread(_server.Start);
                thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}