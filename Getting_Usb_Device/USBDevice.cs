namespace Getting_USB_Devices
{
    class UsbDevice
    {
        public string Name { get; set; }
        public string FreeSize { get; set; }
        public string OccupiedSize { get; set; }
        public string TotalSize { get; set; }
        public bool IsMtp { get; set; }

        public UsbDevice(string name, string freeSize, string occupiedSize, string totalSize, bool isMtp)
        {
            Name = name;
            FreeSize = freeSize;
            OccupiedSize = occupiedSize;
            TotalSize = totalSize;
            IsMtp = isMtp;
        }
    }
}
