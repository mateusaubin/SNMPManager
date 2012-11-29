using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace SNMPManager
{
    public class SNMPHost
    {
        public IPAddress IP { get; set; }

        public ushort Port { get; set; }

        public string Community { get; set; }

        public string Name { get; set; }

        public string DisplayName
        {
            get
            {
                return string.IsNullOrEmpty(Name) ? string.Format("{0}:{1}", IP, Port) : Name;
            }
        }
    }
}
