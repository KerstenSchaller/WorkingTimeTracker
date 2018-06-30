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


namespace WorkingTimeTracker
{
    public partial class Form1 : Form
    {
        private IKeyboardMouseEvents m_Events;
        WorkTimeCalculator workTimeCalculator = new WorkTimeCalculator();
        

        public Form1()
        {
            InitializeComponent();
            StartMouseTracking();
            workTimeCalculator.trigger_Activity();
          
            
            this.WindowState = FormWindowState.Minimized;




            populateListView();

            label1.Text = "Here could be the info \n of your desired workday \n ... if you choose one!";

            this.Hide();
        }

        private void populateListView()
        {

            var days = workTimeCalculator.get_days();
            List<string> strings = new List<string>();
            foreach (var day in days)
            {
                strings.Add(day.getDate_S());
            }
            listBox1.DataSource = strings;

        }




        /*Mouse and keyboard tracking stuff below*/

        void StartMouseTracking()
        {
            SubscribeGlobal();
        }

        private void SubscribeGlobal()
        {
            Unsubscribe();
            Subscribe(Hook.GlobalEvents());
        }

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

        private void HookManager_Supress(object sender, MouseEventExtArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                
                return;
            }

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

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            showBallonTipClickedInfo();
               //}
            //if (e.Button == MouseButtons.Right)
            //{
            //    //show balloon tip
            //    WorkTimeInfo day = workTimeCalculator.get_current_day();

            //    //string[] text = this.generate_Info_string(day);
            //    string text = "Hallo test";

            //    notifyIcon1.ShowBalloonTip(5000,"WorkingTimeTracker",text  + "\n" + text[3] + "\n" + text[5], ToolTipIcon.Info);
            //}
        }

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int index = listBox1.SelectedIndex;
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
            this.populateListView();
        }
    }
}
