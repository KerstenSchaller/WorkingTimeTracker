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
        /*Variables*/
        public string configFileName = "config.xml";
        Values values = new Values();


        /*--------------------------------------------------------------------------------------------------------------*/
        /*Value container class*/
        public class Values
        {
            public string SafetyCopyPath = "null";
            public double standartWorkingTime = 8;
        }

        

        /*--------------------------------------------------------------------------------------------------------------*/
        /*Singleton stuff*/
        private static readonly Configuration instance = new Configuration();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Configuration()
        {

        }


        private Configuration()
        {
            /*Load values from file*/
            this.load();
        }

        /*Singleton instance*/
        public static Configuration Instance
        {
            get
            {
                return instance;
            }
        
        }
        /*--------------------------------------------------------------------------------------------------------------*/
        /*getters and setters*/
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

        public string getSafetyCopyPath()
        {
            return values.SafetyCopyPath;
        }

        public double getStandartWorkingTime()
        {
            return values.standartWorkingTime;
        }

        /*--------------------------------------------------------------------------------------------------------------*/
        /*File operations*/

        /*Save values to File*/
        private void safe()
        {
            Serialization.WriteToXmlFile<Values>(this.configFileName,values);
        }

        /*Load values from file if it exists*/
        public void load()
        {
            if (File.Exists(configFileName))
            {
                values = Serialization.ReadFromXmlFile<Values>(configFileName);
            }
        }

    }

    
}
