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
        private Workday current_day; // the worktimeinfo of the current day
        private List<Workday> days = new List<Workday>(); // worktimeinfo over all days
        private string data_days_path = Directory.GetCurrentDirectory() + @"\data_days.txt"; // path to file where worktimeinfo over all days will be stored

        public double getStandartWorkingTime() { return 8.4; }


        int max_period_break_time = 15; /*[minutes]*/
        TimeSpan sample_time = new TimeSpan(0, 1,0 );


        public WorkTimeCalculator()
        {

        }

        public double[] getAverageWorkingTimes()
        {
            double[] workingTimeAverages = new double[7];

            double Monday_times = 0;
            double Monday_denominator = 0;
            double Tuesday_times = 0;
            double Tuesday_denominator = 0;
            double Wednesday_times = 0;
            double Wednesday_denominator = 0;
            double Thursday_times = 0;
            double Thursday_denominator = 0;
            double Friday_times = 0;
            double Friday_denominator = 0;
            double Saturday_times = 0;
            double Saturday_denominator = 0;
            double Sunday_times = 0;
            double Sunday_denominator = 0;

            foreach (Workday day in days)
            {
                var weekday = day.start_of_workday.DayOfWeek;
                if (weekday == DayOfWeek.Monday)    { Monday_times += day.getWorkingTime(); Monday_denominator++; }
                if (weekday == DayOfWeek.Tuesday)   { Tuesday_times += day.getWorkingTime(); Tuesday_denominator++; }
                if (weekday == DayOfWeek.Wednesday) { Wednesday_times += day.getWorkingTime(); Wednesday_denominator++; }
                if (weekday == DayOfWeek.Thursday)  { Thursday_times += day.getWorkingTime(); Thursday_denominator++; }
                if (weekday == DayOfWeek.Friday)    { Friday_times += day.getWorkingTime(); Friday_denominator++; }
                if (weekday == DayOfWeek.Saturday)  { Saturday_times += day.getWorkingTime(); Saturday_denominator++; }
                if (weekday == DayOfWeek.Sunday)    { Sunday_times += day.getWorkingTime(); Sunday_denominator++; }
            }

            workingTimeAverages[0] = Monday_times / Monday_denominator;
            workingTimeAverages[1] = Tuesday_times / Tuesday_denominator;
            workingTimeAverages[2] = Wednesday_times / Wednesday_denominator;
            workingTimeAverages[3] = Thursday_times / Thursday_denominator;
            workingTimeAverages[4] = Friday_times / Friday_denominator;
            workingTimeAverages[5] = Saturday_times / Saturday_denominator;
            workingTimeAverages[6] = Sunday_times / Sunday_denominator;

            return workingTimeAverages;


        }

        
        private List<Workday> findMissingDays(List<Workday> days)
        {
         
            Workday Day_before = days[0];
            List<Workday> l = new List<Workday>();
         try {
            l.Add(days[0]);
            for (int i = 1; i < days.Count; i++)
            {
               //l.Add(days[i]);
               //bool cond1 = days[i].date.Day != (Day_before.date.Day + 1);
               //bool cond2 = !(Day_before.date.Day == 31 || Day_before.date.Day == 28 || Day_before.date.Day == 30) && (days[i].date.Day == 1);
               DateTime d = Day_before.date + new TimeSpan(24, 0, 0);
               bool cond3 = !(days[i].date.Date.CompareTo((Day_before.date.Date + new TimeSpan(24, 0, 0))) == 0);
               if (cond3)
               {
                  Workday wti = new Workday();
                  try
                  {
                     wti.date = Day_before.date + new TimeSpan(24, 0, 0);
                  }
                  catch (Exception e)
                  {
                     e = e;
                  }
                  l.Add(wti);
                  Day_before = wti;
                  //i--;
               }
               else
               {
                  l.Add(days[i]);
                  Day_before = days[i];
               }
            }
         }
         catch (Exception ex)
         {
            ex = ex;
         }
            return l;
        }

        public List<Workday> getdays()
        {
            return days;
        }

        public List<string> getCalendarweeks()
        {
            List<string> weeks = new List<string>();
            foreach (Workday day in days) weeks.Add(day.getWeekOfYear());
            weeks = weeks.Distinct().ToList();
            return weeks;
        }


        public void setdays(List<Workday> d, bool save = false)
        {
            this.days = d;
            if (save)
            {
                Serialization.WriteToXmlFile<List<Workday>>(data_days_path, days);
            }
        }




        // triggers all actions related to a new activity
        public void trigger_Activity()
        {
            
            if ((DateTime.Now - last_active) > sample_time)
            {
                triggerEvent();
                this.setdays(days,true);/*save data to file*/
            }
            
        }

        public Workday getWorkdayByDateTime(DateTime date)
        {
            int day = date.Day;
            int month = date.Month;
            int year = date.Year;

            foreach (var d in days)
            {
                int _day = d.date.Day;
                int _month = d.date.Month;
                int _year = d.date.Year;

                if ((_day == day) && (month == _month) && (year == _year))
                {
                    return d;
                }

            }
            return null;            
        }



        private void triggerEvent()
        {
            // Variables
            DateTime currentTime = DateTime.Now;
            bool file_created = false;
            bool day_changed = false;
            bool month_changed = false;
            bool year_changed = false;

         try
            {
                // try to load data from passed days
                days = Serialization.ReadFromXmlFile<List<Workday>>(data_days_path);
                // parse days for missing ones(weekend, vacation, sickness...)
                days = findMissingDays(days);
                // safe back parsed days to file in order to keep the ones which where missing
                Serialization.WriteToXmlFile<List<Workday>>(data_days_path, days);
                current_day = getWorkdayByDateTime(DateTime.Now);
            

            }
            catch
            {
                

                // create new File if loading failed
                Serialization.WriteToXmlFile<List<Workday>>(data_days_path,days);
                file_created = true;
 
            }

            // day of last activity is before now. 
            // That means we have new day

            if (file_created == true)
            {
                day_changed = false;
                month_changed = false;
                year_changed = false;
            }
            else
            {
               if (current_day != null)
               {
               
                   day_changed = (current_day.date.Day.CompareTo(currentTime.Day) < 0); // check if day has changed, 
                   month_changed = (current_day.date.Month.CompareTo(currentTime.Month) < 0);// check if month changed(at month change, daychange will be false)
                   year_changed = (current_day.date.Year.CompareTo(currentTime.Year) < 0);// check if year changed
               }
               
         }


            if (day_changed || month_changed || year_changed || file_created || (current_day == null))
            {
            
                /*Create a new day*/
                days.Add(new Workday(currentTime));
                current_day = days.Last();
                

                current_day.setStartofWorkday(currentTime);
                current_day.setEndofWorkday(currentTime);
                last_active = currentTime;
            }
            else
            {

               // write another activity
               last_active = currentTime;
            //set start of workday of this is a new workday created by the findMissingDays(..) function
            if (current_day.getStartofWorkday() == new DateTime()) { current_day.setStartofWorkday(currentTime); }
               current_day.setEndofWorkday(currentTime);
            }
            

        }

        




        


        


    }
}
