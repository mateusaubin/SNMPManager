using System;
using System.IO;
using System.Text;
using SnmpSharpNet;

namespace SNMPManager
{
    /// <summary>
    /// Singleton para realizar a escrita de logs da aplicação.
    /// </summary>
    public sealed class Logger
    {
        // Variáveis de instância
        private StreamWriter writer;

        // Variáveis estáticas
        private static volatile Logger instance;
        private static object syncRoot = new Object();
        public static readonly string FILENAME = "App.log";
        
        private Logger() 
        {
            writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + FILENAME, true, Encoding.UTF8);
            writer.AutoFlush = true; // Evita bufferizar dados
        }

        // Singleton
        public static Logger Self
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Logger();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Escreve um texto arbitrário no arquivo de log
        /// </summary>
        public void Log(string text, LogType type)
        {
            writer.WriteLine(
                string.Format("{0} | {1, -9} | {2}",
                                DateTime.Now.ToString("u"),
                                type,
                                text
                                )
            );
        }

        /// <summary>
        /// Escreve um texto arbitrário no arquivo de log
        /// </summary>
        public void Log(string text)
        {
            Log(text, LogType.INFO);
        }

        /// <summary>
        /// Faz o logging de um SNMPRequest
        /// </summary>
        internal void Log(SNMPRequest SNMPReq)
        {
            var l = string.Format(  "{0,-21} | {1,-3} | {2}",
                                    SNMPReq.Host,
                                    SNMPReq.RequestData.Type,
                                    SNMPReq.Object
                                 );
            this.Log(l, LogType.REQUEST);
        }

        /// <summary>
        /// Faz o logging do resultado de um SNMPRequest
        /// </summary>
        internal void Log(Vb item)
        {
            this.Log(item.Value.ToString(), LogType.RESPONSE);
        }

        /// <summary>
        /// Faz o logging de uma Exception
        /// </summary>
        internal void Log(Exception ex)
        {
            this.Log(ex.Message, LogType.EXCEPTION);
        }
    }

    /// <summary>
    /// Classificação da mensagem de log
    /// </summary>
    public enum LogType
    {
        INFO,
        REQUEST,
        RESPONSE,
        EXCEPTION,
        DISCOVERY
    }
}
