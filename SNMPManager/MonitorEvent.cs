using System;
using System.Collections.Generic;
using System.Text;

namespace SNMPManager
{
    public class MonitorEvent
    {
        /// <summary>
        /// Tipo
        /// </summary>
        public MonitorKind Tipo { get; protected set; }

        /// <summary>
        /// Data e Hora
        /// </summary>
        public DateTime Timestamp { get; protected set; }

        /// <summary>
        /// Host
        /// </summary>
        public SNMPHost Host { get; protected set; }

        public MonitorEvent(SNMPHost h, MonitorKind t)
        {
            Host = h;
            Tipo = t;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}: {2}", Timestamp, Host, Utils.GetDescription(Tipo));
        }
    }
}
