using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Getting_PCI_Devices
{
    class PciDeviceParser
    {
        public void Parse(List<PciDevice> devices)
        {
            foreach (PciDevice device in devices)
            {
                var file = new StreamReader("D:\\C\\Visual Studio 2015\\Projects\\Getting_PCI_Devices\\Getting_PCI_Devices\\pci-ids.txt");
                var vendorReg = new Regex("^" + device.VendorId + "  ");
                var deviceReg = new Regex("^\\t" + device.DeviceId + "  ");
                while (!file.EndOfStream)
                {
                    var vendorText = file.ReadLine();
                    if ( vendorText != null && vendorReg.Match(vendorText).Success)
                    {
                        while (!file.EndOfStream)
                        {
                            var deviceText = file.ReadLine();
                            if ( deviceText != null && deviceReg.Match(deviceText).Success)
                            {
                                device.VendorDescription = vendorText.Substring(6);
                                device.DeviceDescription = deviceText.Substring(7);
                                break;
                            }          
                        }
                    }
                }
            }
            foreach (var device in devices)
            {
                Console.WriteLine("Vendor: {0} \n" +
                                  "Device: {1}\n", device.VendorDescription, device.DeviceDescription);
            }
        }
    }
}
