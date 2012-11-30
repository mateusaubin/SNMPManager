using System;

namespace SNMPManager
{
    /// <summary>
    /// Mapeia um Objeto da MIB
    /// </summary>
    public class MibObject
    {
        /// <summary>
        /// OID do objeto
        /// </summary>
        public string OID { get; set; }

        /// <summary>
        /// Nome do objeto
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Permite operações Set?
        /// </summary>
        public bool CanSet { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? OID : Name;
        }
    }
}
