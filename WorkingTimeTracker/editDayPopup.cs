using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkingTimeTracker
{
    public partial class editDayPopup : Form
    {

        public Workday Day;
        public editDayPopup(Workday day)
        {
            Day = day;
            InitializeComponent();
            DateLabel.Text = day.getDate_S();
            Starttimetextbox.Text = day.getStartofWorkday_S();
            EndtimeTextbox.Text = day.getEndofWorkday_S();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
            //todo... parse timestring from textboxes into Datetimes
            string[] Starttime = Starttimetextbox.Text.Split(':');
            string[] Endtime = EndtimeTextbox.Text.Split(':');
            int st_h = Int32.Parse(Starttime[0]);
            int st_m = Int32.Parse(Starttime[1]);
            Day.start_of_workday = new DateTime(2000, 1, 1,st_h , st_m,0);
            Day.end_of_workday = new DateTime(2000, 1, 1, Int32.Parse(Endtime[0]), Int32.Parse(Endtime[1]), 0);
            
            this.Close();

        }

        private void Starttimetextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
