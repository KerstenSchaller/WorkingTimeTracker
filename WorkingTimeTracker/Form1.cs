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
            

            this.Hide();
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
                //show balloon tip
                WorkTimeInfo day = workTimeCalculator.get_current_day();

                //string[] text = this.generate_Info_string(day);
                string text = "Hallo test";

                notifyIcon1.ShowBalloonTip(5000, "WorkingTimeTracker", text  + "\n" + text[3] + "\n" + text[5], ToolTipIcon.Info);
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

        



    




      

   
      


    }
}
