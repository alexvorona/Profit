using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpLibrary
{
    public class Statistic
    {
        private readonly KeyValuePair<int, long>[] _array; // histogramm
        private double _mean;
        private long _n;

        public Statistic(KeyValuePair<int, long>[] array)
        {
            _array = array;
            _n = _array.Sum(k => k.Value);
            var sum = _array.Sum(k => k.Value*k.Key);
            _mean = _n == 0 ? 0 : sum / _n;
        }

        public double D()
        {
            double d = 0;                      
            for (int i = 0; i < _array.Length; i++)
            {
                d += _array[i].Value * (_array[i].Key - _mean);
            }
            d = _n==0 ? 0 : d / _n;
            return d;
        }

        public double SD()
        {
            double sd = 0;                        
            for (int i = 0; i < _array.Length; i++)
            {
                double k = _array[i].Key - _mean;
                sd += _array[i].Value * k * k;
            }
            sd = Math.Sqrt(sd / (_n - 1));
            return sd;
        }

        public double Median()
        {
            double median = 0;
            long sum = 0;
            long half = _n / 2;

            var query = _array.OrderBy(k => k.Key);
            foreach (var kv in query)
            {
                median = kv.Key;
                sum += kv.Value;
                if (sum > half)
                    break;
            }

            return median;
        }

        public long Mode()
        {           
            return _array.OrderByDescending(k => k.Value).
                                Select(g => g.Key).FirstOrDefault();
        }
    }
}

public class StatisticOpt
{
    private readonly KeyValuePair<int, long>[] _array; // histogramm
    private double _mean;
    private long _n;

    public StatisticOpt(KeyValuePair<int, long>[] array)
    {
        _array = array;
        _n = _array.AsParallel().Sum(k => k.Value);
        var sum = _array.AsParallel().Sum(k => k.Value * k.Key);
        _mean = _n == 0 ? 0 : sum / _n;
    }

    public double D()
    {
        double d = _array.AsParallel().Sum(k => k.Value * (k.Key - _mean));       
        d = _n == 0 ? 0 : d / _n;
        return d;
    }

    public double SD()
    {
        double sd =  _array.AsParallel().Sum(k => k.Value * Math.Pow(k.Key - _mean, 2));
        sd = Math.Sqrt(sd / (_n - 1));
        return sd;
    }

    public double Median()
    {
        double median = 0;
        long sum = 0;
        long half = _n / 2;

        var query = _array.OrderBy(k => k.Key);
        foreach (var kv in query)
        {
            median = kv.Key;
            sum += kv.Value;
            if (sum > half)
                break;
        }

        return median;
    }

    public long Mode()
    {
        if (_array.Length == 0) return 0;
        var max = _array.Max(k => k.Value);
        return _array.Where(k => k.Value == max).Select(g => g.Key).FirstOrDefault();
    }
}
