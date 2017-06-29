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
        public String plus_minus_time = "00:00:00";
        public bool edit_flag = false;
        public bool special_flag = false;
        public bool sick_flag = false;
        public bool vacation_flag = false;
        public String individual_break = "00:00:00";
        public String total_break = "00:00:00";
        public String legal_worktime = "00:00:00";
        public String worktime = "00:00:00";


      public WorkTimeInfo()
        {
            date = DateTime.Now;
            first_active = date;
            last_active = date;
            legal_worktime = convertTimeSpantoString(new TimeSpan(8,24,0));


        }

        public void set_legal_worktime(TimeSpan t){legal_worktime = convertTimeSpantoString(t); }
        public TimeSpan  get_legal_worktime() {return convertStringtoTimeSpan(legal_worktime); }

        public void set_worktime(TimeSpan t) { worktime = convertTimeSpantoString(t); }
        public TimeSpan get_worktime() { return convertStringtoTimeSpan(worktime); }


      public TimeSpan getPlusMinusTime(){return convertStringtoTimeSpan( plus_minus_time); }
        public void setPlusMinusTime(TimeSpan time) { plus_minus_time = convertTimeSpantoString( time); }

        public void set_total_break(TimeSpan t) { total_break = convertTimeSpantoString(t); }
        public TimeSpan get_total_break() { return convertStringtoTimeSpan(total_break); }


        public void setStartofWorkday(DateTime time) { start_of_workday = time; }
        public DateTime getStartofWorkday() { return start_of_workday; }
        public void setEndofWorkday(DateTime time) { end_of_workday = time; }
        public DateTime getEndofWorkday() { return end_of_workday; }



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

        
        public TimeSpan getWorkingHours()
        {
            //return (this.end_of_workday - this.start_of_workday);
            return this.get_worktime();
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

        public TimeSpan get_individual_break()
        {
            return convertStringtoTimeSpan( this.individual_break);
        }

        public void set_individual_break(TimeSpan time)
        {
             this.individual_break =  convertTimeSpantoString( time);
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
