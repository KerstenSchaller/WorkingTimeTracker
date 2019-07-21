using System;
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
using Microsoft.Win32;
using System.IO;

namespace WorkingTimeTracker
{
    public partial class form1 : Form
    {
        //define global vars
        private IKeyboardMouseEvents m_Events;
        WorkTimeCalculator workTimeCalculator ;
        string calenderweek_chosen = "";
        Configuration config = Configuration.Instance;





        //Initialize form
        public form1()
        {
            /*Create workingtimecalculator object*/
            workTimeCalculator = new WorkTimeCalculator();
            /*add sessionswitch callback to detect a lock, or logoff, or shutdown of the system*/
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;

            
            InitializeComponent();

            /*Start tracking mouse movements*/
            StartMouseTracking();

            workTimeCalculator.trigger_Activity();// Trigger first activity after starting program
            
            /*Minimize window*/
            this.WindowState = FormWindowState.Minimized;

            /*Add menu to form*/
            addMenuStrip();

            /*Set times on axis*/
            WorkingtimeChart.ChartAreas[0].AxisY.Minimum = 0;
            WorkingtimeChart.ChartAreas[0].AxisY.Maximum = 10;
            chart_workingtimesingle.ChartAreas[0].AxisY.Minimum = 0;
            chart_workingtimesingle.ChartAreas[0].AxisY.Maximum = 10;
          
            
          
            /*Listview and textbox handling*/
            populateListViews(workTimeCalculator.getdays());

            textBox_OverallPlus.Text = "Overall Working Time +/- : " + workTimeCalculator.getOverallPlusMinusTime();
            /*Set element in days listbox*/
            listBox_days.SetSelected(listBox_days.Items.Count -1,true);

            /*Show warning if SafetyCopy is not configured*/
            if (config.getSafetyCopyPath() == "null")
            {
                pictureBox_Warning.Image = (Image)Properties.Resources.WarningSign;
            }
            else
            {
                /*Hide warning*/
                Size s = this.Size;
                s.Height = 600;
                this.Size = s;
            }

            /*Hide window*/
            this.Hide();
        }

        /*Used to detect system lock, logoff, shutdown*/
        void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case SessionSwitchReason.ConsoleConnect:
                    break;
                case SessionSwitchReason.ConsoleDisconnect:
                    break;
                case SessionSwitchReason.RemoteConnect:
                    break;
                case SessionSwitchReason.RemoteDisconnect:
                    break;
                case SessionSwitchReason.SessionLock:
                    workTimeCalculator.makeSafetyCopy(config.getSafetyCopyPath());
                    break;
                case SessionSwitchReason.SessionLogoff:
                    workTimeCalculator.makeSafetyCopy(config.getSafetyCopyPath());
                    break;
                case SessionSwitchReason.SessionLogon:
                    break;
                case SessionSwitchReason.SessionRemoteControl:
                    break;
                case SessionSwitchReason.SessionUnlock:
                    break;
                default:
                    break;
            }
        }


        /*Adds menu strip items and callbacks*/
        public void addMenuStrip()
        {            
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "MenuStrip";
            var menu1 = new ToolStripMenuItem();
            menuStrip.Items.Add(menu1);
            menu1.Name = "Menu";
            menu1.Text = "Menu";
            
            var submenu1 = new ToolStripMenuItem();
            menu1.DropDownItems.Add(submenu1);
            submenu1.Name = "AutoexportOptions";
            submenu1.Text = "Autoexport Options";
            submenu1.Click += OnMenuAutoExportOptionsClick;

            var submenu2 = new ToolStripMenuItem();
            menu1.DropDownItems.Add(submenu2);
            submenu2.Name = "Import";
            submenu2.Text = "Import";
            submenu2.Click += OnMenuImportClick;

            var submenu3 = new ToolStripMenuItem();
            menu1.DropDownItems.Add(submenu3);
            submenu3.Name = "ExcelExport";
            submenu3.Text = "Export to excel";
            submenu3.Click += OnMenuExcelExportClick;

            var submenu4 = new ToolStripMenuItem();
            menu1.DropDownItems.Add(submenu4);
            submenu4.Name = "SetSdtWorkTime";
            submenu4.Text = "Set standart working time";
            submenu4.Click += OnMenuSetStdTimeClick;


            menuStrip.Update();
        }

        /*Menu callback*/
        private void OnMenuExcelExportClick(object sender, EventArgs e)
        {
            ExportToXLS();
        }



        /*Menu callback*/
        private void OnMenuSetStdTimeClick(object sender, EventArgs e)
        {

            SetStandartWorkingTimePopup popup = new SetStandartWorkingTimePopup();
            popup.ShowDialog(this);
            double stdwt = popup.standardWorkingTime;
            if (stdwt != -1)
            { 
                config.setStandartWorkingTime(stdwt);
            }

            workTimeCalculator = new WorkTimeCalculator();

            UpdateDisplays(calenderweek_chosen);
        }

        /*Menu callback*/
        private void OnMenuAutoExportOptionsClick(object sender, EventArgs e)
        {

            /*Get FilePath by SaveFileDIalog*/
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML File|*.xml";
            saveFileDialog1.Title = "Select a path where safety copy is stored.";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                config.setSafetyCopyPath(saveFileDialog1.FileName);
                //Serialization.WriteToXmlFile<Configuration>("SafetyStoragePath.xml", config);
                workTimeCalculator.makeSafetyCopy(config.getSafetyCopyPath());


                Size s = this.Size;
                s.Height = 600;
                this.Size = s;
                
            }
        }

        /*Menu callback*/
        private void OnMenuImportClick(object sender, EventArgs e)
        {
            /*Get FilePath by SaveFileDIalog*/
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML File|*.xml";
            openFileDialog1.Title = "Select a file from where the workday data is restored.";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                WorkTimeCalculator worktimecalctemp = new WorkTimeCalculator(openFileDialog1.FileName);

                workTimeCalculator.setdays(worktimecalctemp.getdays(),true);
                populateListViews(workTimeCalculator.getdays());
            }


            
        }


        /*Used to fill values into the days listview*/
        private void populateListViews(List<Workday> days)
        {
            
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



        /*Write Calenderweeks into listviews*/
        private void populateCWListView()
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



        /*Create text for countdown textbox*/
        void populateTextbox_countdown()
        {
            var day = workTimeCalculator.getdays().Last();
            var t = day.getPMTime();
            if (t > 0)
            {
                textBox_countdown.Text ="Feierabend!!!";
            }
            else
            {
                int h = (int)t;
                int min = (int)((t - (double)h)*60);
                textBox_countdown.Text = "      " + h +" hours and "+ min + " minutes till Feierabend!";
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
                /*update gui with day information*/
                UpdateDisplays(calendarweek);

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
                UpdateDisplays(calenderweek_chosen);
            }
        }

        /*Update charts and textboxes*/
        public void UpdateDisplays(string calendarweek)
        {
            populateTextbox_countdown();


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
                    it.SubItems.Add(this.doubleToTimeString(w.getWorkingTime()));


                    it.SubItems.Add(this.doubleToTimeString(w.getPMTime()));
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

            textBox_weeklyPlus.Text = "Calenderweek " + calendarweek + " Working Time +/- : " + this.doubleToTimeString(pmtime);

            
            UpdateWorkingTimeChart(workdays);
            UpdateWorkingTimeChartSingle();


        }

        
        /*returns the date of a given calenderweek + year*/
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
        
        /*Exports data to a csv file */
        private void ExportToXLS()
        {
            /*Get FilePath by SaveFileDIalog*/
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Tab Seperated Value Excel File|*.xls";
            saveFileDialog1.Title = "Save all days data to xls";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                safeToTextFile(saveFileDialog1.FileName, '\t');
            }

        }


        /*Defines content of the csv export*/
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

            /*paint bar green if working time reaches end*/
            if (d[0] >= config.getStandartWorkingTime())
            {
                chart_workingtimesingle.Series[workingTimeSeries_s].Color = Color.Green;
            }
            


        }

        /*Opens a popup where the actual chosen day is edited and returned.*/
        /* Actual day is exchanged with the returned one*/
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
                UpdateDisplays(calenderweek_chosen);

            }
        }

      
        private void timer_actualisation_Tick(object sender, EventArgs e)
        {
            UpdateDisplays(calenderweek_chosen);
            populateListViews(workTimeCalculator.getdays());

        }

        /*Helper function: double -> "hh:mm" */
        public string doubleToTimeString(double TimeToCalc = 0)
        {

            double pmtime;
            pmtime = TimeToCalc;
            int hours = (int)pmtime;
            int minutes = (int)((pmtime - hours) * 60);
            minutes = Math.Abs(minutes);
            return (hours.ToString() + ":" + minutes.ToString());
        }

    }


}
