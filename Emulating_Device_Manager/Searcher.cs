using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Management;
using System.Xml;
using Emulating_Device_Manager.DeviceDescription;

namespace Emulating_Device_Manager
{
    class Searcher
    {
        public ManagementObjectSearcher ManagementSearcher { get; }

        private static readonly SelectQuery Query = new SelectQuery("SELECT * FROM Win32_PnPEntity");
        private List<ManagementObject> devices = new List<ManagementObject>();
        public Searcher()
        {
            var scope = new ManagementScope();
            ManagementSearcher = new ManagementObjectSearcher(scope, Query);
        }

        public void DriverOutput()
        {
            List<Device> devices = new List<Device>();
            foreach (var device in ManagementSearcher.Get().OfType<ManagementObject>())
            {
                devices.Add(new Device(device));
              
            }
            foreach (var device in devices)
            {
                Console.WriteLine(device.ToString());
            }
        }

    }


}
