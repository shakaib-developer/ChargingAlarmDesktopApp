using BatteryFullAlarm.Properties;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Management;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BatteryFullAlarm
{
	public partial class BatteryFullIndicator : Form
	{
		private static BatteryFullIndicator obj = null;

		NAudio.Wave.Mp3FileReader mp3 = null;
		NAudio.Wave.DirectSoundOut output = null;
		int i = 0, tick = 8;
		bool canRunAlarm = true;
		bool isCharging = false;

		static readonly CancellationTokenSource cancellationToken = new CancellationTokenSource();

		public BatteryFullIndicator()
		{
			InitializeComponent();

			SystemEvents.PowerModeChanged += OnPowerModeChanged;
			canRunAlarm = true;
			//timer.Start();
			LoadIconAndText();
		}

		private void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
		{
			if (e.Mode == PowerModes.StatusChange) // StatusChange occurs when power state changes
			{
				canRunAlarm = true;
			}
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

			batteryPercentage.Value = Convert.ToInt32(Charge.Replace("%", ""));

			string minLimitString = Settings.Default.minChargeLimit.ToString();
			string maxLimitString = Settings.Default.maxChargeLimit.ToString();
			int minLimit = Settings.Default.minChargeLimit;
			int maxLimit = Settings.Default.maxChargeLimit;

			//canRunAlarm = (lineStatus.Contains("Online") && (!isCharging)) || (!lineStatus.Contains("Online") && isCharging); // [Is charging now and was not charging (Is Pluggedin now)] OR [Is not charging now and was charging (Is Unplugged now)]

			if (!lineStatus.Contains("Online"))
			{
				isCharging = false;

				lblBatteryPercent.Text = "Battery : " + Charge;
				if (btnSilent.BackgroundImage.Size.Width == Resources.speaker.Size.Width) // Repeat
				{
					if (batteryPercentage.Value <= minLimit && (i % tick == 0))
					//if (Charge.Contains(minLimit) && (i % 5 == 0))
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
					if (canRunAlarm && batteryPercentage.Value <= minLimit && (i % tick == 0))
					//if (canRunAlarm && Charge.Contains(minLimit) && (i % 5 == 0))
					{
						RingBatteryLowAlarm();
						canRunAlarm = false; // Only ring once
					}
				}
			}

			else if (lineStatus.Contains("Online"))
			{
				isCharging = true;
				lblBatteryPercent.Text = "Charging : " + Charge;

				if (btnSilent.BackgroundImage.Size.Width == Resources.speaker.Size.Width) // Repeat
				{
					if (batteryPercentage.Value >= maxLimit && (i % tick == 0))
					//if (Charge.Contains(maxLimit) && (i % 5 == 0))
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
						if (batteryPercentage.Value >= maxLimit && (i % tick == 0))
						//if (Charge.Contains(maxLimit) && (i % 5 == 0))
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
			Task.Run(() =>
			{
				//Console.Beep(2000, 1000);

				SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
				speechSynthesizer.Speak($"Battery is low ({batteryPercentage.Value}%). Please connect your laptop to a charger.");
				//speechSynthesizer.Speak("Battery Getting Low, Please plug in the charger.");
				speechSynthesizer.Dispose();
			});

			//mp3 = new NAudio.Wave.Mp3FileReader(@"C:\Program Files (x86)\Shakaib Gujjar\Battery Full Alarm\Low.mp3");
			//output = new NAudio.Wave.DirectSoundOut();
			//output.Init(new NAudio.Wave.WaveChannel32(mp3));
			//output.Play();
		}

		private void RingBatteryFullAlarm()
		{
			Task.Run(() =>
			{
				//Console.Beep(2000, 1000);

				SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
				speechSynthesizer.Speak($"Battery is full ({batteryPercentage.Value}%). Please disconnect your laptop from the charger.");
				//speechSynthesizer.Speak("Battery has been charged, Please unplug the charger.");
				speechSynthesizer.Dispose();
			});

			//mp3 = new NAudio.Wave.Mp3FileReader(@"C:\Program Files (x86)\Shakaib Gujjar\Battery Full Alarm\Charged.mp3");
			//output = new NAudio.Wave.DirectSoundOut();
			//output.Init(new NAudio.Wave.WaveChannel32(mp3));
			//output.Play();
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
			//if (btnSilent.BackgroundImage.Size.Width == Resources.speaker.Size.Width) // Repeat
			if (Settings.Default.btnImage == "speaker")
			{
				btnSilent.BackgroundImage = Resources.silent;
				lblStatus.Text = "Silent";

				// Update Properties in Shared Preferences
				Settings.Default.btnImage = "silent";
				Settings.Default.btnText = "Silent";
				Settings.Default.Save();
			}
			//else if (btnSilent.BackgroundImage.Size.Width == Resources.silent.Size.Width) // Silent
			else if (Settings.Default.btnImage == "silent")
			{
				btnSilent.BackgroundImage = Resources.speakonce;
				lblStatus.Text = "Ring Once";
				canRunAlarm = true;

				// Update Properties in Shared Preferences
				Settings.Default.btnImage = "speakonce";
				Settings.Default.btnText = "Ring Once";
				Settings.Default.Save();
			}
			else // Once
			{
				btnSilent.BackgroundImage = Resources.speaker;
				lblStatus.Text = "Repeat Ring";

				// Update Properties in Shared Preferences
				Settings.Default.btnImage = "speaker";
				Settings.Default.btnText = "Repeat Ring";
				Settings.Default.Save();
			}
			i = 0;
		}

		private void LoadIconAndText()
		{
			if (Settings.Default.btnImage == "speaker")
			{
				btnSilent.BackgroundImage = Resources.speaker;
				lblStatus.Text = "Repeat Ring";
			}
			else if (Settings.Default.btnImage == "silent")
			{
				btnSilent.BackgroundImage = Resources.silent;
				lblStatus.Text = "Silent";
				canRunAlarm = true;
			}
			else // Once
			{
				btnSilent.BackgroundImage = Resources.speakonce;
				lblStatus.Text = "Ring Once";
			}
		}

		private void settingMenu_Click(object sender, EventArgs e)
		{
			string btnImageOld = Settings.Default.btnImage, btnTextOld = Settings.Default.btnText, minLimitOld = Settings.Default.minChargeLimit.ToString(), maxLimitOld = Settings.Default.maxChargeLimit.ToString();

			SettingsForm setting = new SettingsForm();
			setting.ShowDialog();

			string btnImageNew = Settings.Default.btnImage, btnTextNew = Settings.Default.btnText, minLimitNew = Settings.Default.minChargeLimit.ToString(), maxLimitNew = Settings.Default.maxChargeLimit.ToString();
			if (btnImageNew == "speaker")
			{
				if (btnImageOld != btnImageNew || btnTextOld != btnTextNew || minLimitOld != minLimitNew || maxLimitOld != maxLimitNew)
				{
					canRunAlarm = true;
				}
			}
		}
	}
}
