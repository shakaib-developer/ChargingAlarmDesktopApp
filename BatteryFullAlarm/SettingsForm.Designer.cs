namespace BatteryFullAlarm
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtMinCharge = new System.Windows.Forms.TextBox();
            this.txtMaxCharge = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblMinCharge = new System.Windows.Forms.Label();
            this.lblMaxCharge = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(102, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(84, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Settings";
            // 
            // txtMinCharge
            // 
            this.txtMinCharge.Location = new System.Drawing.Point(38, 106);
            this.txtMinCharge.Name = "txtMinCharge";
            this.txtMinCharge.Size = new System.Drawing.Size(218, 20);
            this.txtMinCharge.TabIndex = 1;
            // 
            // txtMaxCharge
            // 
            this.txtMaxCharge.Location = new System.Drawing.Point(38, 175);
            this.txtMaxCharge.Name = "txtMaxCharge";
            this.txtMaxCharge.Size = new System.Drawing.Size(218, 20);
            this.txtMaxCharge.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(181, 217);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 38);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblMinCharge
            // 
            this.lblMinCharge.AutoSize = true;
            this.lblMinCharge.Location = new System.Drawing.Point(35, 88);
            this.lblMinCharge.Name = "lblMinCharge";
            this.lblMinCharge.Size = new System.Drawing.Size(109, 13);
            this.lblMinCharge.TabIndex = 4;
            this.lblMinCharge.Text = "Minimum Charge Limit";
            // 
            // lblMaxCharge
            // 
            this.lblMaxCharge.AutoSize = true;
            this.lblMaxCharge.Location = new System.Drawing.Point(35, 157);
            this.lblMaxCharge.Name = "lblMaxCharge";
            this.lblMaxCharge.Size = new System.Drawing.Size(112, 13);
            this.lblMaxCharge.TabIndex = 5;
            this.lblMaxCharge.Text = "Maximum Charge Limit";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 278);
            this.Controls.Add(this.lblMaxCharge);
            this.Controls.Add(this.lblMinCharge);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtMaxCharge);
            this.Controls.Add(this.txtMinCharge);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtMinCharge;
        private System.Windows.Forms.TextBox txtMaxCharge;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblMinCharge;
        private System.Windows.Forms.Label lblMaxCharge;
    }
}