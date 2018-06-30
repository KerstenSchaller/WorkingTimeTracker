using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WorkingTimeTracker
{
    class WorkTimeCalculator
    {
        private DateTime last_active = new DateTime();
        private WorkTimeInfo current_day; // the worktimeinfo of the current day
        private List<WorkTimeInfo> days = new List<WorkTimeInfo>(); // worktimeinfo over all days
        private string data_days_path = Directory.GetCurrentDirectory() + @"\data_days.txt"; // path to file where worktimeinfo over all days will be stored



        int max_period_break_time = 15; /*[minutes]*/
        TimeSpan sample_time = new TimeSpan(0, 1,0 );


        public WorkTimeCalculator()
        {
        }

        public void setdays(List<WorkTimeInfo> d, bool save = false)
        {
            this.days = d;
            if (save)
            {
                Serialization.WriteToXmlFile<List<WorkTimeInfo>>(data_days_path, days);
            }
        }
        
        // returns a list of days supposed to be displayed in a listbox
        public List<string> get_days_list()
        {
            List<string> l = new List<string>();
            foreach (WorkTimeInfo w in days)
            {
                string s = w.date.Date.ToString();
                s = s.Substring(0,11);
                l.Add(s);
                
            }
            return l;
        }

        public List<WorkTimeInfo> get_days() { return days; }
        public WorkTimeInfo get_day(int day) { return days[day]; }
        public WorkTimeInfo get_current_day() { return current_day; }

        // triggers all actions related to a new activity
        public void trigger_Activity()
        {
            if ((DateTime.Now - last_active) > sample_time)
            {
                Analyze();
                this.setdays(days,true);/*save data to file*/
            }
            
        }



        private void Analyze()
        {
            // Variables

            DateTime currentTime = DateTime.Now;
            bool file_created = false;

            try
            {
                // try to load data from passed days
                days = Serialization.ReadFromXmlFile<List<WorkTimeInfo>>(data_days_path);
                current_day = days.Last();

            }
            catch
            {
                // create new days if loading failed
                //current_day = new WorkTimeInfo();
                //days.Add(current_day);

                // create new File if loading failed
                Serialization.WriteToXmlFile<List<WorkTimeInfo>>(data_days_path,days);
                file_created = true;
            }

            // day of last activity is before now. 
            // That means we have new day
            bool day_changed;
            bool month_changed;
            if (file_created == true)
            {
                day_changed = false;
                month_changed = false;
            }
            else
            {
                day_changed = (current_day.last_active.Day.CompareTo(currentTime.Day) < 0); // check if day has changed, 
                month_changed = (current_day.last_active.Month.CompareTo(currentTime.Month) < 0);// check if month changed(at month change, daychange will be false)
            }


            if (day_changed || month_changed || file_created)
            {
            
                /*Create a new day*/
                days.Add(new WorkTimeInfo());
                current_day = days.Last();
                
                current_day.addActivity(currentTime);
                current_day.setStartofWorkday(currentTime);
                current_day.setEndofWorkday(currentTime);
                last_active = current_day.last_active;
            }
            else
            {

                // write another activity
                current_day.addActivity(currentTime);
                last_active = current_day.last_active;
                current_day.setEndofWorkday(currentTime);
            }
            

        }

        




        


        


    }
}
