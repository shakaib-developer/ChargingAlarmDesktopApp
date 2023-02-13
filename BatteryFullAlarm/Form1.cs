using BatteryFullAlarm.Properties;
using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatteryFullAlarm
{
    public partial class BatteryFullIndicator : Form
    {
        private static BatteryFullIndicator obj = null;

        NAudio.Wave.Mp3FileReader mp3 = null;
        NAudio.Wave.DirectSoundOut output = null;
        int i = 0;
        bool canRunAlarm = true;

        static readonly CancellationTokenSource cancellationToken = new CancellationTokenSource();

        public BatteryFullIndicator()
        {
            InitializeComponent();
            timer.Start();
        }

        public static BatteryFullIndicator getObject()
        {
            if (obj == null)
            {
                obj = new BatteryFullIndicator();
            }
            return obj;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            String ChargeStatus, Charge, lineStatus;

            PowerStatus status = SystemInformation.PowerStatus;
            ChargeStatus = status.BatteryChargeStatus.ToString();

            Charge = status.BatteryLifePercent.ToString("P0");
            lineStatus = status.PowerLineStatus.ToString();

            label1.Text = status.BatteryFullLifetime.ToString();


            batteryPercentage.Value = Convert.ToInt32(Charge.Replace("%", ""));

            if (!lineStatus.Contains("Online"))
            {
                lblBatteryPercent.Text = "Battery : " + Charge;
                if (btnSilent.BackgroundImage.Size.Width == Resources.speaker.Size.Width) // Repeat
                {
                    if (Charge.Contains("35") && (i % 5 == 0))
                    //if (Charge.Contains("5") && (i % 5 == 0))
                    {
                        RingBatteryLowAlarm();
                        //Task.Run(async ()=> RingBatteryLowAlarm());
                    }
                }
                else if (btnSilent.BackgroundImage.Size.Width == Resources.silent.Size.Width) // Silent
                {
                    // App is Silent Do nothing
                }
                else // Once
                {
                    if (canRunAlarm)
                    {
                        if (Charge.Contains("35") && (i % 5 == 0))
                        //if (Charge.Contains("5") && (i % 5 == 0))
                        {
                            RingBatteryLowAlarm();
                            //Task.Run(async ()=> RingBatteryLowAlarm());
                            canRunAlarm = false;
                        }
                    }
                }
            }

            else if (lineStatus.Contains("Online"))
            {
                lblBatteryPercent.Text = "Charging : " + Charge;

                if (btnSilent.BackgroundImage.Size.Width == Resources.speaker.Size.Width) // Repeat
                {
                    if (Charge.Contains("100") && (i % 5 == 0))
                    {
                        RingBatteryFullAlarm();
                    }
                }
                else if (btnSilent.BackgroundImage.Size.Width == Resources.silent.Size.Width) // Silent
                {
                    // App is Silent Do nothing
                }
                else // Once
                {
                    if (canRunAlarm)
                    {
                        if (Charge.Contains("100") && (i % 5 == 0))
                        {
                            RingBatteryFullAlarm();

                            canRunAlarm = false;
                        }
                    }
                }
            }

            //else
            //{
            //    lblBatteryPercent.Text = "Charging : " + Charge;
            //}

            i++;
        }

        private void RingBatteryLowAlarm()
        {
            Console.Beep(2000, 1000);

            mp3 = new NAudio.Wave.Mp3FileReader(@"C:\Program Files (x86)\Shakaib Gujjar\Battery Full Alarm\Low.mp3");
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(mp3));
            output.Play();
        }

        private void RingBatteryFullAlarm()
        {
            Console.Beep(2000, 1000);

            mp3 = new NAudio.Wave.Mp3FileReader(@"C:\Program Files (x86)\Shakaib Gujjar\Battery Full Alarm\Charged.mp3");
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(mp3));
            output.Play();
        }

        private void btnSilent_Click(object sender, EventArgs e)
        {
            UpdateIconAndText();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            UpdateIconAndText();
        }

        private void UpdateIconAndText()
        {
            if (btnSilent.BackgroundImage.Size.Width == Resources.speaker.Size.Width) // Repeat
            {
                btnSilent.BackgroundImage = Resources.silent;
                lblStatus.Text = "Silent";
            }
            else if (btnSilent.BackgroundImage.Size.Width == Resources.silent.Size.Width) // Silent
            {
                btnSilent.BackgroundImage = Resources.speakonce;
                lblStatus.Text = "Ring Once";
                canRunAlarm = true;
            }
            else // Once
            {
                btnSilent.BackgroundImage = Resources.speaker;
                lblStatus.Text = "Repeat Ring";
            }
            i = 0;
        }
    }
}
