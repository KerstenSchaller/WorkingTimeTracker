﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Gma.System.MouseKeyHook;
using Gma.System.MouseKeyHook.Implementation;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace WorkingTimeTracker
{
    public partial class form1 : Form
    {
        //define global vars
        private IKeyboardMouseEvents m_Events;
        WorkTimeCalculator workTimeCalculator = new WorkTimeCalculator();
        string calenderweek_chosen = "";
   


        //Initialize form
        public form1()
        {
            
            InitializeComponent();
            StartMouseTracking();
            workTimeCalculator.trigger_Activity();
            
            this.WindowState = FormWindowState.Minimized;

         /*Set times on axis*/
         WorkingtimeChart.ChartAreas[0].AxisY.Minimum = 0;
         WorkingtimeChart.ChartAreas[0].AxisY.Maximum = 10;
         chart_workingtimesingle.ChartAreas[0].AxisY.Minimum = 0;
         chart_workingtimesingle.ChartAreas[0].AxisY.Maximum = 10;

         


         populateListViews();
         textBox_OverallPlus.Text = "Overall Working Time +/- : " + workTimeCalculator.getOverallPlusMinusTime();
         /*Set element in days listbox*/
         listBox_days.SetSelected(listBox_days.Items.Count -1,true);




         this.Hide();
        }

        

        /*Used to fill values into the days listview*/
        private void populateListViews()
        {

            var days = workTimeCalculator.getdays();
            List<string> strings = new List<string>();
            foreach (var day in days)
            {
                strings.Add(day.getDate_S());
            }

            /*Second line instead of first because that does not cause the selected index changed event to fire*/
            //listBox_days.DataSource = strings;
            listBox_days.Items.AddRange(strings.ToArray());

         

         /*Also Pouplate Calenderweek listview*/
         populateCWListView();

        }




        public void populateCWListView()
        {

            List<string> calenderweeks = workTimeCalculator.getCalendarweeks();
            //finally display the calenderweeks
            /*Second line instead of first because that does not cause the selected index changed event to fire*/
            //calenderweek_listBox.DataSource = calenderweeks;
            calenderweek_listBox.Items.AddRange(calenderweeks.ToArray());
        }




        /*Mouse and keyboard tracking stuff below*/
        void StartMouseTracking()
        {
            SubscribeGlobal();
        }

        /*Subscribe to all mouse events*/
        private void SubscribeGlobal()
        {
            Unsubscribe();
            Subscribe(Hook.GlobalEvents());
        }

        /*subscibe to certain mouse events*/
        private void Subscribe(IKeyboardMouseEvents events)
        {
            m_Events = events;
            m_Events.KeyPress += HookManager_KeyPress;
            m_Events.MouseMove += HookManager_MouseMove;



        }

        // Unsubscribe from mouse events
        private void Unsubscribe()
        {
            if (m_Events == null) return;
            m_Events.KeyPress -= HookManager_KeyPress;
            m_Events.MouseMove -= HookManager_MouseMove;
            m_Events.Dispose();
            m_Events = null;
        }



        /* Keyboard handlers*/
        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            workTimeCalculator.trigger_Activity();

        }

        /*Mouse Handlers*/
        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            workTimeCalculator.trigger_Activity();


        }


        // make form dissapear when minimize button is pressed
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }
        }








        //disable close button
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {

        }

        /*event: mouse clicked on notify icon */
        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                /*show baloontip*/
                showBallonTipClickedInfo();
            }
            if (e.Button == MouseButtons.Left)
            {
                /*show gui*/
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        /*defines what it shown in the ballontip info*/
        public void showBallonTipClickedInfo()
        {
            //show balloon tip
            //var days = workTimeCalculator.getdays();
            Workday day = workTimeCalculator.getWorkdayByDateTime(DateTime.Now);

            string date_s = day.getDate_S();
            double workingTime = day.getWorkingTime();
            string day_start = day.getStartofWorkday_S();
            string day_end = day.getEndofWorkday_S();


            string line1 = "Date: " + date_s + "\n";
            string line2 = "Start: " + day_start + "\n";
            string line3 = "End: " + day_end + "\n";
            string line4 = "Worked: " + workingTime + "hours" + "\n";

            string text = line1 + line2 + line3 + line4;


            notifyIcon1.ShowBalloonTip(5000, "WorkingTimeTracker", text + "\n", ToolTipIcon.Info);

        }

        public void testCalendar()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar calendar = dfi.Calendar;



        }


        /*changes the content of the label according to what day was chosen in listbox*/
        private void listBox_days_SelectedIndexChanged(object sender, EventArgs e)
        {


            int index = listBox_days.SelectedIndex;
            /*Only do action if selected index change event was not triggered by unselecting the listbox*/
            if (index != -1)
            {

                //unselect calenderweek listbox
                calenderweek_listBox.ClearSelected();

                /*Get a list of all days*/
                var days = workTimeCalculator.getdays();
                /*extract day by index chosen in listbox*/
                var day = days[index];

                string calendarweek = day.getWeekOfYear();
                calenderweek_chosen = calendarweek;
                /*Fill table with day information*/
                fillTable(calendarweek);

            }
            
        }


        private void calenderweek_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = calenderweek_listBox.SelectedIndex;

            /*Only do action if selected index change event was not triggered by unselecting the listbox*/
            if (index != -1)
            {
                //unselect days listbox
                listBox_days.ClearSelected();
                calenderweek_chosen = (string)calenderweek_listBox.SelectedItem;
                fillTable(calenderweek_chosen);
            }
        }

        public void fillTable(string calendarweek)
        {
            


            // split calenderweek into week and year
            var v = calendarweek.Split('/');
            int year = Int32.Parse(v[1]);
            int week = Int32.Parse(v[0]);


            // determine first day of week with given year and week(parsed from string to int)
            DateTime FirstDayOfWeek = FirstDateOfWeekISO8601(year, week);

            DateTime Monday = FirstDayOfWeek;
            DateTime Tuesday = Monday + new TimeSpan(1, 0, 0, 0);
            DateTime Wednesday = Monday + new TimeSpan(2, 0, 0, 0);
            DateTime Thursday = Monday + new TimeSpan(3, 0, 0, 0);
            DateTime Friday = Monday + new TimeSpan(4, 0, 0, 0);
            DateTime Saturday = Monday + new TimeSpan(5, 0, 0, 0);
            DateTime Sunday = Monday + new TimeSpan(6, 0, 0, 0);

            //--------------------------------------------------
            // create a list of all workdays in this chosen week
            List<Workday> workdays = new List<Workday>();
            workdays.Add(workTimeCalculator.getWorkdayByDateTime(Monday));
            workdays.Add(workTimeCalculator.getWorkdayByDateTime(Tuesday));
            workdays.Add(workTimeCalculator.getWorkdayByDateTime(Wednesday));
            workdays.Add(workTimeCalculator.getWorkdayByDateTime(Thursday));
            workdays.Add(workTimeCalculator.getWorkdayByDateTime(Friday));
            workdays.Add(workTimeCalculator.getWorkdayByDateTime(Saturday));
            workdays.Add(workTimeCalculator.getWorkdayByDateTime(Sunday));

            
            
            string[] weekdays = {"Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday" };
            listView_table.Items.Clear();

            double pmtime = 0;
            for (int i = 0; i < workdays.Count; i++)
            {
                Workday w = workdays[i];
                ListViewItem it = new ListViewItem(weekdays[i]);
                if (w != null)
                {
                    it.SubItems.Add(w.getDate_S());
                    it.SubItems.Add(w.getStartofWorkday_S());
                    it.SubItems.Add(w.getEndofWorkday_S());
                    var s = w.getWorkingTime().ToString();
                    it.SubItems.Add(s);
                    it.SubItems.Add(w.getPMTime().ToString());
                    pmtime += w.getPMTime();
            }
                else
                {
                    it.SubItems.Add("---");
                    it.SubItems.Add("---");
                    it.SubItems.Add("---");
                    it.SubItems.Add("---");
                }
                listView_table.Items.Add(it);
            }
            listView_table.Update();

            textBox_weeklyPlus.Text = "Calenderweek " + calendarweek + " Working Time +/- : " + pmtime;

            
            UpdateWorkingTimeChart(workdays);
            UpdateWorkingTimeChartSingle();


        }

        

        public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            /*Code taken from*/
            /*https://stackoverflow.com/questions/662379/calculate-date-from-week-number*/
            /*19.01.2019*/


            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
            return result.AddDays(-3);
        }


        private void UpdateButton_Click(object sender, EventArgs e)
        {


        }
        
        private void ExportToXLSButton_Click(object sender, EventArgs e)
        {
            /*Get FilePath by SaveFileDIalog*/
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Tab Seperated Value Excel File|*.xls";
            saveFileDialog1.Title = "Save all days data to xls";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                safeToTextFile(saveFileDialog1.FileName,'\t');
            }
                
        }


        private void safeToTextFile(string Path,char delim)
        {
            List<string> Lines = new List<string>();
            var days = workTimeCalculator.getdays();

            Lines.Add("Date" + delim + "Start of Workday" + delim + "End of Workday" + delim + "WorkingTime[h.m]" + "\n");
            foreach (var day in days)
            {
                string line = day.getDate_S() + delim + day.getStartofWorkday_S() + delim + day.getEndofWorkday_S() + delim + day.getWorkingTime().ToString() + "\n";
                Lines.Add(line);
            }
            Lines[Lines.Count - 1] = null;/*Delete last line since it is the actual day*/
            System.IO.File.WriteAllLines(Path, Lines);


        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }


        
        private void vacationbutton_Click(object sender, EventArgs e)
        {
            int index = listBox_days.SelectedIndex;
            if (index != -1)
            {
                /*Get a list of all days*/
                var days = workTimeCalculator.getdays();
                /*extract day by index chosen in listbox*/

                if (days[index].getVacation() == false)
                {
                    days[index].setVacation(true);
                }
                else
                {
                    days[index].setVacation(false);
                }
                workTimeCalculator.setdays(days, true);
                listBox_days_SelectedIndexChanged(listBox_days, new EventArgs());
            }
        }

        private void Sickbutton_Click(object sender, EventArgs e)
        {
            
            int index = listBox_days.SelectedIndex;
            if (index != -1)
            {
            
                /*Get a list of all days*/
                var days = workTimeCalculator.getdays();
                /*extract day by index chosen in listbox*/

                if (days[index].getSick() == false)
                {
                    days[index].setSick(true);
                }
                else
                {
                    days[index].setSick(false);
                }
                workTimeCalculator.setdays(days, true);
                listBox_days_SelectedIndexChanged(listBox_days, new EventArgs());
            }
        }

        private void form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Icon = null;
        }

        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Icon = null;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }


        //private void UpdateWorkingTimeChart(double[] working_times, double[] working_time_averages)
        private void UpdateWorkingTimeChart(List<Workday> daysWeek)
        {
  

            /*parse working times into array*/
            double[] working_times = new double[7];
            for (int i = 0; i < 7; i++)
            {
                if (daysWeek[i] != null)
                {
                    working_times[i] = daysWeek[i].getWorkingTime();
                }
                else
                {
                    working_times[i] = 0;
                }
                
            }

            double[] working_time_averages = workTimeCalculator.getAverageWorkingTimes();


            /*Create namings used internally to identify series and used for legend*/
            string workingTimeSeries_s = "Working Times";
            string workingTimeAverageSeries_s = "Working times average";
            string standartWorkingTimeseries_s = "Standart Working Time";



            /*Remove old series first*/
            try
            {
                WorkingtimeChart.Series.Remove(WorkingtimeChart.Series[workingTimeSeries_s]);
                WorkingtimeChart.Series.Remove(WorkingtimeChart.Series[workingTimeAverageSeries_s]);
                WorkingtimeChart.Series.Remove(WorkingtimeChart.Series[standartWorkingTimeseries_s]);
            }
            catch { }

            /*Create series for chart*/
            var time_series_week = new Series(workingTimeSeries_s);
            var time_series_week_average = new Series(workingTimeAverageSeries_s);
            var time_series_standartWorktime = new Series(standartWorkingTimeseries_s);

            /*Create X asix labels and add working times*/
            time_series_week.Points.DataBindXY(new[] { "Monday", "Tuesay", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" }, working_times);
            /*Add values to second series "average working times"*/
            time_series_week_average.Points.DataBindY(working_time_averages);
            double standartWorkingTime = workTimeCalculator.getStandartWorkingTime();
            time_series_standartWorktime.Points.DataBindY(new[] { standartWorkingTime, standartWorkingTime, standartWorkingTime, standartWorkingTime, standartWorkingTime, standartWorkingTime, standartWorkingTime });


            /*Add series to chart*/
            WorkingtimeChart.Series.Add(time_series_week);
            WorkingtimeChart.Series.Add(time_series_week_average);
            WorkingtimeChart.Series.Add(time_series_standartWorktime);

            /*Set size of working time columns*/
            WorkingtimeChart.Series[workingTimeSeries_s]["PixelPointWidth"] = "30";


            /*Format average working time series*/
            time_series_week_average.ChartType = SeriesChartType.StackedColumn;
            time_series_week_average.MarkerBorderWidth = 1;
            time_series_week_average.Color = Color.Red;
            WorkingtimeChart.Series[workingTimeAverageSeries_s]["PixelPointWidth"] = "5";

            /*Format standart workingtime time series*/
            time_series_standartWorktime.ChartType = SeriesChartType.Line;
            time_series_standartWorktime.Color = Color.DarkGreen;
            time_series_standartWorktime.BorderWidth = 3;

        }


        //private void UpdateWorkingTimeChart(double[] working_times, double[] working_time_averages)
        private void UpdateWorkingTimeChartSingle()
        {   
            chart_workingtimesingle.Series.Clear();
            var days = workTimeCalculator.getdays();
            Workday workday = days.Last();
            
            double[] working_time_averages = workTimeCalculator.getAverageWorkingTimes();


            /*Create namings used internally to identify series and used for legend*/
            string workingTimeSeries_s = "Working Times";
            
            /*Remove old series first*/
            try
            {
                chart_workingtimesingle.Series.Remove(WorkingtimeChart.Series[workingTimeSeries_s]);
            }
            catch { }

            /*Create series for chart*/
            var time_series_week = new Series(workingTimeSeries_s);
            double[] d = { workday.getWorkingTime() };
            time_series_week.Points.DataBindXY(new[] { "Today" },d);

            

            /*Add series to chart*/
            chart_workingtimesingle.Series.Add(time_series_week);
            
            /*Set size of working time columns*/
            chart_workingtimesingle.Series[workingTimeSeries_s]["PixelPointWidth"] = "30";

            
        }


        private void EditButton_Click(object sender, EventArgs e)
        {
             
            int index = listBox_days.SelectedIndex;
            if(index != -1)
            {

                var days = workTimeCalculator.getdays();
                var day = days[index];

                editDayPopup formpopup = new editDayPopup(day);
                formpopup.ShowDialog(this);
                
                days[index] = formpopup.Day;
                workTimeCalculator.setdays(days, true);
                fillTable(calenderweek_chosen);

            }
        }


    }
}
