using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace Emulating_Device_Manager.DeviceDescription
{
    class Device
    {
        private const string NameProperty = "Name";
        private const string ClassGuidProperty = "ClassGuid";
        private const string HardwareIdProperty = "HardwareID";
        private const string ManufacturerProperty = "Manufacturer";
        private const string CaptionProperty = "Caption";
        private const string DevicePathProperty = "DeviceID";
        private const string DriverRelatedProperty = "Win32_SystemDriver";
        public static string DisableMethod = "Disable";
        public static string EnableMethod = "Enable";

        public string Name { get; }
        public string Caption { get; }
        public object ClassGuid { get; }
        public string DevicePath { get; }
        public List<Driver> Drivers { get; }
        public string[] HardwareId { get; }
        public string Manufacturer { get; }
        public bool IsEnabled { get; set; }

        public Device(ManagementObject managementObject)
        {
            Name = managementObject[NameProperty]?.ToString() ?? string.Empty;
            Caption = managementObject[CaptionProperty]?.ToString() ?? string.Empty;
            ClassGuid = managementObject[ClassGuidProperty]?.ToString() ?? string.Empty;
            DevicePath = managementObject[DevicePathProperty]?.ToString() ?? string.Empty;
            HardwareId = (string[])managementObject[HardwareIdProperty];
            Manufacturer = managementObject[ManufacturerProperty]?.ToString() ?? string.Empty;
            Drivers = new List<Driver>();
            IsEnabled = true;
            foreach (var driver in managementObject.GetRelated(DriverRelatedProperty))
            {
                Drivers.Add(new Driver(driver));
            }
        }

        public override string ToString()
        {
            var driversDescription = Drivers.Aggregate("", (current, driver) => string.Concat(current, driver.ToString()));
            return "Name: " + Name + "\r\n" + "HardwareID: " + string.Join(" ", HardwareId) + "Caption: " + Caption +
                   "\r\n" + "ClassGuid: " + ClassGuid + "\r\n" + "DevicePath: " + DevicePath + "\r\n" + "Manufacturer: " +
                   Manufacturer + "\r\n" + "_____________________________" + "\r\n" + driversDescription;
        }

        public void ChangeState()
        {
            Console.WriteLine(IsEnabled);
            var device = new ManagementObjectSearcher("SELECT * FROM Win32_PNPEntity").Get().OfType<ManagementObject>()
                .FirstOrDefault(x => x[DevicePathProperty].ToString().Equals(DevicePath));
            device?.InvokeMethod(IsEnabled ? DisableMethod : EnableMethod, new object[] { false });
            IsEnabled = !IsEnabled;
        }
    }
}
