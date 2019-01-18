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
        private IKeyboardMouseEvents m_Events;
        WorkTimeCalculator workTimeCalculator = new WorkTimeCalculator();

        List<int> calenderweeks_present = new List<int>();
        

        public form1()
        {
            InitializeComponent();
            StartMouseTracking();
            workTimeCalculator.trigger_Activity();
          
            
            this.WindowState = FormWindowState.Minimized;




            populateListView();
            
            label1.Text = "Here could be the info \n of your desired workday \n ... if you choose one!";

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



            this.Hide();
        }

        /*Used to fill values into the days listview*/
        private void populateListView()
        {

            var days = workTimeCalculator.get_days();
            List<string> strings = new List<string>();
            foreach (var day in days)
            {
                strings.Add(day.getDate_S());
            }
            listBox_days.DataSource = strings;

            /*Also Pouplate Calenderweek listview*/
            populateCWListView();

        }




        public void populateCWListView()
        {
            var days = workTimeCalculator.get_days();

            int cw = -1;
            int cw_ll = -1;
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar calendar = dfi.Calendar;
            List<string> calenderweeks = new List<string>();
            // loop through all days and create a list of Calenderweeks to display
            foreach (var day in days)
            {

                //determine calenderweek
                cw = calendar.GetWeekOfYear(day.date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                if (cw != cw_ll)
                {
                    //compose string for listbox
                    calenderweeks.Add(cw.ToString() +@"/"+ day.date.Year);
                }
                cw_ll = cw;

                //finally display the calenderweeks
                calenderweek_listBox.DataSource = calenderweeks;
            }



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
            WorkTimeInfo day = workTimeCalculator.get_current_day();

            string date_s = day.getDate_S();
            double workingTime = day.getWorkingTime();
            string day_start = day.getStartofWorkday_S();
            string day_end = day.getEndofWorkday_S();

            string text = date_s +"_"+ workingTime + "_"+ day_start + "_"+ day_end;
            string line1 = "Date: " + date_s +  "\n";
            string line2 = "Start: " + day_start + "\n";
            string line3 = "End: " + day_end + "\n";
            string line4 = "Worked: " + workingTime + "hours" + "\n";

            text = line1 + line2 + line3 + line4;
            if (true)
            {
                text += "!!! - Be Careful.. your working time approaches 10hours - !!!";
            }

            notifyIcon1.ShowBalloonTip(5000, "WorkingTimeTracker", text + "\n" , ToolTipIcon.Info);

        }

        /*changes the content of the label according to what day was chosen in listbox*/
        private void listBox_days_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int index = listBox_days.SelectedIndex;
            var days = workTimeCalculator.get_days();
            var day = days[index];
            string date_s = day.getDate_S();
            double workingTime = day.getWorkingTime();
            string day_start = day.getStartofWorkday_S();
            string day_end = day.getEndofWorkday_S();


            string text = "At the " + date_s + "\n"
                        + "you have worked " + workingTime + " hours" + "\n"
                        + "You have started at " + day_start +" o'clock"+ "\n"
                        + "and ended at " + day_end+" o'clock" ;

            label1.Text = text;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            //this.populateListView();

            Label label1 = new Label();
            label1.Text = "Day";

            timeInfoTable.Controls.Add(label1, 1,0);

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
            var days = workTimeCalculator.get_days();

            Lines.Add("Date" + delim + "Start of Workday" + delim + "End of Workday" + delim + "WorkingTime[h.m]" + "\n");
            foreach (var day in days)
            {
                string line = day.getDate_S() + delim + day.getStartofWorkday_S() + delim + day.getEndofWorkday_S() + delim + day.getWorkingTime().ToString() + "\n";
                Lines.Add(line);
            }
            Lines[Lines.Count-1] = null;/*Delete last line since it is the actual day*/
            System.IO.File.WriteAllLines(Path,Lines);


        }

        private void calenderweek_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
