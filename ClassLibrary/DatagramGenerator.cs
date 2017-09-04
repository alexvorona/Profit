using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdpLibrary;

namespace UdpLibrary
{
    public class DatagramGenerator
    {
        private long _currentId;
        private int _minValue;
        private int _maxValue;

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public DatagramGenerator(int minValue, int maxValue)
        {
            _currentId = 0;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public Datagram Next()
        {
            _currentId++;
            int nval;
            lock (syncLock)
            {
                nval = random.Next(_minValue, _maxValue);
            }
            return new Datagram(_currentId, nval);
        }

    }
}
