using System.Management;

namespace Emulating_Device_Manager.DeviceDescription
{
    class Driver
    {
        private const string SysFilePath = "PathName";
        private const string Description = "Description";

        private readonly object _sysFilePath;
        private readonly object _description;

        public Driver(ManagementBaseObject managementObject)
        {
            _sysFilePath = managementObject[SysFilePath];
            _description = managementObject[Description];
        }

        public override string ToString()
        {
            return _sysFilePath + "\n" + _description + "\n";
        }
    }
}
