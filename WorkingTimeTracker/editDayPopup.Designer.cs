namespace WorkingTimeTracker
{
    partial class editDayPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DateLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.Starttimetextbox = new System.Windows.Forms.TextBox();
            this.EndtimeTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_no30minBreak = new System.Windows.Forms.CheckBox();
            this.checkBox_No15minbreak = new System.Windows.Forms.CheckBox();
            this.checkBox_SickAbsence = new System.Windows.Forms.CheckBox();
            this.checkBox_VacationAbsence = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(12, 20);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(30, 13);
            this.DateLabel.TabIndex = 0;
            this.DateLabel.Text = "Date";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 238);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(260, 47);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save and Close";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Starttimetextbox
            // 
            this.Starttimetextbox.Location = new System.Drawing.Point(93, 47);
            this.Starttimetextbox.Name = "Starttimetextbox";
            this.Starttimetextbox.Size = new System.Drawing.Size(179, 20);
            this.Starttimetextbox.TabIndex = 2;
            this.Starttimetextbox.TextChanged += new System.EventHandler(this.Starttimetextbox_TextChanged);
            // 
            // EndtimeTextbox
            // 
            this.EndtimeTextbox.Location = new System.Drawing.Point(93, 104);
            this.EndtimeTextbox.Name = "EndtimeTextbox";
            this.EndtimeTextbox.Size = new System.Drawing.Size(179, 20);
            this.EndtimeTextbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Starttime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Endtime";
            // 
            // checkBox_no30minBreak
            // 
            this.checkBox_no30minBreak.AutoSize = true;
            this.checkBox_no30minBreak.Location = new System.Drawing.Point(158, 154);
            this.checkBox_no30minBreak.Name = "checkBox_no30minBreak";
            this.checkBox_no30minBreak.Size = new System.Drawing.Size(104, 17);
            this.checkBox_no30minBreak.TabIndex = 8;
            this.checkBox_no30minBreak.Text = "No 30 min break";
            this.checkBox_no30minBreak.UseVisualStyleBackColor = true;
            this.checkBox_no30minBreak.CheckedChanged += new System.EventHandler(this.checkBox_no30minBreak_CheckedChanged);
            // 
            // checkBox_No15minbreak
            // 
            this.checkBox_No15minbreak.AutoSize = true;
            this.checkBox_No15minbreak.Location = new System.Drawing.Point(158, 192);
            this.checkBox_No15minbreak.Name = "checkBox_No15minbreak";
            this.checkBox_No15minbreak.Size = new System.Drawing.Size(104, 17);
            this.checkBox_No15minbreak.TabIndex = 9;
            this.checkBox_No15minbreak.Text = "No 15 min break";
            this.checkBox_No15minbreak.UseVisualStyleBackColor = true;
            this.checkBox_No15minbreak.CheckedChanged += new System.EventHandler(this.checkBox_No15minbreak_CheckedChanged);
            // 
            // checkBox_SickAbsence
            // 
            this.checkBox_SickAbsence.AutoSize = true;
            this.checkBox_SickAbsence.Location = new System.Drawing.Point(15, 154);
            this.checkBox_SickAbsence.Name = "checkBox_SickAbsence";
            this.checkBox_SickAbsence.Size = new System.Drawing.Size(122, 17);
            this.checkBox_SickAbsence.TabIndex = 10;
            this.checkBox_SickAbsence.Text = "Absent through Sick";
            this.checkBox_SickAbsence.UseVisualStyleBackColor = true;
            this.checkBox_SickAbsence.CheckedChanged += new System.EventHandler(this.checkBox_SickAbsence_CheckedChanged);
            // 
            // checkBox_VacationAbsence
            // 
            this.checkBox_VacationAbsence.AutoSize = true;
            this.checkBox_VacationAbsence.Location = new System.Drawing.Point(15, 192);
            this.checkBox_VacationAbsence.Name = "checkBox_VacationAbsence";
            this.checkBox_VacationAbsence.Size = new System.Drawing.Size(142, 17);
            this.checkBox_VacationAbsence.TabIndex = 11;
            this.checkBox_VacationAbsence.Text = "Absent through vacation";
            this.checkBox_VacationAbsence.UseVisualStyleBackColor = true;
            this.checkBox_VacationAbsence.CheckedChanged += new System.EventHandler(this.checkBox_VacationAbsence_CheckedChanged);
            // 
            // editDayPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 297);
            this.Controls.Add(this.checkBox_VacationAbsence);
            this.Controls.Add(this.checkBox_SickAbsence);
            this.Controls.Add(this.checkBox_No15minbreak);
            this.Controls.Add(this.checkBox_no30minBreak);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndtimeTextbox);
            this.Controls.Add(this.Starttimetextbox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DateLabel);
            this.Name = "editDayPopup";
            this.Text = "Edit individual Day";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox Starttimetextbox;
        private System.Windows.Forms.TextBox EndtimeTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_no30minBreak;
        private System.Windows.Forms.CheckBox checkBox_No15minbreak;
        private System.Windows.Forms.CheckBox checkBox_SickAbsence;
        private System.Windows.Forms.CheckBox checkBox_VacationAbsence;
    }
}