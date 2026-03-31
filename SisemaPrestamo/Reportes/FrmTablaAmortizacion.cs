using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PrestamosApp.DTOs;
using PrestamosApp.Services;

namespace PrestamosApp.Reportes
{
    public partial class FrmAmortizacion : Form
    {
        public FrmAmortizacion()
        {
            InitializeComponent();
        }

        private string ObtenerRutaReporte()
        {
            string ruta1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes", "ReporteAmortizacion.rdlc");
            if (File.Exists(ruta1))
                return ruta1;

            string ruta2 = Path.Combine(Application.StartupPath, "Reportes", "ReporteAmortizacion.rdlc");
            if (File.Exists(ruta2))
                return ruta2;

            string ruta3 = Path.Combine(Application.StartupPath, "ReporteAmortizacion.rdlc");
            if (File.Exists(ruta3))
                return ruta3;

            throw new FileNotFoundException("No se encontró ReporteAmortizacion.rdlc");
        }

        private void CargarReporte(List<ReporteAmortizacionDto> datos)
        {
            string rutaReporte = ObtenerRutaReporte();

            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportPath = rutaReporte;
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("ReporteAmortizacion", datos)
            );

            reportViewer1.RefreshReport();
        }

        private void FrmAmortizacion_Load(object sender, EventArgs e)
        {
            txtClienteId.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtClienteId.Text))
                {
                    MessageBox.Show("Ingrese el ID del cliente.");
                    return;
                }

                if (!int.TryParse(txtClienteId.Text, out int clienteId))
                {
                    MessageBox.Show("El ID debe ser numérico.");
                    return;
                }

                var service = new ReporteService();
                var datos = service.ObtenerTablaAmortizacionPorCliente(clienteId);

                if (datos == null || datos.Count == 0)
                {
                    MessageBox.Show("Ese cliente no tiene préstamos.");
                    return;
                }

                CargarReporte(datos);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;

                if (ex.InnerException != null)
                    mensaje += "\n\nINNER: " + ex.InnerException.Message;

                if (ex.InnerException?.InnerException != null)
                    mensaje += "\n\nSQL: " + ex.InnerException.InnerException.Message;

                MessageBox.Show("Error:\n\n" + mensaje);
            }
        }
    }
}