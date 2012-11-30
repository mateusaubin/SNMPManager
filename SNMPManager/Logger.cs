using System;
using System.IO;
using System.Text;
using System.Globalization;
using SnmpSharpNet;

namespace SNMPManager
{
    public sealed class Logger
    {
        public readonly string FILENAME = "App.log";
        private LogType LogType;

        private static volatile Logger instance;
        private static object syncRoot = new Object();

        private Logger() { }

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

        public void Log(string text)
        {
            using (var writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + FILENAME, true, Encoding.UTF8))
            {
                writer.WriteLine(
                    string.Format(  "{0} | {1, -9} | {2}",
                                    DateTime.Now.ToString("u"),
                                    LogType,
                                    text
                                 )
                );
            }
            LogType = LogType.INFO;
        }

        internal void Log(SNMPRequest SNMPReq)
        {
            var l = string.Format(  "{0,-21} | {1,-10} | {2}",
                                    SNMPReq.Host.DisplayName,
                                    SNMPReq.RequestPacket.Type,
                                    SNMPReq.Object.DisplayName
                                 );
            LogType = LogType.REQUEST;
            this.Log(l);
        }

        internal void Log(Vb item)
        {
            var l = string.Format("{0}",
                                    item.Value
                                 );
            LogType = LogType.RESPONSE;
            this.Log(l);
        }

        internal void Log(Exception ex)
        {
            LogType = LogType.EXCEPTION;
            this.Log(ex.Message);
        }
    }

    internal enum LogType
    {
        INFO,
        REQUEST,
        RESPONSE,
        EXCEPTION,
    }
}
