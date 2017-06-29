using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace WorkingTimeTracker
{
    public class Basis_information
    {
        public DateTime last_program_start_time;
        [XmlIgnore]
        public List<WorkTimeInfo> days = new List<WorkTimeInfo>();
        
        private WorkTimeInfo current_day_info = new WorkTimeInfo();

        public Basis_information()
        {
            this.last_program_start_time = DateTime.Now;
            

        }

        public DateTime getLastActivity()
        {
            return current_day_info.last_active;
        }



        public  void setLastActivity(DateTime time)
        {
            current_day_info.last_active = time;
        }


        public void addDay()
        {
            days.Add(new WorkTimeInfo());
            current_day_info = days.Last();
        }
        

    }
}
