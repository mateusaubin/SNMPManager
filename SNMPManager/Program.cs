using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SnmpSharpNet;
using System.Net;
using System.Diagnostics;

namespace SNMPManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Self.Log("Inicializando Aplicação");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            Logger.Self.Log("Finalizando Aplicação");
        }
    }
}
