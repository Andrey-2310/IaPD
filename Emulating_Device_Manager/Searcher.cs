using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Remoting.Messaging;
using Emulating_Device_Manager.DeviceDescription;

namespace Emulating_Device_Manager
{
    class Searcher
    {
        public ManagementObjectSearcher ManagementSearcher { get; }

        private static readonly SelectQuery Query = new SelectQuery("SELECT * FROM Win32_PnPEntity");

        public Searcher()
        {
            var scope = new ManagementScope();
            ManagementSearcher = new ManagementObjectSearcher(scope, Query);
        }

        public List<Device> FindDevices()
        {
            return ManagementSearcher.Get().OfType<ManagementObject>().Select(device => new Device(device)).ToList();
        }

    }


}
