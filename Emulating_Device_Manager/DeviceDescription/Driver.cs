using System.Management;

namespace Emulating_Device_Manager.DeviceDescription
{
    class Driver
    {
        private const string SysFilePathProperty = "PathName";
        private const string DescriptionProperty = "Description";

        public object SysFilePath { get; set; }
        public object Description { get; set; }

        public Driver(ManagementBaseObject managementObject)
        {
            SysFilePath = managementObject[SysFilePathProperty];
            Description = managementObject[DescriptionProperty];
        }

        public override string ToString()
        {
            return "PathName: " + SysFilePath + "\r\n" + "Description: " + Description + "\r\n";
        }
    }
}
