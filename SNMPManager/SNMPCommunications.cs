using System;
using System.Collections.Generic;
using System.Text;
using SnmpSharpNet;

namespace SNMPManager
{
    public class SNMPCommunications : SNMPRequest
    {

        public string Hostname
        {
            get
            {
                return base.Host.DisplayName;
            }
        }

        public string Tipo
        {
            get
            {
                return base.RequestPacket.Type.ToString();
            }
        }

        public string Objeto
        {
            get
            {
                return base.Object.DisplayName;
            }
        }

        public SNMPCommunications(SNMPHost host, MibObject obj)
            : base(host, obj)
        { }
    }
}
