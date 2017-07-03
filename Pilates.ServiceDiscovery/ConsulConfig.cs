using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.ServiceDiscovery
{
    public class ConsulConfig
    {
        public string Address { get; set; }
        public string ServiceName { get; set; }
        public string ServiceID { get; set; }
    }
}
