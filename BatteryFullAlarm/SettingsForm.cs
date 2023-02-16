using BatteryFullAlarm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatteryFullAlarm
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update Properties in Shared Preferences
            Settings.Default.minChargeLimit = string.IsNullOrEmpty(txtMinCharge.Text) ? 35 : Convert.ToInt32(txtMinCharge.Text);
            Settings.Default.maxChargeLimit = string.IsNullOrEmpty(txtMaxCharge.Text) ? 100 : Convert.ToInt32(txtMaxCharge.Text);
            Settings.Default.Save();

            this.Dispose();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            txtMinCharge.Text = Settings.Default.minChargeLimit.ToString();
            txtMaxCharge.Text = Settings.Default.maxChargeLimit.ToString();
        }
    }
}
