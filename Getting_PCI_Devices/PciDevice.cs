namespace Getting_PCI_Devices
{
    public class PciDevice
    {
        private string deviceId;
        public string DeviceId { get { return deviceId; } }

        private string _deviceDescription;
        public string DeviceDescription { get { return _deviceDescription; } set { _deviceDescription = value; } }

        private string vendorId;
        public string VendorId { get { return vendorId; } }

        private string _vendorDescription;
        public string VendorDescription { get { return _vendorDescription; } set { _vendorDescription = value; } }

        public PciDevice(string deviceId, string vendorId)
        {
            this.deviceId = deviceId;
            this.vendorId = vendorId;
        }
    }
}
