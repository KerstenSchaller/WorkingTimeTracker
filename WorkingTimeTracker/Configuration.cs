using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WorkingTimeTracker
{
    public class Configuration
    {
        public string SafetyCopyPath = "null";
        public double standartWorkingTime = 8;


        [XmlIgnore]
        public string configFileName = "config.xml";

        public Configuration()
        {

        }

        public void load()
        {
            if (File.Exists(configFileName))
            {
                Configuration c = Serialization.ReadFromXmlFile<Configuration>(configFileName);
                SafetyCopyPath = c.SafetyCopyPath;
                standartWorkingTime = c.standartWorkingTime;
            }
        }


        public void setSafetyCopyPath(string path)
        {
            SafetyCopyPath = path;
        }
        
        public void setStandartWorkingTime(double time)
        {
            standartWorkingTime = time;
            safe();
        }

        private void safe()
        {
            Serialization.WriteToXmlFile<Configuration>(this.configFileName,this);
        }
    }

    
}
