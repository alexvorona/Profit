using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace UdpLibrary
{
    public class StatData
    {
        public double D { get; set; }
        public double SD { get; set; }
        public double Median { get; set; }
        public double Mode { get; set; }

        public StatData(double d, double sd, double median, double mode)
        {
            D = d;
            SD = sd;
            Median = median;
            Mode = mode;
        }
    }
}
