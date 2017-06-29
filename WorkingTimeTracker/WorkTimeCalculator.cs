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
        public string trigger_Activity()
        {
            if ((DateTime.Now - last_active) > sample_time)
            {
                return Analyze();

            }
            return ""; 
        }

        //determines times for all days again
        public void updateAllDays()
        {

            foreach (WorkTimeInfo wti in days)
            {

                if (!(current_day.special_flag ))
                {
                    determine_times(wti);
                }
            }
        }


        private string Analyze()
        {
            // Variables
            


            try
            {
                // try to load data from passed days
                days = Serialization.ReadFromXmlFile<List<WorkTimeInfo>>(data_days_path);
                current_day = days.Last();

            }
            catch
            {
                // create new days if loading failed
                current_day = new WorkTimeInfo();
                days.Add(current_day);
                
                Serialization.WriteToXmlFile<List<WorkTimeInfo>>(data_days_path,days);
            }

            // day of last activity is before now. 
            // That means we have new day
            bool condition1 = (current_day.last_active.Day.CompareTo(DateTime.Now.Day) < 0); // check if day has changed, 
            bool condition2 = (current_day.last_active.Month.CompareTo(DateTime.Now.Month) < 0);// check if month changed(at month change, daychange will be false)
            if (condition1 || condition2)
            {
                // add new day and make it the current
                days.Add(new WorkTimeInfo());
                current_day = days.Last();
                current_day.addActivity(DateTime.Now);
                last_active = current_day.last_active;
            }
            else
            {

                // write another activity
                current_day.addActivity(DateTime.Now);
                last_active = current_day.last_active;
            }
            if (days.Count > 1)
            {
                days = find_missing_days(days);
            }



            
            current_day = determine_times(current_day);
            

            //save changes on days
            Serialization.WriteToXmlFile<List<WorkTimeInfo>>(data_days_path, days);

            string return_str = "start: "
                              + current_day.getStartofWorkday().Hour.ToString()
                              + ":"
                              + current_day.getStartofWorkday().Minute.ToString()
                              + " end: "
                              + current_day.getEndofWorkday().Hour.ToString()
                              + ":"
                              + current_day.getEndofWorkday().Minute.ToString()
                              + "  +/-: "
                              + current_day.getPlusMinusTime().Hours.ToString()
                              + "h:"
                              + current_day.getPlusMinusTime().Minutes.ToString()
                              + "m";
            return return_str;




        }

        private List<WorkTimeInfo> find_missing_days(List<WorkTimeInfo> days)
        {
            WorkTimeInfo Day_before = days[0];
            List<WorkTimeInfo> l = new List<WorkTimeInfo>();
            l.Add(days[0]);
            for (int i = 1;i<days.Count;i++)
            {
                //l.Add(days[i]);
                //bool cond1 = days[i].date.Day != (Day_before.date.Day + 1);
                //bool cond2 = !(Day_before.date.Day == 31 || Day_before.date.Day == 28 || Day_before.date.Day == 30) && (days[i].date.Day == 1);
                DateTime  d = Day_before.date + new TimeSpan(24, 0, 0);
                bool cond3 = !(days[i].date.Date.CompareTo((Day_before.date.Date + new TimeSpan(24, 0, 0))) == 0); 
                if (cond3)
                {
                    WorkTimeInfo wti = new WorkTimeInfo();
                    wti.date = Day_before.date + new TimeSpan(24,0,0);
                    
                    wti.special_flag = true;
                    l.Add(wti);
                    Day_before = wti;
                    i--;
                }
                else
                { 
                    l.Add(days[i]);
                    Day_before = days[i];
                }
            }
            return l;
        }

        public TimeSpan getTotalPlusMinusTime()
        {
            TimeSpan t = new TimeSpan();
            foreach (WorkTimeInfo wti in days)
            {
                if (wti != days.Last())
                {
                    t += wti.getPlusMinusTime();
                }
       
                
            }
            return t;
        }



        public WorkTimeInfo determine_times(WorkTimeInfo workday)
        {
            DateTime clock_time_5h = new DateTime(workday.date.Year, workday.date.Month, workday.date.Day, 5, 0, 0);
            DateTime clock_time_20h = new DateTime(workday.date.Year, workday.date.Month, workday.date.Day, 20, 0, 0);
            DateTime legal_start_time = clock_time_5h;
            DateTime legal_end_time = clock_time_20h;



            // get the activitys of the desired day
            List<DateTime> activitys = workday.getActicitys();

            // create a list of time periods
            List<TimePeriod> timeperiods = new List<TimePeriod>();

            // create a first timeperiod and set the first activitys time as start time
            TimeSpan period_break_time = new TimeSpan();
            timeperiods.Add(new TimePeriod());


            if (((activitys.Count != 0) && (workday.special_flag == false))|| (workday.edit_flag == true))
            {

                if (activitys.Count != 0)
                {
                
                    timeperiods[0].setStartTime(activitys[0]);
            
                    //loop through all activitys
                    for (int i = 1; i < activitys.Count; i++)
                    {
                        period_break_time = activitys[i] - activitys[i-1];
                        if ((period_break_time.TotalMinutes < max_period_break_time) && (activitys[i].CompareTo(legal_end_time) <=0 )) 
                        {
                            // if time between to activitys is below threshold, set the actual activity
                            // time as new Endtime
                            timeperiods.Last().setEndTime(activitys[i]);
                
                        }
                        else
                        {
                            // if break exceeds threshold, create new time period with
                            // start time from actual acitivity
                            // if current activitys time is after legal end time
                            // make legal end time the periods start time
                            timeperiods.Add(new TimePeriod());

                            if (activitys[i].CompareTo(legal_end_time) > 0)
                            {
                                timeperiods.Last().setStartTime(legal_end_time);
                            }
                            else
                            {
                                timeperiods.Last().setStartTime(activitys[i]);

                            }

                        }

                
                    }


                    //sort out single activity periods
                    List<TimePeriod> periods_temp = new List<TimePeriod>();
                    foreach (TimePeriod t_p in timeperiods)
                    {
                        if (t_p.getNumberofActivities() > 1) periods_temp.Add(t_p);
                    }

                    timeperiods = periods_temp;


                    // get start of day inside legal range
                    foreach (TimePeriod t_p in timeperiods)
                    {   

                        if (t_p.getStartTime().CompareTo(legal_start_time) >= 0)
                        {
                            // if start time of period is equal or later to legal start time of workday
                            // set start of workday and break execution of foreach
                            workday.setStartofWorkday(t_p.getStartTime());
                            break;
                        }
                    }

                    // get end of day inside legal range
                    for (int i = timeperiods.Count-1; i >= 0 ; i--  )
                    {

                        if (timeperiods[i].getEndTime().CompareTo(legal_end_time) <= 0)
                        {
                            // if start time of period is equal or earlier than legal end time of workday
                            // set end of workday and break execution of foreach
                            workday.setEndofWorkday(timeperiods[i].getEndTime());
                            break;
                        }
                    }

                }

                // determine plus minus time for each day
                if (workday.getStartofWorkday().Year != 0001)
                {
                    TimeSpan legal_working_time = new TimeSpan(8, 0, 0);
                    TimeSpan hours_worked = workday.getEndofWorkday() - workday.getStartofWorkday();
                    TimeSpan pause = new TimeSpan(0, 0, 0);
                    if (hours_worked > new TimeSpan(6, 0, 0)) // substract pause after 6 hours
                    {
                        pause += new TimeSpan(0, 30, 0);
                    }
                    if (hours_worked > new TimeSpan(9, 0, 0)) // substract pause after 9 hours
                    {
                        pause += new TimeSpan(0, 15, 0);
                    }
                    pause += workday.get_individual_break();
                    workday.set_total_break(pause);
                    hours_worked -= pause;
                    workday.set_worktime( hours_worked);
                    TimeSpan plusminus = hours_worked - legal_working_time;
                    workday.setPlusMinusTime(plusminus);

                }
                else
                {
                    workday.setPlusMinusTime(new TimeSpan(0, 0, 0));
                }
            }

            if ((workday.special_flag == true) && (workday.sick_flag == false) && (workday.vacation_flag == false))
            {
                return workday;
            }
            if ((workday.sick_flag == true) ||(workday.vacation_flag == true))
            {
                // set start and end of workday to default values
                DateTime d = DateTime.Now;
                workday.setStartofWorkday(new DateTime(d.Year, d.Month, d.Day, 8, 0, 0));
                workday.setEndofWorkday(new DateTime(d.Year, d.Month, d.Day, 8 + workday.get_legal_worktime().Hours, workday.get_legal_worktime().Minutes + 30/*Pause*/, 0));
                workday.setPlusMinusTime(new TimeSpan(0,0,0));
                
            }
            return workday;



        }


    }
}
