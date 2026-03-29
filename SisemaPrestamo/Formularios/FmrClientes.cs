using PrestamosApp.Datos;
using PrestamosApp.Entidades;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SisemaPrestamo.Formularios
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            using (var db = new AppDbContext())
            {
                dgvClientes.DataSource = db.Clientes.ToList();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre");
                return;
            }

            if (!decimal.TryParse(txtSueldo.Text, out decimal sueldo))
            {
                MessageBox.Show("Ingrese un sueldo válido");
                return;
            }

            using (var db = new AppDbContext())
            {
                var cliente = new Cliente
                {
                    NombreCompleto = txtNombre.Text,
                    Correo = txtCorreo.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Garantia = txtGarantia.Text,
                    Sueldo = sueldo,
                    Activo = true
                };

                db.Clientes.Add(cliente);
                db.SaveChanges();

                MessageBox.Show("Cliente guardado correctamente");

                LimpiarCampos();
                CargarClientes();
            }
        }

        
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtGarantia.Clear();
            txtSueldo.Clear();
        }
    }
}