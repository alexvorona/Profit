using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UdpLibrary
{
    public class DatagramCollector
    {
        private long _receivedCount;
        private long _lastNum;
        private KeyValuePair<int, long>[] _array; // histogramm
        private Statistic stat;
        private StatisticOpt statO;

        ConcurrentDictionary<int, long> _numDictionary = new ConcurrentDictionary<int, long>();
        public DatagramCollector()
        {
            _receivedCount = 0;            
        }

        public void Add(Datagram datagram)
        {
            _receivedCount++;
            _lastNum = datagram.Id;
           _numDictionary.AddOrUpdate(datagram.Num, 1, (key, oldValue) => oldValue + 1);

        }
        
        public long Total
        {
            get
            {
                return _lastNum;
            }
        }
        public long Lost
        {
            get
            {
                return _lastNum - _receivedCount;
            }
        }

        public StatData CalculateStatistic()
        {
            _array = _numDictionary.ToArray();
            stat = new Statistic(_array);
            double d = stat.D();
            double sd = stat.SD();
            double median = stat.Median();
            double mode = stat.Mode();
            return new StatData(d,sd,median,mode);
        }

        public StatData CalculateOStatistic()
        {
           // var array = _numDictionary.ToArray();
            statO = new StatisticOpt(_array);
            double d = statO.D();
            double sd = statO.SD();
            double median = statO.Median();
            double mode = statO.Mode();
            return new StatData(d, sd, median, mode);
        }
    }
}
