using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WorkingTimeTracker
{
    public class WorkTimeInfo
    {
        public DateTime date = new DateTime();
        public DateTime start_of_workday = new DateTime();
        public DateTime end_of_workday = new DateTime();
        public DateTime last_active = new DateTime();
        public DateTime first_active = new DateTime();
        public List<DateTime> activitys = new List<DateTime>();

        public WorkTimeInfo()
        {
            date = DateTime.Now;
            
        }

        public WorkTimeInfo(bool valid)
        {
            date = NULL;

        }

        public void setStartofWorkday(DateTime time) { start_of_workday = time; }

        public string getStartofWorkday_S()
        {
            return start_of_workday.Hour.ToString() + ":" + start_of_workday.Minute.ToString();
        }

        public void setEndofWorkday(DateTime time) { end_of_workday = time; }

        public string getEndofWorkday_S()
        {
            return end_of_workday.Hour.ToString() + ":" + end_of_workday.Minute.ToString();
        }
        public string getDate_S() { return this.date.Date.ToString().Substring(0, 10); }

        public double getWorkingTime()
        {
            TimeSpan total_time = end_of_workday - start_of_workday;
            TimeSpan time_incl_breaks = total_time;

            /*Calc first brake after 6h*/
            if (total_time.Hours >= 6)
            {
                time_incl_breaks -= new TimeSpan(0,30,0);
            }
            /*Calc first brake after 9h*/
            if ((total_time.TotalMinutes - 30) >= (9*60))
            {
                time_incl_breaks -= new TimeSpan(0, 15, 0);
            }


            return time_incl_breaks.Hours + Math.Round((time_incl_breaks.Minutes/60.0),2);
        }



        public List<DateTime> getActicitys()
        {
            return activitys;
        }

        

        // adds another activity to the list and makes it the last_active
        public void addActivity(DateTime time)
        {
            activitys.Add(time);
            last_active = time;
        }

        
      





        // gets the first activity from the list after a specified time
        public DateTime getfirstActivityAfter(DateTime time)
        {
            foreach (DateTime t in activitys)
            {
                if (t.CompareTo(time) > 0)
                {
                    return t;
                }

            }
            DateTime dummy = new DateTime(1986,1,1);
            return dummy;
        }

        // gets the last activity before a specified time
        public DateTime getlastActivitybefore(DateTime time)
        {
            DateTime t_before = activitys.First();
            foreach (DateTime t in activitys)
            {
                if (t.CompareTo(time) > 0)
                {
                    return t_before;

                }
                t_before = t;

            }
            DateTime dummy = new DateTime(1986, 1, 1);
            return dummy;
        }


        public String convertTimeSpantoString(TimeSpan t)
        {
            return t.ToString();
        }

        public TimeSpan convertStringtoTimeSpan(string s)
        {

            String[] times = s.Split(':');
            if (times[2].Contains("."))
            {
                String[] t = times[2].Split('.');
                times[2] = t[0];
            }
            return new TimeSpan(Int32.Parse(times[0]), Int32.Parse(times[1]), Int32.Parse (times[2]));
        }
    }
}
