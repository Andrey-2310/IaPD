using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulating_Device_Manager.DeviceDescription
{
    interface IDeviceOptions
    {
        void EnableDevice();
        void DisableDevice();
    }
}
