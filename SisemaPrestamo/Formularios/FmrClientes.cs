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
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
        private void CargarClientes()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var lista = db.Clientes
                        .Select(c => new
                        {
                            c.ClienteId,
                            c.NombreCompleto,
                            c.Correo,
                            c.Telefono,
                            c.Direccion,
                            c.Garantia,
                            c.SueldoMensual
                        })
                        .ToList();

                    dgvClientes.DataSource = null;
                    dgvClientes.DataSource = lista;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;

                if (ex.InnerException != null)
                    mensaje += "\n\nINNER: " + ex.InnerException.Message;

                if (ex.InnerException?.InnerException != null)
                    mensaje += "\n\nSQL: " + ex.InnerException.InnerException.Message;

                MessageBox.Show("Error al cargar clientes:\n\n" + mensaje);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var cliente = new Cliente
                    {
                        NombreCompleto = txtNombre.Text,
                        Correo = txtCorreo.Text,
                        Telefono = txtTelefono.Text,
                        Direccion = txtDireccion.Text,
                        Garantia = txtGarantia.Text,
                        Sueldo = decimal.Parse(txtSueldo.Text),
                        Activo = true
                    };

                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                }

                MessageBox.Show("Cliente guardado correctamente");
                CargarClientes();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;

                if (ex.InnerException != null)
                    mensaje += "\n\nINNER: " + ex.InnerException.Message;

                if (ex.InnerException?.InnerException != null)
                    mensaje += "\n\nSQL: " + ex.InnerException.InnerException.Message;

                MessageBox.Show("Error al guardar:\n\n" + mensaje);
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

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarClientes();
                MessageBox.Show("Lista de clientes actualizada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un cliente.");
                    return;
                }

                int clienteId = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteId"].Value);

                var confirmacion = MessageBox.Show(
                    "¿Seguro que deseas eliminar este cliente?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion == DialogResult.No)
                    return;

                using (var db = new AppDbContext())
                {
                    var cliente = db.Clientes.FirstOrDefault(c => c.ClienteId == clienteId);

                    if (cliente == null)
                    {
                        MessageBox.Show("Cliente no encontrado.");
                        return;
                    }

   
                    var tienePrestamos = db.Prestamos.Any(p => p.ClienteId == clienteId);

                    if (tienePrestamos)
                    {
                        MessageBox.Show("No se puede eliminar este cliente porque tiene préstamos.");
                        return;
                    }

                    db.Clientes.Remove(cliente);
                    db.SaveChanges();
                }

                MessageBox.Show("Cliente eliminado correctamente.");
                CargarClientes();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;

                if (ex.InnerException != null)
                    mensaje += "\n\nINNER: " + ex.InnerException.Message;

                if (ex.InnerException?.InnerException != null)
                    mensaje += "\n\nSQL: " + ex.InnerException.InnerException.Message;

                MessageBox.Show("Error al eliminar:\n\n" + mensaje);
            }
        }
    }
}