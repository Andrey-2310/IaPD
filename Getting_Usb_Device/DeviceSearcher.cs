using System.Collections.Generic;
using System.Linq;
using System.IO;
using MediaDevices;

namespace Getting_USB_Devices
{
    class DeviceSearcher
    {
        public List<UsbDevice> GetDevices()
        {
            List<UsbDevice> devices = new List<UsbDevice>();
            List<DriveInfo> drives = DriveInfo.GetDrives().Where(d => d.IsReady && d.DriveType == DriveType.Removable).ToList();
            List<MediaDevice> mtpDevices = MediaDevice.GetDevices().ToList();
            foreach (MediaDevice device in mtpDevices)
            {
                device.Connect();
                if (device.DeviceType != DeviceType.Generic)
                {
                    devices.Add(new UsbDevice(device.FriendlyName, null, null, null, true));
                }
            }
            foreach (DriveInfo drive in drives)
            {
                devices.Add(new UsbDevice(drive.Name, BytesToMegaBytesString(drive.TotalFreeSpace),
                    BytesToMegaBytesString(drive.TotalSize - drive.TotalFreeSpace),
                    BytesToMegaBytesString(drive.TotalSize), false));
            }
            return devices;
        }

        private string BytesToMegaBytesString(long value)
        {
            double megaBytes = (value / 1024) / 1024;
            return megaBytes.ToString() + " MB";
        }
    }
}
