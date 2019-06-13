namespace WorkingTimeTracker
{
    partial class form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
         this.listBox_days = new System.Windows.Forms.ListBox();
         this.ExportToCSVButton = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.calenderweek_listBox = new System.Windows.Forms.ListBox();
         this.label3 = new System.Windows.Forms.Label();
         this.Sickbutton = new System.Windows.Forms.Button();
         this.vacationbutton = new System.Windows.Forms.Button();
         this.WorkingtimeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.EditButton = new System.Windows.Forms.Button();
         this.listView_table = new System.Windows.Forms.ListView();
         this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chart_workingtimesingle = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.textBox_OverallPlus = new System.Windows.Forms.TextBox();
         this.textBox_weeklyPlus = new System.Windows.Forms.TextBox();
         ((System.ComponentModel.ISupportInitialize)(this.WorkingtimeChart)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.chart_workingtimesingle)).BeginInit();
         this.SuspendLayout();
         // 
         // notifyIcon1
         // 
         this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
         this.notifyIcon1.Text = "WorkingTimeTracker";
         this.notifyIcon1.Visible = true;
         this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
         this.notifyIcon1.BalloonTipClosed += new System.EventHandler(this.notifyIcon1_BalloonTipClosed);
         this.notifyIcon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDown);
         // 
         // listBox_days
         // 
         this.listBox_days.FormattingEnabled = true;
         this.listBox_days.Location = new System.Drawing.Point(28, 32);
         this.listBox_days.Name = "listBox_days";
         this.listBox_days.Size = new System.Drawing.Size(99, 498);
         this.listBox_days.TabIndex = 24;
         this.listBox_days.SelectedIndexChanged += new System.EventHandler(this.listBox_days_SelectedIndexChanged);
         // 
         // ExportToCSVButton
         // 
         this.ExportToCSVButton.Location = new System.Drawing.Point(855, 127);
         this.ExportToCSVButton.Name = "ExportToCSVButton";
         this.ExportToCSVButton.Size = new System.Drawing.Size(99, 23);
         this.ExportToCSVButton.TabIndex = 27;
         this.ExportToCSVButton.Text = "Export to *.xls";
         this.ExportToCSVButton.UseVisualStyleBackColor = true;
         this.ExportToCSVButton.Click += new System.EventHandler(this.ExportToXLSButton_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(25, 9);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(60, 13);
         this.label2.TabIndex = 28;
         this.label2.Text = "InfoByDate";
         // 
         // calenderweek_listBox
         // 
         this.calenderweek_listBox.FormattingEnabled = true;
         this.calenderweek_listBox.Location = new System.Drawing.Point(133, 31);
         this.calenderweek_listBox.Name = "calenderweek_listBox";
         this.calenderweek_listBox.Size = new System.Drawing.Size(108, 498);
         this.calenderweek_listBox.TabIndex = 29;
         this.calenderweek_listBox.SelectedIndexChanged += new System.EventHandler(this.calenderweek_listBox_SelectedIndexChanged);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(130, 9);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(105, 13);
         this.label3.TabIndex = 30;
         this.label3.Text = "InfoByCalenderweek";
         // 
         // Sickbutton
         // 
         this.Sickbutton.Location = new System.Drawing.Point(855, 31);
         this.Sickbutton.Name = "Sickbutton";
         this.Sickbutton.Size = new System.Drawing.Size(99, 23);
         this.Sickbutton.TabIndex = 35;
         this.Sickbutton.Text = "Toggle Sick";
         this.Sickbutton.UseVisualStyleBackColor = true;
         this.Sickbutton.Click += new System.EventHandler(this.Sickbutton_Click);
         // 
         // vacationbutton
         // 
         this.vacationbutton.Location = new System.Drawing.Point(855, 63);
         this.vacationbutton.Name = "vacationbutton";
         this.vacationbutton.Size = new System.Drawing.Size(99, 23);
         this.vacationbutton.TabIndex = 36;
         this.vacationbutton.Text = "Toggle Vacation";
         this.vacationbutton.UseVisualStyleBackColor = true;
         this.vacationbutton.Click += new System.EventHandler(this.vacationbutton_Click);
         // 
         // WorkingtimeChart
         // 
         chartArea5.Name = "ChartArea1";
         this.WorkingtimeChart.ChartAreas.Add(chartArea5);
         legend3.Name = "Legend1";
         this.WorkingtimeChart.Legends.Add(legend3);
         this.WorkingtimeChart.Location = new System.Drawing.Point(282, 237);
         this.WorkingtimeChart.Name = "WorkingtimeChart";
         this.WorkingtimeChart.Size = new System.Drawing.Size(672, 293);
         this.WorkingtimeChart.TabIndex = 37;
         this.WorkingtimeChart.Text = "chart1";
         this.WorkingtimeChart.Click += new System.EventHandler(this.chart1_Click);
         // 
         // EditButton
         // 
         this.EditButton.Location = new System.Drawing.Point(855, 95);
         this.EditButton.Name = "EditButton";
         this.EditButton.Size = new System.Drawing.Size(99, 23);
         this.EditButton.TabIndex = 38;
         this.EditButton.Text = "EditDay";
         this.EditButton.UseVisualStyleBackColor = true;
         this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
         // 
         // listView_table
         // 
         this.listView_table.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
         this.listView_table.GridLines = true;
         this.listView_table.Location = new System.Drawing.Point(282, 32);
         this.listView_table.MultiSelect = false;
         this.listView_table.Name = "listView_table";
         this.listView_table.Size = new System.Drawing.Size(567, 150);
         this.listView_table.TabIndex = 40;
         this.listView_table.UseCompatibleStateImageBehavior = false;
         this.listView_table.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Day";
         this.columnHeader1.Width = 100;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Date";
         this.columnHeader2.Width = 100;
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "Starttime";
         this.columnHeader3.Width = 100;
         // 
         // columnHeader4
         // 
         this.columnHeader4.Text = "Endtime";
         this.columnHeader4.Width = 100;
         // 
         // columnHeader5
         // 
         this.columnHeader5.Text = "WorkingTIme";
         this.columnHeader5.Width = 100;
         // 
         // chart_workingtimesingle
         // 
         chartArea6.Name = "ChartArea1";
         this.chart_workingtimesingle.ChartAreas.Add(chartArea6);
         this.chart_workingtimesingle.Location = new System.Drawing.Point(970, 32);
         this.chart_workingtimesingle.Name = "chart_workingtimesingle";
         this.chart_workingtimesingle.Size = new System.Drawing.Size(146, 492);
         this.chart_workingtimesingle.TabIndex = 41;
         this.chart_workingtimesingle.Text = "chart1";
         // 
         // columnHeader6
         // 
         this.columnHeader6.Text = "+/- Time";
         // 
         // textBox_OverallPlus
         // 
         this.textBox_OverallPlus.Location = new System.Drawing.Point(282, 198);
         this.textBox_OverallPlus.Name = "textBox_OverallPlus";
         this.textBox_OverallPlus.Size = new System.Drawing.Size(182, 20);
         this.textBox_OverallPlus.TabIndex = 42;
         // 
         // textBox_weeklyPlus
         // 
         this.textBox_weeklyPlus.Location = new System.Drawing.Point(598, 198);
         this.textBox_weeklyPlus.Name = "textBox_weeklyPlus";
         this.textBox_weeklyPlus.Size = new System.Drawing.Size(251, 20);
         this.textBox_weeklyPlus.TabIndex = 43;
         // 
         // form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1130, 541);
         this.Controls.Add(this.textBox_weeklyPlus);
         this.Controls.Add(this.textBox_OverallPlus);
         this.Controls.Add(this.chart_workingtimesingle);
         this.Controls.Add(this.listView_table);
         this.Controls.Add(this.EditButton);
         this.Controls.Add(this.WorkingtimeChart);
         this.Controls.Add(this.vacationbutton);
         this.Controls.Add(this.Sickbutton);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.calenderweek_listBox);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.ExportToCSVButton);
         this.Controls.Add(this.listBox_days);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "form1";
         this.Text = "WorkingTimeTracker";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form1_FormClosing);
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form1_FormClosed);
         this.Load += new System.EventHandler(this.Form1_Load);
         this.Resize += new System.EventHandler(this.Form1_Resize);
         ((System.ComponentModel.ISupportInitialize)(this.WorkingtimeChart)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chart_workingtimesingle)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ListBox listBox_days;
        private System.Windows.Forms.Button ExportToCSVButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox calenderweek_listBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Sickbutton;
        private System.Windows.Forms.Button vacationbutton;
        private System.Windows.Forms.DataVisualization.Charting.Chart WorkingtimeChart;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.ListView listView_table;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_workingtimesingle;
      private System.Windows.Forms.ColumnHeader columnHeader6;
      private System.Windows.Forms.TextBox textBox_OverallPlus;
      private System.Windows.Forms.TextBox textBox_weeklyPlus;
   }
}

