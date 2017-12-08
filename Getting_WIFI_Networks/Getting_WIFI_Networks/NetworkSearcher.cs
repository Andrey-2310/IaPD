using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeWifi;
using SimpleWifi;

namespace Getting_WIFI_Networks
{
    class NetworkSearcher
    {
        private readonly Wifi _wifi;
        private readonly WlanClient _wlanClient;

        public NetworkSearcher()
        {
            _wifi = new Wifi();
            _wlanClient = new WlanClient();
        }

        public List<WiFiNetwork> GetNetworks()
        {
            var accessPoints = _wifi.GetAccessPoints();
            return accessPoints.Select(accessPoint => new WiFiNetwork(accessPoint.Name, accessPoint.SignalStrength + "%", accessPoint.ToString(), GetBssId(accessPoint), accessPoint.IsSecure, accessPoint.IsConnected)).ToList();
        }

        private List<string> GetBssId(AccessPoint accessPoint)
        {
            var wlanInterface = _wlanClient.Interfaces.FirstOrDefault();
            return wlanInterface?.GetNetworkBssList()
                .Where(x => Encoding.ASCII.GetString(x.dot11Ssid.SSID, 0, (int)x.dot11Ssid.SSIDLength).Equals(accessPoint.Name))
                .Select(y => Dot11BSSTostring(y)).ToList();
        }

        private string Dot11BSSTostring(Wlan.WlanBssEntry entry)
        {
            var bssIdBuilder = new StringBuilder();
            foreach (var bssByte in entry.dot11Bssid)
            {
                bssIdBuilder.Append(bssByte.ToString("X"));
                bssIdBuilder.Append("-");
            }
            bssIdBuilder.Remove(bssIdBuilder.Length - 1, 1);
            return bssIdBuilder.ToString();
        }
    }
}
