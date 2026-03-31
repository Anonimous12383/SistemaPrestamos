using System;
using System.Windows.Forms;
using PrestamosApp.Formularios;
using PrestamosApp.Reportes;
using REPORTES.Reportes;
using SisemaPrestamo.Formularios;

namespace PrestamosApp
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }


        private void btnClientes_Click(object sender, EventArgs e)
        {
            new FrmClientes().ShowDialog();
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            new FrmPrestamos().ShowDialog();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            new FrmPagos().ShowDialog();
        }

        private void btnReporteCliente_Click(object sender, EventArgs e)
        {
            new FrmInformacionCliente().ShowDialog();
        }

        private void btnReporteMorosos_Click(object sender, EventArgs e)
        {
            new FrmClientesMorosos().ShowDialog();
        }

        private void btnReporteMoras_Click(object sender, EventArgs e)
        {
            new FrmMorasAcumuladas().ShowDialog();
        }

        private void btnReporteFinanciero_Click(object sender, EventArgs e)
        {
            new FrmTotalPrestado().ShowDialog();
        }

        private void btnReporteAmortizacion_Click(object sender, EventArgs e)
        {
            new FrmAmortizacion().ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}