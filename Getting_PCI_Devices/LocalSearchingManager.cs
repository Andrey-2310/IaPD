using System.Collections.Generic;
using System.Management;
using System.Text.RegularExpressions;


namespace Getting_PCI_Devices
{
    class LocalSearchingManager
    {
        public ManagementObjectSearcher Searcher { get; }

        private static readonly SelectQuery Query = new SelectQuery("SELECT * FROM Win32_PnPEntity");
        private static readonly Regex DeviceRegEx = new Regex("DEV_.{4}");
        private static readonly Regex VendorRegEx = new Regex("VEN_.{4}");

        public LocalSearchingManager()
        {
            var scope = new ManagementScope();
            Searcher = new ManagementObjectSearcher(scope, Query);
        }

        public List<PciDevice> SearchDevicesOnLocalMachine()
        {
            var pciDevicesList = new List<PciDevice>();
            foreach (var device in Searcher.Get())
            {
                var description = device["DeviceID"].ToString();
                if (description.Contains("PCI"))
                    pciDevicesList.Add(new PciDevice(DeviceRegEx.Match(description).Value.Substring(4).ToLower(),
                        VendorRegEx.Match(description).Value.Substring(4).ToLower()));
            }
            return pciDevicesList;
        }
    }
}
