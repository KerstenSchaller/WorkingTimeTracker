namespace WorkingTimeTracker
{
    partial class SetStandartWorkingTimePopup
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
            this.button_Set = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.textBox_workingTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Set
            // 
            this.button_Set.Location = new System.Drawing.Point(27, 78);
            this.button_Set.Name = "button_Set";
            this.button_Set.Size = new System.Drawing.Size(75, 23);
            this.button_Set.TabIndex = 0;
            this.button_Set.Text = "Set";
            this.button_Set.UseVisualStyleBackColor = true;
            this.button_Set.Click += new System.EventHandler(this.button_Set_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(182, 78);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // textBox_workingTime
            // 
            this.textBox_workingTime.Location = new System.Drawing.Point(65, 40);
            this.textBox_workingTime.Name = "textBox_workingTime";
            this.textBox_workingTime.Size = new System.Drawing.Size(156, 20);
            this.textBox_workingTime.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input standart working time in format hour.minute";
            // 
            // SetStandartWorkingTimePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 113);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_workingTime);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_Set);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SetStandartWorkingTimePopup";
            this.Text = "Set Standart Working Time";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Set;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.TextBox textBox_workingTime;
        private System.Windows.Forms.Label label1;
    }
}