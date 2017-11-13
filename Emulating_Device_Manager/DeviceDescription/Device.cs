using System;
using System.Collections.Generic;
using System.Management;

namespace Emulating_Device_Manager.DeviceDescription
{
    class Device
    {
        private const string ClassGuidProperty = "ClassGuid";
        private const string HardwareIdProperty = "HardwareID";
        private const string ManufacturerProperty = "Manufacturer";
        private const string CaptionProperty = "Caption";
        private const string DevicePathProperty = "DeviceID";
        private const string DriverRelatedProperty = "Win32_SystemDriver";

        public object Caption { get; set; }
        private object ClassGuid { get; set; }
        private object DevicePath { get; set; }
        private List<Driver> Drivers { get; set; }
        private string[] HardwareId { get; set; }
        private object Manufactirer { get; set; }

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
    }
}
