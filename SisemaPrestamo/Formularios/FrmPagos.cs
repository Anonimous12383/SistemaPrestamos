using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using PrestamosApp.Datos;
using PrestamosApp.Services;

namespace PrestamosApp.Formularios
{
    public partial class FrmPagos : Form
    {
        private readonly PagoService _pagoService = new PagoService();

        public FrmPagos()
        {
            InitializeComponent();
        }

        private void FrmPagos_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagos.MultiSelect = false;
            dgvPagos.ReadOnly = true;

            CargarPrestamos();
            CargarPagos();
        }

        private void CargarPrestamos()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var activos = db.Prestamos
                        .Where(p => p.Estado == "ACTIVO")
                        .Select(p => new
                        {
                            p.PrestamoId,
                            Descripcion = "Préstamo #" + p.PrestamoId +
                                          " - Cliente ID: " + p.ClienteId +
                                          " - Saldo: " + p.SaldoPendiente
                        })
                        .ToList();

                    chkFuePagado.DataSource = null;
                    chkFuePagado.DisplayMember = "Descripcion";
                    chkFuePagado.ValueMember = "PrestamoId";
                    chkFuePagado.DataSource = activos;

                    chkFuePagado.SelectedIndex = activos.Count > 0 ? 0 : -1;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;

                if (ex.InnerException != null)
                    mensaje += "\n\nINNER: " + ex.InnerException.Message;

                if (ex.InnerException?.InnerException != null)
                    mensaje += "\n\nSQL: " + ex.InnerException.InnerException.Message;

                MessageBox.Show("Error al cargar préstamos:\n\n" + mensaje);
            }
        }

        private void CargarPagos()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var lista = db.Pagos
                        .Select(p => new
                        {
                            p.PagoId,
                            p.PrestamoId,
                            p.NumeroCuota,
                            p.FechaPago,
                            p.Cuota,
                            p.InteresPagado,
                            p.CapitalPagado,
                            p.Mora,
                            p.NuevoMontoDeuda,
                            p.MesesRestantes,
                            p.FuePagado
                        })
                        .ToList();

                    dgvPagos.DataSource = null;
                    dgvPagos.DataSource = lista;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;

                if (ex.InnerException != null)
                    mensaje += "\n\nINNER: " + ex.InnerException.Message;

                if (ex.InnerException?.InnerException != null)
                    mensaje += "\n\nSQL: " + ex.InnerException.InnerException.Message;

                MessageBox.Show("Error al cargar pagos:\n\n" + mensaje);
            }
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkFuePagado.SelectedIndex == -1 || chkFuePagado.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un préstamo.");
                    return;
                }

                int prestamoId = Convert.ToInt32(chkFuePagado.SelectedValue);

                // El control en el diseñador parece ser un ComboBox (tiene DataSource), por eso
                // no existe la propiedad Checked. Aquí comprobamos en tiempo de ejecución
                // si el control es realmente un CheckBox y usamos su Checked; en caso contrario
                // usamos un valor por defecto (false).
                System.Windows.Forms.Control control = chkFuePagado;
                var chkBox = control as System.Windows.Forms.CheckBox;
                bool fuePagado = chkBox != null && chkBox.Checked;

                string resultado = _pagoService.RegistrarPago(prestamoId, fuePagado);

                MessageBox.Show(resultado);

                CargarPrestamos();
                CargarPagos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar pago:\n\n" + ex.Message);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarPrestamos();
            CargarPagos();
        }
    }
}