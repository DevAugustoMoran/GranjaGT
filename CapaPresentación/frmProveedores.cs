using CapaDatos;
using CapaLogica;
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
    public partial class frmProveedores: Form
    {
        CDproveedores cdproveedores = new CDproveedores();
        CLproveedores clproveedores = new CLproveedores();

        public frmProveedores()
        {
            InitializeComponent();
        }

        public void mtdConsultarProveedores()
        {
            DataTable dtproveedores = cdproveedores.MtdConsultarProveedores();
            dgvProveedores.DataSource = dtproveedores;
        }

        public void mtdLimpiarCampos()
        {
            txtCodigoProveedor.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            cboxEstado.Text = "";
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {

            lblFecha.Text = clproveedores.MtdFechaActual().ToString("dd/MM/yyyy");
            mtdConsultarProveedores();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {


            if(txtNombre.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtDireccion.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string Nombre = txtNombre.Text;
                    string Telefono = txtTelefono.Text;
                    string Correo = txtCorreo.Text;
                    string Direccion = txtDireccion.Text;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = "Administrador";
                    DateTime FechaAuditoria = clproveedores.MtdFechaActual();

                    cdproveedores.MtdAgregarProveedor(Nombre, Telefono, Correo, Direccion, Estado, UsuarioAuditoria, FechaAuditoria);
                    MessageBox.Show("Proveedor agregado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarProveedores();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoProveedor.Text = dgvProveedores.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvProveedores.SelectedCells[1].Value.ToString();
            txtTelefono.Text = dgvProveedores.SelectedCells[2].Value.ToString();
            txtCorreo.Text = dgvProveedores.SelectedCells[3].Value.ToString();
            txtDireccion.Text = dgvProveedores.SelectedCells[4].Value.ToString();
            cboxEstado.Text = dgvProveedores.SelectedCells[5].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(txtCodigoProveedor.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtDireccion.Text == "" || cboxEstado.Text == "" )
            {
                MessageBox.Show("Por favor seleccione un proveedor para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoProveedor = Convert.ToInt32(txtCodigoProveedor.Text);
                    string Nombre = txtNombre.Text;
                    string Telefono = txtTelefono.Text;
                    string Correo = txtCorreo.Text;
                    string Direccion = txtDireccion.Text;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = "Administrador";
                    DateTime FechaAuditoria = clproveedores.MtdFechaActual();
                    cdproveedores.MtdActualizarProveedor(CodigoProveedor, Nombre, Telefono, Correo, Direccion, Estado, UsuarioAuditoria, FechaAuditoria);
                    MessageBox.Show("Proveedor actualizado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarProveedores();
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
            if (txtCodigoProveedor.Text == "")
            {
                MessageBox.Show("Por favor seleccione un proveedor para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoProveedor = Convert.ToInt32(txtCodigoProveedor.Text);
                    cdproveedores.MtdEliminarProveedor(CodigoProveedor);
                    MessageBox.Show("Proveedor eliminado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarProveedores();
                    mtdLimpiarCampos();
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
    }
}
