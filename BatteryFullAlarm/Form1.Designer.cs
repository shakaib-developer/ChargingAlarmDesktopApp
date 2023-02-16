namespace BatteryFullAlarm
{
    partial class BatteryFullIndicator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatteryFullIndicator));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblBatteryPercent = new System.Windows.Forms.Label();
            this.btnSilent = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.batteryPercentage = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblBatteryPercent
            // 
            this.lblBatteryPercent.AutoSize = true;
            this.lblBatteryPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblBatteryPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatteryPercent.Location = new System.Drawing.Point(12, 48);
            this.lblBatteryPercent.Name = "lblBatteryPercent";
            this.lblBatteryPercent.Size = new System.Drawing.Size(168, 37);
            this.lblBatteryPercent.TabIndex = 10;
            this.lblBatteryPercent.Text = "Loading ...";
            // 
            // btnSilent
            // 
            this.btnSilent.BackColor = System.Drawing.Color.White;
            this.btnSilent.BackgroundImage = global::BatteryFullAlarm.Properties.Resources.speakonce;
            this.btnSilent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSilent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSilent.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnSilent.Location = new System.Drawing.Point(19, 163);
            this.btnSilent.Name = "btnSilent";
            this.btnSilent.Size = new System.Drawing.Size(46, 43);
            this.btnSilent.TabIndex = 1;
            this.btnSilent.UseVisualStyleBackColor = false;
            this.btnSilent.Click += new System.EventHandler(this.btnSilent_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(71, 176);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(75, 17);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Ring Once";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // batteryPercentage
            // 
            this.batteryPercentage.BackColor = System.Drawing.SystemColors.Control;
            this.batteryPercentage.Location = new System.Drawing.Point(19, 102);
            this.batteryPercentage.Name = "batteryPercentage";
            this.batteryPercentage.Size = new System.Drawing.Size(295, 42);
            this.batteryPercentage.TabIndex = 3;
            this.batteryPercentage.Value = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(330, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingMenu
            // 
            this.settingMenu.Name = "settingMenu";
            this.settingMenu.Size = new System.Drawing.Size(56, 20);
            this.settingMenu.Text = "&Setting";
            this.settingMenu.Click += new System.EventHandler(this.settingMenu_Click);
            // 
            // BatteryFullIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(330, 219);
            this.Controls.Add(this.lblBatteryPercent);
            this.Controls.Add(this.batteryPercentage);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSilent);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "BatteryFullIndicator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battery Full Indicator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblBatteryPercent;
        private System.Windows.Forms.Button btnSilent;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar batteryPercentage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingMenu;
    }
}

