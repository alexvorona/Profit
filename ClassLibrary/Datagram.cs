using System;

namespace UdpLibrary
{
    public class Datagram
    {
        private char _separator = ':';
        private long _id;
        private int _num;

        public long Id => _id;
        public int Num => _num;
        public Datagram(long id, int num)
        {
            _id = id;
            _num = num;
        }
        public Datagram(string str)
        {
            string[] words = str.Split(_separator);
            _id = Int64.Parse(words[0]);
            _num = Int32.Parse(words[1]);            
        }

        public override string ToString()
        {
            return $"{_id}{_separator}{_num}";
        }
    }
}
