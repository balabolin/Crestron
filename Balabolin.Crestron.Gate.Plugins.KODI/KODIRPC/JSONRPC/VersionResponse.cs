using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace KODIRPC.JSONRPC
{
   public class VersionResponse
   {
       public KODIRPC.JSONRPC.VersionResponse_version version { get; set; }
    }
}
