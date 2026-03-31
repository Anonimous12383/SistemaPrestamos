using System;
using System.Windows.Forms;
using PrestamosApp;
using PrestamosApp.Reportes;
using REPORTES.Reportes;

namespace SisemaPrestamo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPrincipal());
        }
    }
}
