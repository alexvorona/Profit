using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpLibrary
{
    public class DatagramSender
    {
        protected static CustomSettings _settings;
        private DatagramGenerator _datagramGenerator;
        public DatagramSender(CustomSettings settings, DatagramGenerator datagramGenerator )
        {
            _settings = settings;
            _datagramGenerator = datagramGenerator;
        }

        public void SendMessages()
        {
            UdpClient sender = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(_settings.IPAddress), _settings.Port);
            
            try
            {
                while (true)
                {
                    string message = _datagramGenerator.Next().ToString();
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    sender.Send(data, data.Length, endPoint);
                    Console.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sender.Close();
            }
        }
    }
}