using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PrestamosApp.DTOs;
using PrestamosApp.Services;


namespace PrestamosApp.Reportes
{
    public partial class FrmInformacionCliente : Form
    {
        public FrmInformacionCliente()
        {
            InitializeComponent();
        }

        // 🔵 ESTE MÉTODO CARGA EL REPORTE
        private void CargarReporte(int clienteId)
        {
            var service = new ReporteService();
            var cliente = service.ObtenerDetalleCliente(clienteId);

            if (cliente == null)
            {
                MessageBox.Show("Cliente no encontrado");
                return;
            }

            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportPath = "Reportes/ReporteCliente.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("Clientes",
                new List<ReporteClienteDto> { cliente })
            );

            reportViewer1.RefreshReport();
        }

        // 🔵 SE EJECUTA AL ABRIR EL FORM
        private void FrmInformacionCliente_Load(object sender, EventArgs e)
        {
            // Si el textbox está vacío, usa cliente 1 por defecto
            if (string.IsNullOrWhiteSpace(txtClienteId.Text))
            {
                txtClienteId.Text = "1";
            }

            int clienteId = int.Parse(txtClienteId.Text);

            CargarReporte(clienteId);
        }

        // 🔵 BOTÓN BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClienteId.Text))
            {
                MessageBox.Show("Debe ingresar un ID de cliente.");
                return;
            }

            if (!int.TryParse(txtClienteId.Text, out int clienteId))
            {
                MessageBox.Show("El ID debe ser numérico.");
                return;
            }

            try
            {
                var service = new ReporteService();
                var cliente = service.ObtenerDetalleCliente(clienteId);

                if (cliente == null)
                {
                    MessageBox.Show("Cliente no encontrado.");
                    return;
                }

                reportViewer1.Reset();

                string rutaReporte = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Reportes",
                    "ReporteCliente.rdlc"
                );

                reportViewer1.LocalReport.ReportPath = rutaReporte;

                // 🔥 AQUÍ VA LO QUE ME PREGUNTASTE
                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(
                    new Microsoft.Reporting.WinForms.ReportDataSource(
                        "ReporteCliente",
                        new List<ReporteClienteDto> { cliente }
                    )
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

                MessageBox.Show("Error al buscar cliente:\n\n" + mensaje);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}