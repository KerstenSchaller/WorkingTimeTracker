using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkingTimeTracker
{
    public partial class SetStandartWorkingTimePopup : Form
    {
        public double standardWorkingTime = -1;

        public SetStandartWorkingTimePopup()
        {
            InitializeComponent();
        }

        private void button_Set_Click(object sender, EventArgs e)
        {
            
            standardWorkingTime = Double.Parse(textBox_workingTime.Text, CultureInfo.InvariantCulture);
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
