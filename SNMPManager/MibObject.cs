using System;
using System.Collections.Generic;
using System.Text;

namespace SNMPManager
{
    public class MibObject
    {
        public string OID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string DisplayName
        {
            get
            {
                return string.IsNullOrEmpty(Name) ? OID : Name;
            }
        }

        public bool CanSet { get; set; }
    }
}
