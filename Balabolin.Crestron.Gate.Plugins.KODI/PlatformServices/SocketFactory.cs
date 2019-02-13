using KODIRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Balabolin.Crestron.Gate.Plugins.KODI.PlatformServices
{
    public class SocketFactory : ISocketFactory
    {
        public ISocket GetSocket()
        {
            return null;
        }

        public async Task<string[]> ResolveHostname(string hostname)
        {
            //IReadOnlyList<EndpointPair> data = await DatagramSocket.GetEndpointPairsAsync(new HostName(hostname), "0");

            return null;//data.Select(ep => ep.RemoteHostName.DisplayName).ToArray();
        }
    }
}
