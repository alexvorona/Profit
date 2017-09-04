using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpLibrary
{
    public class DatagramReceiver
    {
        protected static CustomSettings _settings;
        private DatagramCollector _datagramCollector;

        public DatagramReceiver(CustomSettings settings, DatagramCollector datagramCollector)
        {
            _settings = settings;
            _datagramCollector = datagramCollector;
        }

        public void ReceiveMessage()
        {
            UdpClient receiver = new UdpClient(_settings.Port);
            receiver.JoinMulticastGroup(IPAddress.Parse(_settings.IPAddress), 200);
            IPEndPoint remoteIp = null;

            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);
                    Datagram datagram = new Datagram(message);
                    _datagramCollector.Add(datagram);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                receiver.Close();
            }
        }
    }
}
