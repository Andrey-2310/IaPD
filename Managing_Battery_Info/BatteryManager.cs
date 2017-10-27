using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ManagingBatteryInfo
{
    public class BatteryManager
    {
        public PowerLineStatus PowerLineStatus { get; set; }
        public PowerLineStatus PreviousPowerLineStatus { get; set; }
        public string PercentBattery { get; set; }
        public string WorkTime { get; set; }
        public bool StartApp { get; set; }
        public int PreviousScreenTime { get; set; }
        public int DefaultScreenTime { get; set; }

        public void Init()
        {
            StartApp = true;
            PreviousScreenTime = GetScreenTime();
            DefaultScreenTime = GetScreenTime();
            UpdateData();
        }

        public void UpdateData()
        {
            PowerLineStatus = SystemInformation.PowerStatus.PowerLineStatus;
            if (StartApp)
            {
                PreviousPowerLineStatus = PowerLineStatus;
                StartApp = false;
            }
            PercentBattery = (SystemInformation.PowerStatus.BatteryLifePercent * 100).ToString(CultureInfo.CurrentCulture);
            if (PowerLineStatus == PowerLineStatus.Offline)
            {
                var calcLife = SystemInformation.PowerStatus.BatteryLifeRemaining;
                if (calcLife != -1)
                {
                    var span = new TimeSpan(0, 0, calcLife);
                    WorkTime = span.ToString("g");
                }
                else WorkTime = "Calculating time...";
            }
            else
            {
                WorkTime = "From AC adapter.";
            }
        }

        public void SetDisplayOff(int value)
        {
            var p = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = "/c powercfg /x -monitor-timeout-dc " + value
                }
            };
            p.Start();
            p.WaitForExit();
            p.Close();
        }

        public int GetScreenTime()
        {
            var procCmd = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/c powercfg /q"
                }
            };
            procCmd.Start();
            var powerConfig = procCmd.StandardOutput.ReadToEnd();
            var lastString = new Regex("VIDEOIDLE.*\\n.*\\n.*\\n.*\\n.*\\n.*\\n.*");
            var videoIdle = lastString.Match(powerConfig).Value;
            var batteryState = videoIdle.Substring(videoIdle.Length - 11).TrimEnd();
            return Convert.ToInt32(batteryState, 16) / 60;
        }

    }
}
