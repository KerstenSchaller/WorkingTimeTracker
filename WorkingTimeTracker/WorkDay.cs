using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WorkingTimeTracker
{
    public class Workday
    {
        public DateTime date = new DateTime();
        public DateTime start_of_workday = new DateTime();
        public DateTime end_of_workday = new DateTime();

        public bool absent_through_sickness = false;
        public bool absent_through_vacation = false;


      public double getPMTime()
      {
         if ((this.date.Date.DayOfWeek == DayOfWeek.Saturday) || (this.date.Date.DayOfWeek == DayOfWeek.Sunday)) return 0;
         double t = this.getWorkingTime() - IniReader.getStandartWorkingTime();
          t = Math.Round(t,2);
          return t;
      }

      public bool getSick() { return absent_through_sickness; }
        public void setSick(bool value)
        {
            absent_through_sickness = value;
            absent_through_vacation = false;

        }

        public bool getVacation() { return absent_through_vacation; }
        public void setVacation(bool value)
        {
            absent_through_sickness = false;
            absent_through_vacation = value;

        }

        public Workday(DateTime Date)
        {
            date = Date;
        }

        public Workday()
        {

        }


        public string getWeekOfYear()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar calendar = dfi.Calendar;
            int week =  calendar.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            int year = date.Year;
            return (week.ToString() + @"/" + year.ToString());
        }

        public void setStartofWorkday(DateTime time) { start_of_workday = time; }
      public DateTime getStartofWorkday() { return start_of_workday; }
        public string getStartofWorkday_S()
        {
            if (absent_through_sickness == true) return "sick";
            if (absent_through_vacation == true) return "vacation";
            return start_of_workday.Hour.ToString() + ":" + start_of_workday.Minute.ToString();
        }

        public void setEndofWorkday(DateTime time) { end_of_workday = time; }

        public string getEndofWorkday_S()
        {
            if (absent_through_sickness == true) return "sick";
            if (absent_through_vacation == true) return "vacation";
            return end_of_workday.Hour.ToString() + ":" + end_of_workday.Minute.ToString();
        }

        public string getDate_S() { return this.date.Date.ToString().Substring(0, 10); }

        public double getWorkingTime()
        {
         //return hours for full workday if day was sick or vacation
         if (absent_through_sickness == true || absent_through_vacation == true)
         {
            var stdwt = IniReader.getStandartWorkingTime();
            return (stdwt);
         } 

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

            var ret = time_incl_breaks.Hours + Math.Round((time_incl_breaks.Minutes / 60.0), 2);
            return ret;
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
