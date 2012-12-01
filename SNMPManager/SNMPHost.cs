using System;
using System.Collections.Generic;
using System.Net;

namespace SNMPManager
{
    /// <summary>
    /// Mapeia um Host com capacidades SNMP
    /// </summary>
    public class SNMPHost
    {
        /// <summary>
        /// Endereço IP
        /// </summary>
        public IPAddress IP { get; set; }

        /// <summary>
        /// Porta SNMP
        /// </summary>
        public ushort Port { get; set; }

        /// <summary>
        /// Comunidade
        /// </summary>
        public string Community { get; set; }

        /// <summary>
        /// Nome do host
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tipos de evento que devem ser monitorados neste host
        /// </summary>
        public IList<MonitorKind> MonitoredEvents { get; protected set; }

        /*
        /// <summary>
        /// Fila de eventos que dispararam para este host
        /// </summary>
        public Queue<MonitorEvent> EventQueue { get; protected set; }
        */

        public SNMPHost()
        {
            //EventQueue = new Queue<MonitorEvent>();
            MonitoredEvents = new List<MonitorKind>();
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? string.Format("{0}:{1}", IP, Port) : Name;
        }

        internal bool AddMonitoringEvent(MonitorKind monitor)
        {
            if (!MonitoredEvents.Contains(monitor))
            {
                MonitoredEvents.Add(monitor);
                return true;
            }
            return false;
        }
    }
}
