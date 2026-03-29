using System;
using System.Windows.Forms;
using SisemaPrestamo.Servicios;

namespace SisemaPrestamo.Formularios
{
    public partial class FrmPrestamos : Form
    {
        private readonly PrestamoService service = new PrestamoService();

        public FrmPrestamos()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal monto = decimal.Parse(txtMonto.Text);
            int meses = int.Parse(txtMeses.Text);

            var tasa = service.ObtenerTasaPorMeses(meses);
            var interes = service.CalcularInteres(monto, tasa);
            var total = service.CalcularMontoTotal(monto, interes);
            var cuota = service.CalcularCuotaMensual(total, meses);

            lblTasa.Text = tasa.ToString();
            lblInteres.Text = interes.ToString();
            lblTotal.Text = total.ToString();
            lblCuota.Text = cuota.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var resultado = service.CrearPrestamo(
                int.Parse(txtClienteId.Text),
                decimal.Parse(txtMonto.Text),
                int.Parse(txtMeses.Text)
            );

            MessageBox.Show(resultado);
        }
    }
}