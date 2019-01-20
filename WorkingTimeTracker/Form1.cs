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
            ////show balloon tip
            //WorkTimeInfo day = workTimeCalculator.get_current_day();

            //string date_s = day.getDate_S();
            //double workingTime = day.getWorkingTime();
            //string day_start = day.getStartofWorkday_S();
            //string day_end = day.getEndofWorkday_S();

            //string text = date_s +"_"+ workingTime + "_"+ day_start + "_"+ day_end;
            //string line1 = "Date: " + date_s +  "\n";
            //string line2 = "Start: " + day_start + "\n";
            //string line3 = "End: " + day_end + "\n";
            //string line4 = "Worked: " + workingTime + "hours" + "\n";

            //text = line1 + line2 + line3 + line4;
            //if (true)
            //{
            //    text += "!!! - Be Careful.. your working time approaches 10hours - !!!";
            //}

            //notifyIcon1.ShowBalloonTip(5000, "WorkingTimeTracker", text + "\n" , ToolTipIcon.Info);

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

            
            //remove all controls from table
            timeInfoTable.Controls.Clear();
            //set again all permanent text values
            InitializeTable();


            // split calenderweek into week and year
            var v = calendarweek.Split('/');
            int year = Int32.Parse(v[1]);
            int week = Int32.Parse(v[0]);


            // determine first day of week with given year and week(parsed from string to int)
            DateTime FirstDayOfWeek = FirstDateOfWeekISO8601(year, week);


            fillDatesToTable(FirstDayOfWeek);
            fillStartTimesToTable(FirstDayOfWeek);
            



            //string date_s = day.getDate_S();
            //double workingTime = day.getWorkingTime();
            //string day_start = day.getStartofWorkday_S();
            //string day_end = day.getEndofWorkday_S();


            //string text = "At the " + date_s + "\n"
            //            + "you have worked " + workingTime + " hours" + "\n"
            //            + "You have started at " + day_start +" o'clock"+ "\n"
            //            + "and ended at " + day_end+" o'clock" ;

        }

        private void fillStartTimesToTable(DateTime FirstDayOfWeek)
        {
            DateTime Monday = FirstDayOfWeek;
            DateTime Tuesday = Monday + new TimeSpan(1, 0, 0, 0);
            DateTime Wednesday = Monday + new TimeSpan(2, 0, 0, 0);
            DateTime Thursday = Monday + new TimeSpan(3, 0, 0, 0);
            DateTime Friday = Monday + new TimeSpan(4, 0, 0, 0);
            DateTime Saturday = Monday + new TimeSpan(5, 0, 0, 0);
            DateTime Sunday = Monday + new TimeSpan(6, 0, 0, 0);

            Workday workday = new Workday();
            //--------------------------------------------------
            workday = workTimeCalculator.getWorkdayByDateTime(Monday);
            Label l1 = new Label();
            if (workday == null)
            {
                l1.Text = "---";
            }
            else
            {
                l1.Text = workday.getStartofWorkday_S();
            }
            timeInfoTable.Controls.Add(l1, 2, 1);
            //--------------------------------------------------
            workday = workTimeCalculator.getWorkdayByDateTime(Tuesday);
            Label l2 = new Label();
            if (workday == null)
            {
                l2.Text = "---";
            }
            else
            {
                l2.Text = workday.getStartofWorkday_S();
            }
            timeInfoTable.Controls.Add(l2, 2, 2);
            //--------------------------------------------------
            workday = workTimeCalculator.getWorkdayByDateTime(Wednesday);
            Label l3 = new Label();
            if (workday == null)
            {
                l3.Text = "---";
            }
            else
            {
                l3.Text = workday.getStartofWorkday_S();
            }
            timeInfoTable.Controls.Add(l3, 2, 3);
            //--------------------------------------------------
            workday = workTimeCalculator.getWorkdayByDateTime(Thursday);
            Label l4 = new Label();
            if (workday == null)
            {
                l4.Text = "---";
            }
            else
            {
                l4.Text = workday.getStartofWorkday_S();
            }
            timeInfoTable.Controls.Add(l4, 2, 4);
            //--------------------------------------------------
            workday = workTimeCalculator.getWorkdayByDateTime(Friday);
            Label l5 = new Label();
            if (workday == null)
            {
                l5.Text = "---";
            }
            else
            {
                l5.Text = workday.getStartofWorkday_S();
            }
            timeInfoTable.Controls.Add(l5, 2, 5);
            //--------------------------------------------------
            workday = workTimeCalculator.getWorkdayByDateTime(Saturday);
            Label l6 = new Label();
            if (workday == null)
            {
                l6.Text = "---";
            }
            else
            {
                l6.Text = workday.getStartofWorkday_S();
            }
            timeInfoTable.Controls.Add(l6, 2, 6);
            //--------------------------------------------------
            workday = workTimeCalculator.getWorkdayByDateTime(Sunday);
            Label l7 = new Label();
            if (workday == null)
            {
                l7.Text = "---";
            }
            else
            {
                l7.Text = workday.getStartofWorkday_S();
            }
            timeInfoTable.Controls.Add(l7, 2, 7);
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

            /*Fill Dates*/
            Label monday = new Label();
            Label tuesday = new Label();
            Label wednesday = new Label();
            Label thursday = new Label();
            Label friday = new Label();
            Label saturday = new Label();
            Label sunday = new Label();
            monday.Text = Monday.Day + "." + Monday.Month + "." + Monday.Year;
            tuesday.Text = Tuesday.Day + "." + Tuesday.Month + "." + Tuesday.Year;
            wednesday.Text = Wednesday.Day + "." + Wednesday.Month + "." + Wednesday.Year;
            thursday.Text = Thursday.Day + "." + Thursday.Month + "." + Thursday.Year;
            friday.Text = Friday.Day + "." + Friday.Month + "." + Friday.Year;
            saturday.Text = Saturday.Day + "." + Saturday.Month + "." + Saturday.Year;
            sunday.Text = Sunday.Day + "." + Sunday.Month + "." + Sunday.Year;

            



            timeInfoTable.Controls.Add(monday, 1, 1);
            timeInfoTable.Controls.Add(tuesday, 1, 2);
            timeInfoTable.Controls.Add(wednesday, 1, 3);
            timeInfoTable.Controls.Add(thursday, 1, 4);
            timeInfoTable.Controls.Add(friday, 1, 5);
            timeInfoTable.Controls.Add(saturday, 1, 6);
            timeInfoTable.Controls.Add(sunday, 1, 7);

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
            /*Remove old controls first*/
            //timeInfoTable.Controls.Remove(monday);
            //timeInfoTable.Controls.Remove(tuesday);
            //timeInfoTable.Controls.Remove(wednesday);
            //timeInfoTable.Controls.Remove(thursday);
            //timeInfoTable.Controls.Remove(friday);
            //timeInfoTable.Controls.Remove(saturday);
            //timeInfoTable.Controls.Remove(sunday);

            //remove all controls from table
            timeInfoTable.Controls.Clear();
            //set again all permanent text values
            InitializeTable();


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
        //    List<string> Lines = new List<string>();
        //    var days = workTimeCalculator.get_days();

        //    Lines.Add("Date" + delim + "Start of Workday" + delim + "End of Workday" + delim + "WorkingTime[h.m]" + "\n");
        //    foreach (var day in days)
        //    {
        //        string line = day.getDate_S() + delim + day.getStartofWorkday_S() + delim + day.getEndofWorkday_S() + delim + day.getWorkingTime().ToString() + "\n";
        //        Lines.Add(line);
        //    }
        //    Lines[Lines.Count-1] = null;/*Delete last line since it is the actual day*/
        //    System.IO.File.WriteAllLines(Path,Lines);


        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
