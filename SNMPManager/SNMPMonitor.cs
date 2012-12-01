using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using SnmpSharpNet;

namespace SNMPManager
{
    public sealed class SNMPMonitor
    {
        private static volatile SNMPMonitor instance;
        private static object syncRoot = new Object();

        private SNMPMonitor() { }

        public static SNMPMonitor Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SNMPMonitor();
                    }
                }

                return instance;
            }
        }

        public IEnumerable<MonitorEvent> Exec(IEnumerable<SNMPHost> hostList)
        {
            if (hostList == null)
                throw new ArgumentNullException("hostList");

            var eventosGerados = new Queue<MonitorEvent>();
            MonitorEvent ocorrencia = null;

            foreach (var host in hostList)
            {
                foreach (var evento in host.MonitoredEvents)
                {
                    switch (evento)
                    {
                        case MonitorKind.IsAlive:
                            if (!IsAlive(host))
                                ocorrencia = new MonitorEvent(host, evento);
                            break;
                        default:
                            break;
                    }
                    if (ocorrencia != null)
                    {
                        //host.EventQueue.Enqueue(ocorrencia);
                        eventosGerados.Enqueue(ocorrencia);
                    }
                    ocorrencia = null;
                }
            }

            return eventosGerados;
        }

        /// <summary>
        /// Verifica se o Host está ativo (respondendo a requisições)
        /// </summary>
        private bool IsAlive(SNMPHost host)
        {
            var mibObj = new MibObject() { OID = "1.3.6.1.2.1.1.3" };
            var req = new SNMPRequest(host, mibObj) { LogRequests = false };
            try
            {
                req.Send();
                if (req.ResponseValue != null)
                    return true;
            }
            catch { }
            return false;
        }
    }

    public enum MonitorKind
    {
        Nenhum,

        [Description("Não houve resposta do Host.")]
        IsAlive
    }
}
