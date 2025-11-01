using CapaDatos;
using CapaLogica;
using CapaPresentacion.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentación
{
    public partial class frmClientes: Form
    {
        CDclientes cdclientes = new CDclientes();
        CLclientes clclientes = new CLclientes();

        public frmClientes()
        {
            InitializeComponent();
        }

        public void mtdConsultarClientes()
        {
            DataTable dtclientes = cdclientes.MtdConsultarClientes();
            dgvClientes.DataSource = dtclientes;
        }

        public void mtdLimpiarCampos()
        {
            txtCodigoCliente.Text = "";
            txtNombre.Text = "";
            cboxTipo.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            cboxEstado.Text = "";
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            lblFecha.Text = clclientes.MtdFechaActual().ToString("dd/MM/yyyy");
            mtdConsultarClientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || cboxTipo.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtDireccion.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string Nombre = txtNombre.Text;
                    string Tipo = cboxTipo.Text;
                    string Telefono = txtTelefono.Text;
                    string Correo = txtCorreo.Text;
                    string Direccion = txtDireccion.Text;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = UserCache.Nombre;
                    DateTime FechaAuditoria = clclientes.MtdFechaActual();
                    cdclientes.MtdAgregarCliente(Nombre, Tipo, Telefono, Correo, Direccion, Estado, UsuarioAuditoria, FechaAuditoria.ToString());
                    MessageBox.Show("Cliente agregado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarClientes();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoCliente.Text = dgvClientes.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvClientes.SelectedCells[1].Value.ToString();
            cboxTipo.Text = dgvClientes.SelectedCells[2].Value.ToString();
            txtTelefono.Text = dgvClientes.SelectedCells[3].Value.ToString();
            txtCorreo.Text = dgvClientes.SelectedCells[4].Value.ToString();
            txtDireccion.Text = dgvClientes.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgvClientes.SelectedCells[6].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigoCliente.Text == "" || txtNombre.Text == "" || cboxTipo.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtDireccion.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor seleccione un cliente para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoCliente = Convert.ToInt32(txtCodigoCliente.Text);
                    string Nombre = txtNombre.Text;
                    string Tipo = cboxTipo.Text;
                    string Telefono = txtTelefono.Text;
                    string Correo = txtCorreo.Text;
                    string Direccion = txtDireccion.Text;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = UserCache.Nombre;
                    DateTime FechaAuditoria = clclientes.MtdFechaActual();
                    cdclientes.MtdActualizarCliente(CodigoCliente, Nombre, Tipo, Telefono, Correo, Direccion, Estado, UsuarioAuditoria, FechaAuditoria.ToString());
                    MessageBox.Show("Cliente actualizado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarClientes();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtdLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigoCliente.Text == "")
            {
                MessageBox.Show("Por favor seleccione un cliente para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoCliente = int.Parse(txtCodigoCliente.Text);

                    if (cdclientes.MtdConsultarVentas(CodigoCliente) == true)
                    {
                        MessageBox.Show("Hay otros formularios usando estos campos. No se puede eliminar", "Error al borrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        cdclientes.MtdEliminarCliente(CodigoCliente);
                        MessageBox.Show("Cliente eliminado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mtdConsultarClientes();
                        mtdLimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
