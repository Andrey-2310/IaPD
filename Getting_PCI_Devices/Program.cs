using System;
using System.Management;
using System.Text.RegularExpressions;

namespace Getting_PCI_Devices
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionScope = new ManagementScope();
            var serialQuery = new SelectQuery("SELECT * FROM Win32_PnPEntity");
            var searcher = new ManagementObjectSearcher(connectionScope, serialQuery);
            var deviceRegEx = new Regex("DEV_.{4}");
            var vendorRegEx = new Regex("VEN_.{4}");
            foreach (ManagementObject device in searcher.Get())
            {
                var description = device["DeviceID"].ToString();
                if (description.Contains("PCI"))
                {         
                    string Description = device.GetPropertyValue("Description").ToString();
                    string name = device.GetPropertyValue("DeviceID").ToString();
                    Console.WriteLine("Device ID: " + deviceRegEx.Match(description).Value.Substring(4));
                    Console.WriteLine("Vendor ID: " + vendorRegEx.Match(description).Value.Substring(4));
                    Console.WriteLine("Full Description: "+ device["Description"] +"\n");
                }
            }
        }
    }
}


