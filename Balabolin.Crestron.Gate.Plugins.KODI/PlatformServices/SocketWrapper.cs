using KODIRPC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Balabolin.Crestron.Gate.Plugins.KODI.PlatformServices
{
    public class SocketWrapper : ISocket
    {
        private readonly Socket _streamSocket;

        public SocketWrapper(Socket streamSocket)
        {
            _streamSocket = streamSocket;
        }

        public void Dispose()
        {
            _streamSocket.Dispose();
        }

        public async Task ConnectAsync(string hostName, int port)
        {
            await _streamSocket.ConnectAsync(new HostName(hostName), port.ToString());
        }

        public Stream GetInputStream()
        {
            return _streamSocket.InputStream.AsStreamForRead();
        }
    }
}
