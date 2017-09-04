using System;
using UdpLibrary;

namespace ConsoleServer
{
    public class UdpServer
    {
        private static SettingsLoader _settingsLoader = new SettingsLoader();
        private static CustomSettings _settings;
        private static DatagramSender _datagramSender;
        private static DatagramGenerator _datagramGenerator;

        public UdpServer()
        {
            _settings = _settingsLoader.ReadXml();
            _datagramGenerator = new DatagramGenerator(_settings.DiapasonMin, _settings.DiapasonMax);
            _datagramSender = new DatagramSender(_settings, _datagramGenerator);
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Diapason: Min {_settings.DiapasonMin}, Max {_settings.DiapasonMax} ");
            Console.WriteLine($" IP {_settings.IPAddress}, Port {_settings.Port} ");
        }

        public void Start()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("->Press Enter to start");
            Console.ReadLine();
            _datagramSender.SendMessages();
        }
    }
}