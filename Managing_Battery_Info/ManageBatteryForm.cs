using System;
using System.Windows.Forms;

namespace ManagingBatteryInfo
{
    public partial class ManageBatteryForm : Form
    {
        private readonly BatteryManager _manager = new BatteryManager();
        public ManageBatteryForm()
        {
            InitializeComponent();
        }

        public void BatteryLoading(object sender, EventArgs e)
        {
            _manager.Init();
            if (_manager.PowerLineStatus == PowerLineStatus.Online)
            {
                timeOutBox.Enabled = false;
            }
            UpdateBattery(null, null);
            TimerConfiguration();
        }

        private void TimerConfiguration() 
        {
            updateTimer.Tick += UpdateBattery;
            updateTimer.Interval = 1000;
            updateTimer.Start();
        }

        private void UpdateBattery(object sender, EventArgs e)
        {
            _manager.UpdateData();
            percentageProgressBar.Value = Convert.ToInt32(_manager.PercentBattery);
            timeLeftTextBox.Text = _manager.WorkTime;
            statTextBox.Text = _manager.PowerLineStatus.ToString();
            percentageLabel.Text = _manager.PercentBattery + @"%";
            statTextBox.Text = _manager.PowerLineStatus.ToString();
            if (_manager.PreviousPowerLineStatus != _manager.PowerLineStatus)
            {
                if (_manager.PreviousPowerLineStatus == PowerLineStatus.Offline)
                {
                    timeOutBox.Enabled = false;
                }
                else
                {
                    timeOutBox.Enabled = true;
                }
                _manager.PreviousPowerLineStatus = _manager.PowerLineStatus;
            }
        }

        private void AppClosing(object sender, FormClosingEventArgs e)
        {
            _manager.SetDisplayOff(_manager.DefaultScreenTime);
        }

        private void timeOutBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _manager.SetDisplayOff(int.Parse(timeOutBox.SelectedItem.ToString()));
        }
    }
}
