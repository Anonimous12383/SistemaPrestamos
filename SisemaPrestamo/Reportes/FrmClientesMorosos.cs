using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PrestamosApp.Services;

namespace REPORTES.Reportes
{
    public partial class FrmClientesMorosos : Form
    {
        private const string DATASET_NAME = "ReporteMorosos";

        public FrmClientesMorosos()
        {
            InitializeComponent();
        }

        private string ObtenerRutaReporte()
        {
            string ruta1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes", "ReporteMorosos.rdlc");
            if (File.Exists(ruta1))
                return ruta1;

            string ruta2 = Path.Combine(Application.StartupPath, "Reportes", "ReporteMorosos.rdlc");
            if (File.Exists(ruta2))
                return ruta2;

            string ruta3 = Path.Combine(Application.StartupPath, "ReporteMorosos.rdlc");
            if (File.Exists(ruta3))
                return ruta3;

            throw new FileNotFoundException("No se encontró el archivo ReporteMorosos.rdlc");
        }

        private void CargarReporte()
        {
            try
            {
                var service = new ReporteService();
                var datos = service.ObtenerClientesMorosos();

                reportViewer1.Reset();
                reportViewer1.LocalReport.ReportPath = ObtenerRutaReporte();
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource(DATASET_NAME, datos)
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

        private void FrmClientesMorosos_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            // vacío para evitar error del diseñador
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtClienteId.Text))
                {
                    CargarReporte();
                    return;
                }

                if (!int.TryParse(txtClienteId.Text.Trim(), out int clienteId))
                {
                    MessageBox.Show("Ingrese un ID válido.");
                    return;
                }

                var service = new ReporteService();
                // Usar la sobrecarga que recibe el ID y devuelve directamente la lista tipada
                var datos = service.ObtenerClientesMorosos(clienteId);

                if (datos == null || datos.Count == 0)
                {
                    MessageBox.Show("No se encontraron clientes morosos con este ID.");
                    return;
                }

                reportViewer1.Reset();
                reportViewer1.LocalReport.ReportPath = ObtenerRutaReporte();
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource(DATASET_NAME, datos)
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

                MessageBox.Show("Error al buscar cliente moroso:\n\n" + mensaje);
            }
        }
    }
}