using System.Net;
using System.Net.NetworkInformation;
using RadioPlayer.Services.Abstracts;

namespace RadioPlayer.Services;

public class DnsService(Ping ping) : IDnsService
{
    private  string? _fastestUrl;
    private const string BaseUrl = "all.api.radio-browser.info";

    public string ApiUrl
    {
        get
        {
            if (!string.IsNullOrEmpty(_fastestUrl)) return _fastestUrl;
            
            var ips = Dns.GetHostAddresses(BaseUrl);
            var lastRoundTripTime = long.MaxValue;
            var searchUrl = "de1.api.radio-browser.info"; // Fallback

            foreach (var ipAddress in ips)
            {
                var reply = ping.Send(ipAddress);
                if (reply.RoundtripTime >= lastRoundTripTime) continue;

                lastRoundTripTime = reply.RoundtripTime;
                searchUrl = ipAddress.ToString();
            }

            if (!string.IsNullOrEmpty(Dns.GetHostEntry(searchUrl).HostName))
            {
                searchUrl = Dns.GetHostEntry(searchUrl).HostName;
            }
            _fastestUrl=searchUrl;
            return _fastestUrl;
        }
    }
}