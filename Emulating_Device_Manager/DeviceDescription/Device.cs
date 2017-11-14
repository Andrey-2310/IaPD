using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace Emulating_Device_Manager.DeviceDescription
{
    class Device : IDeviceOptions
    {
        private const string ClassGuidProperty = "ClassGuid";
        private const string HardwareIdProperty = "HardwareID";
        private const string ManufacturerProperty = "Manufacturer";
        private const string CaptionProperty = "Caption";
        private const string DevicePathProperty = "DeviceID";
        private const string DriverRelatedProperty = "Win32_SystemDriver";
        private const string DisableMethod = "Disable";
        private const string EnableMethod = "Enable";

        public object Caption { get; }
        private object ClassGuid { get; }
        private object DevicePath { get; }
        private List<Driver> Drivers { get; }
        private string[] HardwareId { get; }
        private object Manufactirer { get; }

        public Device(ManagementObject managementObject)
        {
            Caption = managementObject[CaptionProperty];
            ClassGuid = managementObject[ClassGuidProperty];
            DevicePath = managementObject[DevicePathProperty];
            HardwareId = (string[])managementObject[HardwareIdProperty];
            Manufactirer = managementObject[ManufacturerProperty];
            Drivers = new List<Driver>();
            foreach (var driver in managementObject.GetRelated(DriverRelatedProperty))
            {
                Drivers.Add(new Driver(driver));
            }
        }

        public override string ToString()
        {
            foreach (var driver in Drivers)
            {
                Console.WriteLine(driver.ToString());
            }
            if (!ReferenceEquals(HardwareId, null))
                foreach (var hardwareId in HardwareId)
                {
                    Console.WriteLine(hardwareId);
                }
            return Caption + "\n" + ClassGuid + "\n" + DevicePath + "\n" + Manufactirer + "\n" + "_____________________________" + "\n";
        }

        public void EnableDevice()
        {
            ChangeState(EnableMethod);
        }

        public void DisableDevice()
        {
            ChangeState(DisableMethod);
        }

        private void ChangeState(string method)
        {
            ManagementObject tempCurrentElement = null;
            var deviceList = new ManagementObjectSearcher("SELECT * FROM Win32_PNPEntity");
            foreach (var item in deviceList.Get().OfType<ManagementObject>())
            {
                if (DevicePath != item["DeviceID"]) continue;
                tempCurrentElement = item;
                break;
            }
            tempCurrentElement?.InvokeMethod(method, new object[] { false });
        }
    }
}
