using System;
using System.Collections.Generic;
using System.Text;
using SnmpSharpNet;

namespace SNMPManager
{
    public class SNMPRequest
    {
        public static readonly int TIMEOUT = 1000;

        public DateTime Timestamp { get; protected set; }

        public SNMPHost Host { get; set; }

        public MibObject Object { get; set; }

        public Pdu RequestPacket { get; protected set; }

        public SnmpV2Packet ResponsePacket { get; protected set; }

        public object ResponseValue { get; protected set; }

        public SNMPRequest(SNMPHost host, MibObject obj)
        {
            Host = host;
            Object = obj;
        }

        public void Send()
        {
            Send(null);
        }

        public void Send(AsnType setValue)
        {
            using (var target = new UdpTarget(Host.IP, Host.Port, TIMEOUT, 0))
            {
                var agentp = new AgentParameters(SnmpVersion.Ver2, new OctetString(Host.Community));
                var oid = new Oid(Object.OID + ".0");
                RequestPacket = new Pdu(setValue == null ? PduType.Get : PduType.Set);

                switch (RequestPacket.Type)
                {
                    case PduType.Get:
                        RequestPacket.VbList.Add(oid);
                        break;
                    case PduType.Set:
                        RequestPacket.VbList.Add(oid, setValue);
                        break;
                    default:
                        throw new InvalidOperationException("unsupported");
                }
                Logger.Self.Log(this);
                Timestamp = DateTime.Now;
                try
                {
                    ResponsePacket = target.Request(RequestPacket, agentp) as SnmpV2Packet;
                    if (ResponsePacket != null && ResponsePacket.Pdu.ErrorStatus == 0)
                    {
                        var item = ResponsePacket.Pdu.VbList[0];
                        ResponseValue = item.Value;
                        Logger.Self.Log(item);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Self.Log(ex);
                    throw new SnmpException("Não foi possível realizar a operação");
                }
            }
        }
    }
}
