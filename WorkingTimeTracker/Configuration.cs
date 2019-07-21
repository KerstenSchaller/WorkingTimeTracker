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
        /*Singleton stuff*/
        private static readonly Configuration instance = new Configuration();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Configuration()
        {

        }


        private Configuration()
        {
            this.load();
        }

        public static Configuration Instance
        {
            get
            {
                return instance;
            }
        
        }

        public class Values
        {
            public string SafetyCopyPath = "null";
            public double standartWorkingTime = 8;
        }

        Values values = new Values();


        public string configFileName = "config.xml";
        
        public void load()
        {
            if (File.Exists(configFileName))
            {
                values = Serialization.ReadFromXmlFile<Values>(configFileName);
            }
        }


        public void setSafetyCopyPath(string path)
        {
            values.SafetyCopyPath = path;
            safe();
        }
        
        public void setStandartWorkingTime(double time)
        {
            values.standartWorkingTime = time;
            safe();
        }

        private void safe()
        {
            Serialization.WriteToXmlFile<Values>(this.configFileName,values);
        }

        internal string getSafetyCopyPath()
        {
            return values.SafetyCopyPath;
        }

        internal double getStandartWorkingTime()
        {
            return values.standartWorkingTime;
        }
    }

    
}
