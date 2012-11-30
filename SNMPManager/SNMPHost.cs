using System;
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

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? string.Format("{0}:{1}", IP, Port) : Name;
        }
    }
}
