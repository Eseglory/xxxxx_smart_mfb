using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Smart.MFB.ERP.Common.ServiceModel
{
    public static class PCIPAddress
    {

        public static string IPAddress
        {
            get
            {
                string IPAddress = string.Empty;

                IPHostEntry Host = default(IPHostEntry);
                string Hostname = null;
                Hostname = System.Environment.MachineName;
                Host = Dns.GetHostEntry(Hostname);
                foreach (var IP in Host.AddressList)
                {
                    if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        IPAddress = Convert.ToString(IP);
                    }
                }
                return IPAddress;
            }
        }
    }

}

