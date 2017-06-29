namespace WorkingTimeTracker
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.burger_button = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.vacationButton = new System.Windows.Forms.Button();
            this.SickButton = new System.Windows.Forms.Button();
            this.setWorkTimeButton = new System.Windows.Forms.Button();
            this.resetDayButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.setStartButton = new System.Windows.Forms.Button();
            this.setEndButton = new System.Windows.Forms.Button();
            this.setLegalWorktimeButton = new System.Windows.Forms.Button();
            this.textBox_StartTime = new System.Windows.Forms.TextBox();
            this.textBox_EndTime = new System.Windows.Forms.TextBox();
            this.textBox_legal_time = new System.Windows.Forms.TextBox();
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "label6";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(32, 46);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(536, 252);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // burger_button
            // 
            this.burger_button.Location = new System.Drawing.Point(574, 46);
            this.burger_button.Name = "burger_button";
            this.burger_button.Size = new System.Drawing.Size(28, 251);
            this.burger_button.TabIndex = 10;
            this.burger_button.TabStop = false;
            this.burger_button.Text = "__ __ __";
            this.burger_button.UseVisualStyleBackColor = true;
            this.burger_button.Click += new System.EventHandler(this.burger_button_Click);
            // 
            // editButton
            // 
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(608, 46);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(169, 23);
            this.editButton.TabIndex = 11;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // vacationButton
            // 
            this.vacationButton.Enabled = false;
            this.vacationButton.Location = new System.Drawing.Point(608, 75);
            this.vacationButton.Name = "vacationButton";
            this.vacationButton.Size = new System.Drawing.Size(169, 23);
            this.vacationButton.TabIndex = 12;
            this.vacationButton.Text = "Vacation";
            this.vacationButton.UseVisualStyleBackColor = true;
            this.vacationButton.Click += new System.EventHandler(this.vacationButton_Click);
            // 
            // SickButton
            // 
            this.SickButton.Enabled = false;
            this.SickButton.Location = new System.Drawing.Point(608, 104);
            this.SickButton.Name = "SickButton";
            this.SickButton.Size = new System.Drawing.Size(169, 23);
            this.SickButton.TabIndex = 13;
            this.SickButton.Text = "Sick";
            this.SickButton.UseVisualStyleBackColor = true;
            this.SickButton.Click += new System.EventHandler(this.SickButton_Click);
            // 
            // setWorkTimeButton
            // 
            this.setWorkTimeButton.Enabled = false;
            this.setWorkTimeButton.Location = new System.Drawing.Point(608, 134);
            this.setWorkTimeButton.Name = "setWorkTimeButton";
            this.setWorkTimeButton.Size = new System.Drawing.Size(169, 23);
            this.setWorkTimeButton.TabIndex = 14;
            this.setWorkTimeButton.Text = "set Times individually";
            this.setWorkTimeButton.UseVisualStyleBackColor = true;
            this.setWorkTimeButton.Click += new System.EventHandler(this.setWorkTimeButton_Click);
            // 
            // resetDayButton
            // 
            this.resetDayButton.Enabled = false;
            this.resetDayButton.Location = new System.Drawing.Point(608, 163);
            this.resetDayButton.Name = "resetDayButton";
            this.resetDayButton.Size = new System.Drawing.Size(169, 23);
            this.resetDayButton.TabIndex = 15;
            this.resetDayButton.Text = "Reset Day";
            this.resetDayButton.UseVisualStyleBackColor = true;
            this.resetDayButton.Click += new System.EventHandler(this.resetDayButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(608, 192);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(169, 23);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // setStartButton
            // 
            this.setStartButton.Enabled = false;
            this.setStartButton.Location = new System.Drawing.Point(783, 104);
            this.setStartButton.Name = "setStartButton";
            this.setStartButton.Size = new System.Drawing.Size(169, 23);
            this.setStartButton.TabIndex = 17;
            this.setStartButton.Text = "set StartTime";
            this.setStartButton.UseVisualStyleBackColor = true;
            this.setStartButton.Click += new System.EventHandler(this.setStartButton_Click);
            // 
            // setEndButton
            // 
            this.setEndButton.Enabled = false;
            this.setEndButton.Location = new System.Drawing.Point(783, 134);
            this.setEndButton.Name = "setEndButton";
            this.setEndButton.Size = new System.Drawing.Size(169, 23);
            this.setEndButton.TabIndex = 18;
            this.setEndButton.Text = "set End Time";
            this.setEndButton.UseVisualStyleBackColor = true;
            this.setEndButton.Click += new System.EventHandler(this.setEndButton_Click);
            // 
            // setLegalWorktimeButton
            // 
            this.setLegalWorktimeButton.Enabled = false;
            this.setLegalWorktimeButton.Location = new System.Drawing.Point(783, 163);
            this.setLegalWorktimeButton.Name = "setLegalWorktimeButton";
            this.setLegalWorktimeButton.Size = new System.Drawing.Size(169, 23);
            this.setLegalWorktimeButton.TabIndex = 19;
            this.setLegalWorktimeButton.Text = "set legal Worktime";
            this.setLegalWorktimeButton.UseVisualStyleBackColor = true;
            this.setLegalWorktimeButton.Click += new System.EventHandler(this.setLegalWorktimeButton_Click_1);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 347);
            this.Controls.Add(this.textBox_legal_time);
            this.Controls.Add(this.textBox_EndTime);
            this.Controls.Add(this.textBox_StartTime);
            this.Controls.Add(this.setLegalWorktimeButton);
            this.Controls.Add(this.setEndButton);
            this.Controls.Add(this.setStartButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.resetDayButton);
            this.Controls.Add(this.setWorkTimeButton);
            this.Controls.Add(this.SickButton);
            this.Controls.Add(this.vacationButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.burger_button);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button burger_button;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button vacationButton;
        private System.Windows.Forms.Button SickButton;
        private System.Windows.Forms.Button setWorkTimeButton;
        private System.Windows.Forms.Button resetDayButton;
        private System.Windows.Forms.Button SaveButton;
      private System.Windows.Forms.Button setStartButton;
      private System.Windows.Forms.Button setEndButton;
      private System.Windows.Forms.Button setLegalWorktimeButton;
      private System.Windows.Forms.TextBox textBox_StartTime;
      private System.Windows.Forms.TextBox textBox_EndTime;
      private System.Windows.Forms.TextBox textBox_legal_time;
   }
}

