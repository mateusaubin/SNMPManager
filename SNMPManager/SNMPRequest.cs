using System;
using System.Collections.Generic;
using System.Text;
using SnmpSharpNet;

namespace SNMPManager
{
    public class SNMPRequest
    {
        public static readonly int TIMEOUT = 2500;

        public DateTime Timestamp { get; protected set; }

        public SNMPHost Host { get; set; }

        public MibObject Object { get; set; }

        public Pdu RequestPacket { get; protected set; }

        public SnmpV2Packet ResponsePacket { get; protected set; }

        public object ResponseValue { get; protected set; }

        public SNMPRequest(SNMPHost host, PduType type, MibObject obj)
        {
            Host = host;
            RequestPacket = new Pdu(type);
            Object = obj;
        }

        public void Send()
        {
            using (var target = new UdpTarget(Host.IP, Host.Port, TIMEOUT, 0))
            {
                var agentp = new AgentParameters(SnmpVersion.Ver2, new OctetString(Host.Community));
                switch (RequestPacket.Type)
                {
                    case PduType.Get:
                        RequestPacket.VbList.Add(new Oid(Object.OID + ".0"));
                        break;
                    case PduType.Set:
                        // TODO: Implementar Set
                        throw new NotImplementedException();
                        break;
                    default:
                        break;
                }
                Timestamp = DateTime.Now;
                try
                {
                    ResponsePacket = target.Request(RequestPacket, agentp) as SnmpV2Packet;
                }
                catch (Exception)
                {
                    ResponsePacket = null;
                }

                if (ResponsePacket != null && ResponsePacket.Pdu.ErrorStatus == 0)
                {
                    var item = ResponsePacket.Pdu.VbList[0];
                    ResponseValue = item.Value;
                    //string.Format("Oid: {0}| Type: {1}| Value: {2}", item.Oid, item.Type, item.Value);
                }
                else
                {
                    // TODO: Tratar Erros
                    throw new Exception();
                }
            }
        }
    }
}
