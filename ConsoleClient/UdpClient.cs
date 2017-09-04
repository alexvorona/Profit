using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdpLibrary;

namespace ConsoleClient
{
    public class UdpClient
    {
        private static SettingsLoader _settingsLoader = new SettingsLoader();
        private static CustomSettings _settings;
        private static DatagramReceiver _datagramReceiver;
        private static DatagramCollector _datagramCollector;

        public UdpClient()
        {
            _settings = _settingsLoader.ReadXml();
            _datagramCollector = new DatagramCollector();
            _datagramReceiver = new DatagramReceiver(_settings, _datagramCollector);
            Console.WriteLine("-----------------------------");
            Console.WriteLine($" IP {_settings.IPAddress}, Port {_settings.Port} ");
        }

        public void ShowStatistic()
        {
            while (true)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("->Press Enter (for statistic)");
                Console.ReadLine();

                Console.WriteLine($"Total : {_datagramCollector.Total}");
                Console.WriteLine($"Lost : {_datagramCollector.Lost}");

                Console.WriteLine("---->1-st version");
                var t1 = DateTime.Now;
                StatData stat = _datagramCollector.CalculateStatistic();
                var t2 = DateTime.Now;
                Console.WriteLine($"D : {stat.D}");
                Console.WriteLine($"SD : {stat.SD}");
                Console.WriteLine($"Median : {stat.Median}");
                Console.WriteLine($"Mode : {stat.Mode}");
                Console.WriteLine($"Time : {t2 - t1}");

                Console.WriteLine("---->2-st version");
                var t3 = DateTime.Now;
                
                StatData statO = _datagramCollector.CalculateOStatistic();
                var t4 = DateTime.Now;
                Console.WriteLine($"D : {statO.D}");
                Console.WriteLine($"SD : {statO.SD}");
                Console.WriteLine($"Median : {statO.Median}");
                Console.WriteLine($"Mode : {statO.Mode}");
                Console.WriteLine($"Time : {t4 - t3}");
            }
        }

        public void Start()
        {
            _datagramReceiver.ReceiveMessage();
        }
    }
}
