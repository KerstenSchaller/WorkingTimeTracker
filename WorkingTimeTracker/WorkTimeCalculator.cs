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
        private List<string> data_days_path = new List<string>();

        TimeSpan sample_time = new TimeSpan(0, 1, 0);// min time after which a new sample is written


        /*Configuration object obtained by singleton instance*/
        Configuration config = Configuration.Instance;


        /*Return standart working time as read from config*/
        public double getStandartWorkingTime()
        {
            return config.getStandartWorkingTime();
        }




        /*Parameterless Constructor, used to get standart datasets from file*/
        public WorkTimeCalculator()
        {

            data_days_path.Add(Directory.GetCurrentDirectory() + @"\data_days_2019.txt");// new file format
            data_days_path.Add(Directory.GetCurrentDirectory() + @"\data_days.txt"); //  old file format
            // Read data from file to days
            days = ReadData();

        }

        /*Parametrized constructor, used to load data from a certain file(backup)*/
        public WorkTimeCalculator(string path)
        {
            data_days_path.Add(path);
            if (File.Exists(path))
            {
                days = ReadData(path);
            }
            
        }

        /*Plus minus time over all days*/
        public double getOverallPlusMinusTime()
        {
          double d = 0;
          foreach (Workday day in days)
          {
             d += day.getPMTime(); 
          }
          return d;
        }

        /*Average working times as array from monday till sunday*/
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
                if (day == days.Last()){break; }// break for actual day because at the beginning of the day it would screw the average
                var weekday = day.date.DayOfWeek;
                if (weekday == DayOfWeek.Monday)    {Monday_times += day.getWorkingTime(); Monday_denominator++; }
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

        /*Determine if days are missing and add them to list of dayss*/
        private List<Workday> findMissingDays(List<Workday> days)
        {
            Workday Day_before = days[0];
            List<Workday> l = new List<Workday>();
            l.Add(days[0]);
            Workday lastday = days[days.Count - 1];
            int i = 1;

            while (days[i-1] != lastday)
            {
                bool condition_for_adding_days = (days[i-1].date.Date + new TimeSpan(24, 0, 0)).CompareTo(days[i].date.Date) != 0;
                if (condition_for_adding_days)
                {
                    days.Insert(i,new Workday(days[i - 1].date.Date + new TimeSpan(24, 0, 0), config.getStandartWorkingTime()));
                }
                i++;
            }
            
            return days;
        }

        /*Return all days as list*/
        public List<Workday> getdays()
        {
            return days;
        }

        /*Return all contained calenderweeks*/
        public List<string> getCalendarweeks()
        {
            List<string> weeks = new List<string>();
            foreach (Workday day in days) weeks.Add(day.getWeekOfYear());
            weeks = weeks.Distinct().ToList();
            return weeks;
        }


        /*Overwrite days with other days source, option to safe it to file*/
        public void setdays(List<Workday> d, bool save = false)
        {
            this.days = d;
            if (save)
            {
                saveData( days);
            }
        }

        public void makeSafetyCopy(string path)
        {
            WorkTimeCalculator worktimecalctemp = new WorkTimeCalculator(path);
            if (worktimecalctemp.days.Count <= days.Count)
            {
                saveData(path, this.days);
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

        /*Returns a workday from the list of all days, specified by a DateTime*/
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

        /*Save data to default filename*/
        private void saveData(List<Workday> days)
        {
            Serialization.WriteToXmlFile<List<Workday>>(data_days_path[0], days);
        }

        /*Save data to specified filename(used for backup)*/
        private void saveData(string path, List<Workday>days)
        {
            Serialization.WriteToXmlFile<List<Workday>>(path, days);
        }

        /**/
        private List<Workday> ReadData(string path = null)
        {
            List<Workday> days = new List<Workday>();
            if (path != null)
            {
                days = Serialization.ReadFromXmlFile<List<Workday>>(path);
            }
            else
            if (File.Exists(data_days_path[0]))
            {
                days =Serialization.ReadFromXmlFile<List<Workday>>(data_days_path[0]);
            }
            else
            {
                if (File.Exists(data_days_path[1]))
                {
                    days = Serialization.ReadFromXmlFile<List<Workday>>(data_days_path[1]);
                    //saveData(days);
                }

            }
            return days;

        }

        /*Triggers a new event (updates data)*/
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
                days = ReadData();
                // safe back parsed days to file in order to keep the ones which where missing
                saveData( days);
                current_day = getWorkdayByDateTime(DateTime.Now);
            

            }
            catch
            {
                // create new File if loading failed
                saveData(days);
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
                days.Add(new Workday(currentTime, config.getStandartWorkingTime()));
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


            // parse days for missing ones(weekend, vacation, sickness...)
            days = findMissingDays(days);

        }
        
    }
}
