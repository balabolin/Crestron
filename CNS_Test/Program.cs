using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNS_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Crestron.ActiveCNX.ActiveCNX activeCNX = new Crestron.ActiveCNX.ActiveCNX("192.168.100.100", 5, "", "", 41794,false);
            activeCNX.Connect();
            activeCNX.Disconnect();
            var b = activeCNX.isConnected;

        }
    }
}
