using System;
using System.Collections.Generic;
using System.Management;
using System.Text.RegularExpressions;

namespace Getting_PCI_Devices
{
    class Program
    {
        private static void Main(string[] args)
        {
            var searchingManager = new LocalSearchingManager();
            var pciDevices = searchingManager.SearchDevicesOnLocalMachine();
            var customParser = new PciDeviceParser();
            customParser.Parse(pciDevices);
        }
    }
}


