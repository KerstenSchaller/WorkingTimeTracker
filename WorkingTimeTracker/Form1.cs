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
            string s = workTimeCalculator.trigger_Activity();
            if (s != "") label6.Text = "Today: " + s ;
          
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            listView1.View = View.Details;
        
            populate_Listview();

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


      bool b = true;
      private void populate_Listview()
        {
         if (b) {
            b = false;
            ColumnHeader columnHeader0 = new ColumnHeader();
            ColumnHeader columnHeader1 = new ColumnHeader();
            ColumnHeader columnHeader2 = new ColumnHeader();
            ColumnHeader columnHeader3 = new ColumnHeader();
            ColumnHeader columnHeader4 = new ColumnHeader();
            ColumnHeader columnHeader5 = new ColumnHeader();
            ColumnHeader columnHeader6 = new ColumnHeader();
            ColumnHeader columnHeader7 = new ColumnHeader();
            columnHeader0.Text = "Day";
            columnHeader1.Text = "Date";
            columnHeader2.Text = "Start";
            columnHeader3.Text = "End";
            columnHeader4.Text = "Working Time";
            columnHeader5.Text = "+/-";
            columnHeader6.Text = "";
            columnHeader7.Text = "Legal Worktime";
            this.listView1.Columns.AddRange(new ColumnHeader[] { columnHeader0 });
            this.listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            this.listView1.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            this.listView1.Columns.AddRange(new ColumnHeader[] { columnHeader3 });
            this.listView1.Columns.AddRange(new ColumnHeader[] { columnHeader4 });
            this.listView1.Columns.AddRange(new ColumnHeader[] { columnHeader5 });
            this.listView1.Columns.AddRange(new ColumnHeader[] { columnHeader6 });
            this.listView1.Columns.AddRange(new ColumnHeader[] { columnHeader7 });

         }
         //label1.Text = info_text[0];
         //label2.Text = info_text[1];
         //label3.Text = info_text[2];
         //label4.Text = info_text[3];


         List<string> days =  workTimeCalculator.get_days_list();
            
            listView1.Items.Clear();
            
            for (int i = 0; i < days.Count; i++)
            {
                WorkTimeInfo day = workTimeCalculator.get_day(i);
                string[] info_text = generate_Info_string(day);
                DateTime weekday = day.date;
                ListViewItem listitem = new ListViewItem(weekday.DayOfWeek.ToString());
           
                // todo exchange info text with correct values
                listitem.SubItems.Add(days[i]);
                listitem.SubItems.Add(info_text[0].Substring(12));
                listitem.SubItems.Add(info_text[1].Substring(10));
                listitem.SubItems.Add(info_text[2].Substring(13));
                listitem.SubItems.Add(info_text[3].Substring(4));
                string editstr = "";
                if (day.edit_flag == true) editstr = "editet & ";
               if (day.sick_flag == true)
               {
                  listitem.SubItems.Add(editstr + "Sick");
               }
               else
               {
                  if (day.vacation_flag == true)
                  {
                     listitem.SubItems.Add(editstr + "Vacation");
                  }
               }


            //color rows according to days
            //red = missing data on usual working days.
            //black = weekends, without work activity
            //green = any day with valid workinfo
            //pink = sick days
            //light blue = vacation days

            DayOfWeek d = day.date.DayOfWeek;
            listitem.BackColor = Color.Green;
                if (day.special_flag && !day.edit_flag)
                {
                    listitem.BackColor = Color.Red;
                    
                    if ((d == DayOfWeek.Saturday) || (d == DayOfWeek.Sunday))
                    {

                        listitem.BackColor = Color.Black;
                        
                    }
                }
               if (day.vacation_flag)
               {
                  listitem.BackColor = Color.Aqua;
               }
               else
               {
                  if (day.sick_flag)
                  {
                     listitem.BackColor = Color.Pink;
                  }
               }

                
                listView1.Items.Add(listitem);
            }
         
       

            listView1.Columns[0].Width = -2;
            listView1.Columns[1].Width = -2;
            listView1.Columns[2].Width = -2;
            listView1.Columns[3].Width = -2;
            listView1.Columns[4].Width = -2;
            listView1.Columns[5].Width = -2;
            listView1.Columns[6].Width = -2;
            listView1.Columns[7].Width = -2;

         label5.Text = generate_Info_string(workTimeCalculator.get_current_day())[4];
        }


        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    workTimeCalculator.activ_before = false;
        //}

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
            string s = workTimeCalculator.trigger_Activity();
            if (s != "")
            {
                label6.Text = "Today: " + s;
                populate_Listview();

            }

        }

        /*Mouse Handlers*/
        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            string s = workTimeCalculator.trigger_Activity();
            if (s != "")
            {
                label6.Text = "Today: " + s;
                populate_Listview();

            }

        }


        // make form dissapear when minimize button is pressed
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {    
                this.Hide();
            }
        }

        // make form appear or dissapear again after double clicking the notify icon
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        

        public string[] generate_Info_string(WorkTimeInfo day)
        {
            workTimeCalculator.updateAllDays();
            string[] text = new string[6];
            string sign = "";
            string sign2 = "";
            string h_pm = Math.Abs((int)workTimeCalculator.getTotalPlusMinusTime().TotalHours) + "h:" + Math.Abs((int)workTimeCalculator.getTotalPlusMinusTime().Minutes) + "min";
            if ((workTimeCalculator.getTotalPlusMinusTime().Hours < 0) || (workTimeCalculator.getTotalPlusMinusTime().Minutes) < 0)
            {
                sign = "-";
            }
            if (day.getPlusMinusTime().TotalMilliseconds < 0 )
            {
                sign2 = "-";
            }

            text[0] = "Start Time: " + day.start_of_workday.Hour + ":" + day.start_of_workday.Minute +" ";
            text[1] = "End Time: " + day.end_of_workday.Hour + ":" + day.end_of_workday.Minute + " ";
            text[2] = "Working Time: " + day.getWorkingHours().Hours + "h:" + day.getWorkingHours().Minutes + "m" + " ";
            text[3] = "+/- : " + sign2 + Math.Abs(day.getPlusMinusTime().Hours) + "h:" + Math.Abs(day.getPlusMinusTime().Minutes) + "m" + " ";
            text[4] = "Total +/- : " + sign + h_pm  + "- without today";
            text[5] = "Planned Downtime : " + (day.getStartofWorkday() + day.get_legal_worktime() + day.get_total_break()).Hour + ":" + (day.getStartofWorkday() + day.get_legal_worktime() + day.get_total_break()).Minute + " ";

            return text;
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

        
        bool baloon_tip_active = false;
        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            baloon_tip_active = false;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            baloon_tip_active = false;
        }

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //show gui
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            if (e.Button == MouseButtons.Right)
            {
                //show balloon tip
                workTimeCalculator.updateAllDays();
                WorkTimeInfo day = workTimeCalculator.get_current_day();
                string[] text = this.generate_Info_string(day);
                notifyIcon1.ShowBalloonTip(5000,"WorkingTimeTracker",text[0] + text[1] + "\n" + text[3] + "\n" + text[5], ToolTipIcon.Info);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.editButton.Enabled = true;


        }



    



        int index;
        List<WorkTimeInfo> days;
        private void editButton_Click(object sender, EventArgs e)
        {
        
            var indices = listView1.SelectedIndices;
            if(indices.Count != 0)
            {
               index = indices[0];
               days = workTimeCalculator.get_days();

               this.SaveButton.Enabled = true;
               this.setWorkTimeButton.Enabled = true;
               this.SickButton.Enabled = true;
               this.vacationButton.Enabled = true;
               this.resetDayButton.Enabled = true;
               this.SaveButton.Enabled = true;
            }
      }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            get_changed_times();
            populate_Listview();
            workTimeCalculator.setdays(days,true);
            
            this.SaveButton.Enabled = false;
            this.setWorkTimeButton.Enabled = false;
            this.SickButton.Enabled = false;
            this.vacationButton.Enabled = false;
            this.resetDayButton.Enabled = false;
            this.SaveButton.Enabled = false;
            this.setEndButton.Enabled = false;
            this.setStartButton.Enabled = false;
            this.setLegalWorktimeButton.Enabled = false;

            this.textBox_EndTime.Enabled = false;
            this.textBox_legal_time.Enabled = false;
            this.textBox_StartTime.Enabled = false;

        }

        private void vacationButton_Click(object sender, EventArgs e)
        {
            days[index].vacation_flag = true;
            
        }

        private void SickButton_Click(object sender, EventArgs e)
        {
            days[index].sick_flag = true;

        }

        private void setWorkTimeButton_Click(object sender, EventArgs e)
        {
            days[index].edit_flag = true;
            this.setEndButton.Enabled = true;
            this.setStartButton.Enabled = true;
            this.setLegalWorktimeButton.Enabled = true;

            this.textBox_StartTime.Text = days[index].getStartofWorkday().ToString().Substring(11);
            this.textBox_EndTime.Text = days[index].getEndofWorkday().ToString().Substring(11);
            this.textBox_legal_time.Text = days[index].get_legal_worktime().ToString();

      }

      private void get_changed_times()
      {
         string[] s0 = this.textBox_StartTime.Text.Split(':');
         string[] s1 = this.textBox_EndTime.Text.Split(':');
         string[] s2 = this.textBox_legal_time.Text.Split(':');

         if (s0[0] != "" && s1[0] != "" && s2[0] != "" )
         { 
            DateTime d = days[index].date;
            days[index].setStartofWorkday(new DateTime(d.Year,d.Month,d.Day,Int32.Parse(s0[0]), Int32.Parse(s0[1]), Int32.Parse(s0[2])));
            days[index].setEndofWorkday(new DateTime(d.Year, d.Month, d.Day, Int32.Parse(s1[0]), Int32.Parse(s1[1]), Int32.Parse(s1[2])));
            days[index].set_legal_worktime(new TimeSpan(Int32.Parse(s2[0]), Int32.Parse(s2[1]), Int32.Parse(s2[2])    ));
         }



      }
   
      

      private void resetDayButton_Click(object sender, EventArgs e)
        {
            if (days[index].sick_flag || days[index].vacation_flag || days[index].edit_flag)
            {
                days[index].sick_flag = false;
                days[index].vacation_flag = false;
                days[index].edit_flag = false;
                days[index].setStartofWorkday(new DateTime());
                days[index].setEndofWorkday(new DateTime());
                days[index].set_worktime(new TimeSpan(0, 0, 0));
                days[index].setPlusMinusTime(new TimeSpan(0, 0, 0));
            }

        }

      private void setlegalWorkTimeButton_Click(object sender, EventArgs e)
      {

      }


      private void setLegalWorktimeButton_Click_1(object sender, EventArgs e)
      {
         this.textBox_legal_time.Enabled = true;
      }

      private void setEndButton_Click(object sender, EventArgs e)
      {
         this.textBox_EndTime.Enabled = true;
      }

      private void setStartButton_Click(object sender, EventArgs e)
      {
         this.textBox_StartTime.Enabled = true;
      }

        private bool toggle = true;
        private void burger_button_Click(object sender, EventArgs e)
        {
            if (toggle)
            {
                this.Width = 620 +450;
                toggle = !toggle;
            }
            else
            {
                this.Width = 620;
                toggle = !toggle;
            }
            
        }

    }
}
