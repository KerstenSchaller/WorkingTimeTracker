﻿namespace WorkingTimeTracker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBox_StartTime = new System.Windows.Forms.TextBox();
            this.textBox_EndTime = new System.Windows.Forms.TextBox();
            this.textBox_legal_time = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ExportToCSVButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.calenderweek_listBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
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
            // textBox_StartTime
            // 
            this.textBox_StartTime.Enabled = false;
            this.textBox_StartTime.Location = new System.Drawing.Point(971, 108);
            this.textBox_StartTime.Name = "textBox_StartTime";
            this.textBox_StartTime.Size = new System.Drawing.Size(54, 20);
            this.textBox_StartTime.TabIndex = 21;
            // 
            // textBox_EndTime
            // 
            this.textBox_EndTime.Enabled = false;
            this.textBox_EndTime.Location = new System.Drawing.Point(971, 134);
            this.textBox_EndTime.Name = "textBox_EndTime";
            this.textBox_EndTime.Size = new System.Drawing.Size(54, 20);
            this.textBox_EndTime.TabIndex = 22;
            // 
            // textBox_legal_time
            // 
            this.textBox_legal_time.Enabled = false;
            this.textBox_legal_time.Location = new System.Drawing.Point(971, 166);
            this.textBox_legal_time.Name = "textBox_legal_time";
            this.textBox_legal_time.Size = new System.Drawing.Size(54, 20);
            this.textBox_legal_time.TabIndex = 23;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(28, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(99, 277);
            this.listBox1.TabIndex = 24;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(262, 313);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(202, 32);
            this.UpdateButton.TabIndex = 25;
            this.UpdateButton.Text = "Update Date List";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Visible = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "label1";
            // 
            // ExportToCSVButton
            // 
            this.ExportToCSVButton.Location = new System.Drawing.Point(28, 314);
            this.ExportToCSVButton.Name = "ExportToCSVButton";
            this.ExportToCSVButton.Size = new System.Drawing.Size(213, 32);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 357);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calenderweek_listBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExportToCSVButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox_legal_time);
            this.Controls.Add(this.textBox_EndTime);
            this.Controls.Add(this.textBox_StartTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "WorkingTimeTracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
      private System.Windows.Forms.TextBox textBox_StartTime;
      private System.Windows.Forms.TextBox textBox_EndTime;
      private System.Windows.Forms.TextBox textBox_legal_time;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExportToCSVButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox calenderweek_listBox;
        private System.Windows.Forms.Label label3;
    }
}

