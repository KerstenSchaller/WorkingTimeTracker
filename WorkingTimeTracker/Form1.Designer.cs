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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 347);
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
   }
}

