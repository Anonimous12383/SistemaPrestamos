using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PrestamosApp.Services;

namespace PrestamosApp.Reportes
{
    public partial class FrmMorasAcumuladas : Form
    {
        public FrmMorasAcumuladas()
        {
            InitializeComponent();
        }

        private void CargarReporte(string filtro = "")
        {
            try
            {
                var service = new ReporteService();
                var datos = service.ObtenerMorasPorCliente();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    datos = datos
                        .Where(x => x.Cliente.ToLower().Contains(filtro.ToLower()))
                        .ToList();
                }

                reportViewer1.Reset();

                string rutaReporte = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Reportes",
                    "ReporteMoras.rdlc"
                );

                reportViewer1.LocalReport.ReportPath = rutaReporte;
                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("ReporteMoras", datos)
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

        private void FrmMorasAcumuladas_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtClienteId.Text.Trim();
            CargarReporte(filtro);
        }
    }
}