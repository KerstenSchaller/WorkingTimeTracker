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

namespace WorkingTimeTracker
{
    public partial class form1 : Form
    {
        //define global vars
        private IKeyboardMouseEvents m_Events;
        WorkTimeCalculator workTimeCalculator = new WorkTimeCalculator();
        



        //Initialize form
        public form1()
        {
            
            InitializeComponent();
            StartMouseTracking();
            workTimeCalculator.trigger_Activity();


            this.WindowState = FormWindowState.Minimized;




            populateListViews();

            //set all permanent text values
            InitializeTable();




            this.Hide();
        }

        /*Fills in the permanent text values into the table*/
        private void InitializeTable()
        {
            Label day_label = new Label();
            Label date_label = new Label();
            Label starttime_label = new Label();
            Label endtime_label = new Label();
            Label workingtime_label = new Label();
            day_label.Text = "Day";
            date_label.Text = "Date";
            starttime_label.Text = "Start Time";
            endtime_label.Text = "End Time";
            workingtime_label.Text = "Working Time";

            //add headers
            timeInfoTable.Controls.Add(day_label, 0, 0);
            timeInfoTable.Controls.Add(date_label, 1, 0);
            timeInfoTable.Controls.Add(starttime_label, 2, 0);
            timeInfoTable.Controls.Add(endtime_label, 3, 0);
            timeInfoTable.Controls.Add(workingtime_label, 4, 0);

            //prefill days
            Label days_label1 = new Label();
            Label days_label2 = new Label();
            Label days_label3 = new Label();
            Label days_label4 = new Label();
            Label days_label5 = new Label();
            Label days_label6 = new Label();
            Label days_label7 = new Label();
            days_label1.Text = "Monday";
            timeInfoTable.Controls.Add(days_label1, 0, 1);
            days_label2.Text = "Tuesday";
            timeInfoTable.Controls.Add(days_label2, 0, 2);
            days_label3.Text = "Wednesday";
            timeInfoTable.Controls.Add(days_label3, 0, 3);
            days_label4.Text = "Thursday";
            timeInfoTable.Controls.Add(days_label4, 0, 4);
            days_label5.Text = "Friday";
            timeInfoTable.Controls.Add(days_label5, 0, 5);
            days_label6.Text = "Saturday";
            timeInfoTable.Controls.Add(days_label6, 0, 6);
            days_label7.Text = "Sunday";
            timeInfoTable.Controls.Add(days_label7, 0, 7);

            Label l11 = new Label();
            Label l12 = new Label();
            Label l13 = new Label();
            Label l14 = new Label();
            Label l15 = new Label();
            Label l16 = new Label();
            Label l17 = new Label();

            Label l21 = new Label();
            Label l22 = new Label();
            Label l23 = new Label();
            Label l24 = new Label();
            Label l25 = new Label();
            Label l26 = new Label();
            Label l27 = new Label();

            Label l31 = new Label();
            Label l32 = new Label();
            Label l33 = new Label();
            Label l34 = new Label();
            Label l35 = new Label();
            Label l36 = new Label();
            Label l37 = new Label();

            Label l41 = new Label();
            Label l42 = new Label();
            Label l43 = new Label();
            Label l44 = new Label();
            Label l45 = new Label();
            Label l46 = new Label();
            Label l47 = new Label();


            timeInfoTable.Controls.Add(l11, 1, 1);
            timeInfoTable.Controls.Add(l12, 1, 2);
            timeInfoTable.Controls.Add(l13, 1, 3);
            timeInfoTable.Controls.Add(l14, 1, 4);
            timeInfoTable.Controls.Add(l15, 1, 5);
            timeInfoTable.Controls.Add(l16, 1, 6);
            timeInfoTable.Controls.Add(l17, 1, 7);

            timeInfoTable.Controls.Add(l21, 2, 1);
            timeInfoTable.Controls.Add(l22, 2, 2);
            timeInfoTable.Controls.Add(l23, 2, 3);
            timeInfoTable.Controls.Add(l24, 2, 4);
            timeInfoTable.Controls.Add(l25, 2, 5);
            timeInfoTable.Controls.Add(l26, 2, 6);
            timeInfoTable.Controls.Add(l27, 2, 7);

            timeInfoTable.Controls.Add(l31, 3, 1);
            timeInfoTable.Controls.Add(l32, 3, 2);
            timeInfoTable.Controls.Add(l33, 3, 3);
            timeInfoTable.Controls.Add(l34, 3, 4);
            timeInfoTable.Controls.Add(l35, 3, 5);
            timeInfoTable.Controls.Add(l36, 3, 6);
            timeInfoTable.Controls.Add(l37, 3, 7);

            timeInfoTable.Controls.Add(l41, 4, 1);
            timeInfoTable.Controls.Add(l42, 4, 2);
            timeInfoTable.Controls.Add(l43, 4, 3);
            timeInfoTable.Controls.Add(l44, 4, 4);
            timeInfoTable.Controls.Add(l45, 4, 5);
            timeInfoTable.Controls.Add(l46, 4, 6);
            timeInfoTable.Controls.Add(l47, 4, 7);
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
                fillTable((string)calenderweek_listBox.SelectedItem);
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

            UpdateWorkingTimeChart(workdays);

            fillDatesToTable(FirstDayOfWeek);
            fillTimesToTable(workdays,"starttime");
            fillTimesToTable(workdays, "endtime");
            fillTimesToTable(workdays, "workingtime");

        }

        
        private void fillTimesToTable(List<Workday> workdays,string valuetype)
        {

            var controls = timeInfoTable.Controls;
            int column = 2;

            int start;
            int end;

            switch (valuetype)
            {
                case "starttime":
                    start = 19;
                    end = 25;
                    column = 2;
                    break;
                case "endtime":
                    start = 26;
                    end = 32;
                    column = 3;
                    break;
                case "workingtime":
                    start = 33;
                    end = 39;
                    column = 4;
                    break;
                default:
                    start = 0;
                    end = 0;
                    break;
            }

            int i_workdays = 0;

            // iterate through all days and fill control text either with "---" if theres no info for that day or with the desired value
            for (int i = start; i < end+1; i++)
            {
               if ((workdays[i_workdays] == null) || ( workdays[i_workdays].getStartofWorkday_S() == "0:0" ))
               {
                  controls[i].Text = "---";
                    i_workdays++;
                    continue;
               }
                
                switch (valuetype)
                {
                    case "starttime":
                        controls[i].Text = workdays[i_workdays].getStartofWorkday_S();
                        break;
                    case "endtime":
                        controls[i].Text = workdays[i_workdays].getEndofWorkday_S();
                        break;
                    case "workingtime":
                        controls[i].Text = workdays[i_workdays].getWorkingTime().ToString();
                        break;
                    default:
                        break;
                }
                    
                
                i_workdays++;
            }
            

            
            
        }

        private void fillDatesToTable(DateTime FirstDayOfWeek)
        {

            DateTime Monday = FirstDayOfWeek;
            DateTime Tuesday = Monday + new TimeSpan(1, 0, 0, 0);
            DateTime Wednesday = Monday + new TimeSpan(2, 0, 0, 0);
            DateTime Thursday = Monday + new TimeSpan(3, 0, 0, 0);
            DateTime Friday = Monday + new TimeSpan(4, 0, 0, 0);
            DateTime Saturday = Monday + new TimeSpan(5, 0, 0, 0);
            DateTime Sunday = Monday + new TimeSpan(6, 0, 0, 0);

            string monday = Monday.Day + "." + Monday.Month + "." + Monday.Year;
            string tuesday = Tuesday.Day + "." + Tuesday.Month + "." + Tuesday.Year;
            string wednesday = Wednesday.Day + "." + Wednesday.Month + "." + Wednesday.Year;
            string thursday = Thursday.Day + "." + Thursday.Month + "." + Thursday.Year;
            string friday = Friday.Day + "." + Friday.Month + "." + Friday.Year;
            string saturday = Saturday.Day + "." + Saturday.Month + "." + Saturday.Year;
            string sunday = Sunday.Day + "." + Sunday.Month + "." + Sunday.Year;

            var controls = timeInfoTable.Controls;
            controls[12].Text = monday;
            controls[13].Text = tuesday;
            controls[14].Text = wednesday;
            controls[15].Text = thursday;
            controls[16].Text = friday;
            controls[17].Text = saturday;
            controls[18].Text = sunday;


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

            for (int i = 0; i < 40; i++)
            {
                var controls = timeInfoTable.Controls;
                controls[i].Text = i.ToString();
            }


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
            time_series_standartWorktime.Color = Color.Black;

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            int index = listBox_days.SelectedIndex;
            var days = workTimeCalculator.getdays();

            var day = days[index];

            editDayPopup formpopup = new editDayPopup(day);
            formpopup.Show(this);
            days[index] = formpopup.Day;
            workTimeCalculator.setdays(days,true);
        }
    }
}
