﻿using System;
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



        int max_period_break_time = 15; /*[minutes]*/
        TimeSpan sample_time = new TimeSpan(0, 1,0 );


        public WorkTimeCalculator()
        {
        }

        public List<Workday> getdays()
        {
            return days;
        }

        public List<int> getCalendarweeks()
        {
            List<int> weeks = new List<int>();
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



        private void triggerEvent()
        {
            // Variables
            DateTime currentTime = DateTime.Now;
            bool file_created = false;

            try
            {
                // try to load data from passed days
                days = Serialization.ReadFromXmlFile<List<Workday>>(data_days_path);
                current_day = days.Last();

            }
            catch
            {
                

                // create new File if loading failed
                Serialization.WriteToXmlFile<List<Workday>>(data_days_path,days);
                file_created = true;
            }

            // day of last activity is before now. 
            // That means we have new day
            bool day_changed;
            bool month_changed;
            bool year_changed;
            if (file_created == true)
            {
                day_changed = false;
                month_changed = false;
                year_changed = false;
            }
            else
            {
                day_changed = (current_day.end_of_workday.Day.CompareTo(currentTime.Day) < 0); // check if day has changed, 
                month_changed = (current_day.end_of_workday.Month.CompareTo(currentTime.Month) < 0);// check if month changed(at month change, daychange will be false)
                year_changed = (current_day.end_of_workday.Year.CompareTo(currentTime.Year) < 0);// check if year changed
            }


            if (day_changed || month_changed || year_changed || file_created)
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
                current_day.setEndofWorkday(currentTime);
            }
            

        }

        




        


        


    }
}
