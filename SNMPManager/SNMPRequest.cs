using System;
using SnmpSharpNet;

namespace SNMPManager
{
    /// <summary>
    /// Mapeia um Request SNMP e sua Resposta
    /// </summary>
    public class SNMPRequest
    {
        private ushort _timeout;
        private byte _retries;

        /// <summary>
        /// Timeout padrão da requisição
        /// </summary>
        public static readonly ushort DEFAULT_TIMEOUT = 500;

        /// <summary>
        /// Número padrão de tentativas em caso de erro
        /// </summary>
        public static readonly byte DEFAULT_RETRIES = 1;

        /// <summary>
        /// Timeout da requisição
        /// </summary>
        public ushort TimeOut
        {
            get
            {
                return _timeout == 0 ? DEFAULT_TIMEOUT : _timeout;
            }
            set
            {
                _timeout = value;
            }
        }

        /// <summary>
        /// Quantidade de tentativas em caso de erro
        /// </summary>
        public byte Retries
        {
            get
            {
                return _retries == 0 ? DEFAULT_RETRIES : _retries;
            }
            set
            {
                _retries = value;
            }
        }

        /// <summary>
        /// Data e Hora de realização
        /// </summary>
        public DateTime Timestamp { get; protected set; }

        /// <summary>
        /// Host SNMP alvo da requisição
        /// </summary>
        public SNMPHost Host { get; protected set; }

        /// <summary>
        /// Objeto da MIB requisitado
        /// </summary>
        public MibObject Object { get; protected set; }

        /// <summary>
        /// Pacote de Requisição
        /// </summary>
        public Pdu RequestData { get; protected set; }

        /// <summary>
        /// Pacote de Resposta
        /// </summary>
        public SnmpV2Packet ResponsePacket { get; protected set; }

        /// <summary>
        /// Valor da Resposta
        /// </summary>
        public AsnType ResponseValue { get; protected set; }

        /// <summary>
        /// Deve gravar logs?
        /// </summary>
        public bool LogRequests { get; set; }

        public SNMPRequest(SNMPHost host, MibObject obj)
        {
            Host = host;
            Object = obj;
            LogRequests = true;
        }

        /// <summary>
        /// Executa uma requisição do tipo Get
        /// </summary>
        public void Send()
        {
            Send(null);
        }

        /// <summary>
        /// Executa uma requisição do tipo Set
        /// </summary>
        /// <param name="setValue">Valor a set definido</param>
        public void Send(AsnType setValue)
        {
            using (var target = new UdpTarget(Host.IP, Host.Port, TimeOut, Retries))
            {
                var agentp = new AgentParameters(SnmpVersion.Ver2, new OctetString(Host.Community));

                // Caso necessario, appenda o .0 na requisição
                var oid = new Oid(Object.OID);
                if (oid[oid.Length - 1] != 0)
                    oid.Add(0);

                // Cria pacote de dados
                RequestData = new Pdu(setValue == null ? PduType.Get : PduType.Set);

                // Adiciona dados da requisição
                switch (RequestData.Type)
                {
                    case PduType.Get:
                        RequestData.VbList.Add(oid);
                        break;
                    case PduType.Set:
                        RequestData.VbList.Add(oid, setValue);
                        break;
                    default:
                        throw new InvalidOperationException("unsupported");
                }
                try
                {
                    if (LogRequests) Logger.Self.Log(this);
                    Timestamp = DateTime.Now;

                    // Envia requisição
                    ResponsePacket = target.Request(RequestData, agentp) as SnmpV2Packet;
                    
                    // Trata resposta
                    if (ResponsePacket != null && ResponsePacket.Pdu.ErrorStatus == (int)PduErrorStatus.noError)
                    {
                        // TODO: suportar mais de um retorno
                        var item = ResponsePacket.Pdu.VbList[0];

                        ResponseValue = item.Value;
                        if (LogRequests) Logger.Self.Log(item);
                    }
                }
                catch (Exception ex)
                {
                    if (LogRequests) Logger.Self.Log(ex);
                    throw new SnmpException("Não foi possível realizar a operação");
                }
            }
        }
    }
}
