using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PrestamosApp.DTOs;
using PrestamosApp.Services;

namespace PrestamosApp.Reportes
{
    public partial class FrmTotalPrestado : Form
    {
        public FrmTotalPrestado()
        {
            InitializeComponent();
        }

        private void FrmTotalPrestado_Load(object sender, EventArgs e)
        {
            // No cargar automáticamente
        }

        private string ObtenerRutaReporte()
        {
            string ruta1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes", "ReporteFinanciero.rdlc");
            if (File.Exists(ruta1))
                return ruta1;

            string ruta2 = Path.Combine(Application.StartupPath, "Reportes", "ReporteFinanciero.rdlc");
            if (File.Exists(ruta2))
                return ruta2;

            string ruta3 = Path.Combine(Application.StartupPath, "ReporteFinanciero.rdlc");
            if (File.Exists(ruta3))
                return ruta3;

            string ruta4 = Path.Combine(Directory.GetCurrentDirectory(), "Reportes", "ReporteFinanciero.rdlc");
            if (File.Exists(ruta4))
                return ruta4;

            throw new FileNotFoundException(
                "No se encontró el archivo ReporteFinanciero.rdlc.\n\n" +
                "Busqué en:\n" + ruta1 + "\n" + ruta2 + "\n" + ruta3 + "\n" + ruta4
            );
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new ReporteService();
                var resumen = service.ObtenerResumenFinanciero();

                string rutaReporte = ObtenerRutaReporte();

                reportViewer1.Reset();
                reportViewer1.LocalReport.ReportPath = rutaReporte;
                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("ReporteFinanciero", new List<ReporteFinancieroDto> { resumen })
                );

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;

                if (ex.InnerException != null)
                    mensaje += "\n\nINNER: " + ex.InnerException.Message;

                if (ex.InnerException?.InnerException != null)
                    mensaje += "\n\nSQL: " + ex.InnerException.InnerException.Message;

                MessageBox.Show("Error al cargar reporte:\n\n" + mensaje);
            }
        }
    }
}