using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Emulating_Device_Manager.DeviceDescription;

namespace Emulating_Device_Manager
{
    public partial class Form1 : Form
    {
        private List<Device> _devices;
        public Form1()
        {
            InitializeComponent();
            _devices = new Searcher().FindDevices();
            foreach (var device in _devices)
            {
                DevicesListBox.Items.Add(device.Name ?? string.Empty);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DevicesListBox_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(DevicesListBox.SelectedItems);
            var hitInfo = DevicesListBox.HitTest(e.Location);
            if (hitInfo.Location == ListViewHitTestLocations.None) return;
            DeviceInfoTextBox.Text = _devices[DevicesListBox.SelectedItems[0].Index].ToString();
            StatusButton_SetText();
        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            _devices[DevicesListBox.SelectedItems[0].Index].ChangeState();
            StatusButton_SetText();
        }

        private void StatusButton_SetText()
        {
            statusButton.Text = _devices[DevicesListBox.SelectedItems[0].Index].IsEnabled ? Device.DisableMethod : Device.EnableMethod;
        }
    }
}
