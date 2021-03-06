﻿using System;
using System.Windows.Forms;

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
