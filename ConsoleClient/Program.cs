using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UdpLibrary;

namespace ConsoleClient
{
    class Program
    {
        private static UdpClient _client;

        static void Main(string[] args)
        {
            try
            {
                _client = new UdpClient();

                Thread receiveThread = new Thread(_client.Start);
                receiveThread.Start();

                Thread workThread = new Thread(_client.ShowStatistic);
                workThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }      
      
       
      
    }
}