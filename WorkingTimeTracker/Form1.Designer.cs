﻿namespace WorkingTimeTracker
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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.listBox_days = new System.Windows.Forms.ListBox();
<<<<<<< HEAD
=======
            this.UpdateButton = new System.Windows.Forms.Button();
>>>>>>> CompleteReworkOfCode
            this.ExportToCSVButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.calenderweek_listBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timeInfoTable = new System.Windows.Forms.TableLayoutPanel();
            this.Sickbutton = new System.Windows.Forms.Button();
            this.vacationbutton = new System.Windows.Forms.Button();
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
            this.listBox_days.Size = new System.Drawing.Size(99, 277);
            this.listBox_days.TabIndex = 24;
            this.listBox_days.SelectedIndexChanged += new System.EventHandler(this.listBox_days_SelectedIndexChanged);
            // 
<<<<<<< HEAD
            // ExportToCSVButton
            // 
            this.ExportToCSVButton.Location = new System.Drawing.Point(133, 316);
            this.ExportToCSVButton.Name = "ExportToCSVButton";
            this.ExportToCSVButton.Size = new System.Drawing.Size(108, 23);
=======
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(262, 313);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(202, 32);
            this.UpdateButton.TabIndex = 25;
            this.UpdateButton.Text = "testbutton";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // ExportToCSVButton
            // 
            this.ExportToCSVButton.Location = new System.Drawing.Point(28, 374);
            this.ExportToCSVButton.Name = "ExportToCSVButton";
            this.ExportToCSVButton.Size = new System.Drawing.Size(213, 32);
>>>>>>> CompleteReworkOfCode
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
            this.calenderweek_listBox.Size = new System.Drawing.Size(108, 277);
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
            // timeInfoTable
            // 
            this.timeInfoTable.AutoSize = true;
            this.timeInfoTable.BackColor = System.Drawing.SystemColors.ControlDark;
            this.timeInfoTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.timeInfoTable.ColumnCount = 5;
            this.timeInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.timeInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.timeInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.timeInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
<<<<<<< HEAD
            this.timeInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
=======
            this.timeInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
>>>>>>> CompleteReworkOfCode
            this.timeInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.timeInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.timeInfoTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.timeInfoTable.Location = new System.Drawing.Point(282, 32);
            this.timeInfoTable.Name = "timeInfoTable";
            this.timeInfoTable.RowCount = 8;
            this.timeInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.25773F));
            this.timeInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.74227F));
            this.timeInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.timeInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.timeInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.timeInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.timeInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.timeInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.timeInfoTable.Size = new System.Drawing.Size(531, 244);
            this.timeInfoTable.TabIndex = 33;
            this.timeInfoTable.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // Sickbutton
            // 
            this.Sickbutton.Location = new System.Drawing.Point(28, 316);
            this.Sickbutton.Name = "Sickbutton";
            this.Sickbutton.Size = new System.Drawing.Size(99, 23);
            this.Sickbutton.TabIndex = 35;
            this.Sickbutton.Text = "Toggle Sick";
            this.Sickbutton.UseVisualStyleBackColor = true;
            this.Sickbutton.Click += new System.EventHandler(this.Sickbutton_Click);
            // 
            // vacationbutton
            // 
            this.vacationbutton.Location = new System.Drawing.Point(28, 345);
            this.vacationbutton.Name = "vacationbutton";
            this.vacationbutton.Size = new System.Drawing.Size(99, 23);
            this.vacationbutton.TabIndex = 36;
            this.vacationbutton.Text = "Toggle Vacation";
            this.vacationbutton.UseVisualStyleBackColor = true;
            this.vacationbutton.Click += new System.EventHandler(this.vacationbutton_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(829, 377);
=======
            this.ClientSize = new System.Drawing.Size(1060, 425);
>>>>>>> CompleteReworkOfCode
            this.Controls.Add(this.vacationbutton);
            this.Controls.Add(this.Sickbutton);
            this.Controls.Add(this.timeInfoTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calenderweek_listBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExportToCSVButton);
<<<<<<< HEAD
=======
            this.Controls.Add(this.UpdateButton);
>>>>>>> CompleteReworkOfCode
            this.Controls.Add(this.listBox_days);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form1";
            this.Text = "WorkingTimeTracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
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
        private System.Windows.Forms.TableLayoutPanel timeInfoTable;
        private System.Windows.Forms.Button Sickbutton;
        private System.Windows.Forms.Button vacationbutton;
    }
}

