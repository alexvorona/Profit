using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UdpLibrary
{
    public class SettingsLoader
    {
        public CustomSettings Fields;

        public SettingsLoader()
        {
            Fields = new CustomSettings();
        }
        
        public void WriteXml()
        {
            XmlSerializer ser = new XmlSerializer(typeof(CustomSettings));
            TextWriter writer = new StreamWriter(Fields.XMLFileName);
            ser.Serialize(writer, Fields);
            writer.Close();
        }
        
        public CustomSettings ReadXml()
        {
            if (File.Exists(Fields.XMLFileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(CustomSettings));
                TextReader reader = new StreamReader(Fields.XMLFileName);

                try
                {
                    Fields = ser.Deserialize(reader) as CustomSettings;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Warning : Default settings loaded");
                }
                finally
                {
                    reader.Close();
                }
            }
            else
            {
                WriteXml();
            }
            return Fields;
        }
    }
}
