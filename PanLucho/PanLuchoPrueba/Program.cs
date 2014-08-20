using System;

using System.Windows.Forms;
using ClbClientes;
using ClbFacturas;
using ClbPedidosEspeciales;using ClbUsuarios;
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
           // Application.Run(new FrmUsuarios() { Tag = "c|u|00" });
            Application.Run(new FrmFactura());}
    }
}
