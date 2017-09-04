using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UdpLibrary
{
    public class CustomSettings
    {
        [NonSerialized]
        public String XMLFileName = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("ClassLibrary.dll", "") + "settings.xml";
        
        public int DiapasonMin = 0;
        public int DiapasonMax = 100;

        public string IPAddress = "224.0.0.0"; 
        public int Port = 8001; 
    }
}
