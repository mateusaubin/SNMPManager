using System;

namespace SNMPManager
{
    /// <summary>
    /// Wrapper para apresentar os dados na tela, uma vez 
    /// que o DataGridView não permite certas operações
    /// </summary>
    public class SNMPCommunications : SNMPRequest
    {

        public string Hostname
        {
            get
            {
                return base.Host.ToString();
            }
        }

        public string Tipo
        {
            get
            {
                return base.RequestData.Type.ToString();
            }
        }

        public string Objeto
        {
            get
            {
                return base.Object.ToString();
            }
        }

        public SNMPCommunications(SNMPHost host, MibObject obj)
            : base(host, obj)
        { }
    }
}
