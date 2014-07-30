using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClbClientes;
using ClbFacturas;
using Menu;


namespace PanLuchoPrueba
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmCliente());
            Application.Run(new FrmCliente());
        }
    }
}
