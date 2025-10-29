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
    public partial class frmRoles : Form
    {
        CDroles cdroles = new CDroles();
        CLroles clroles = new CLroles();

        public frmRoles()
        {
            InitializeComponent();
        }

        public void mtdConsultarRoles()
        {
            DataTable dtroles = cdroles.MtdConsultarRol();
            dgvRoles.DataSource = dtroles;
        }

        public void mtdLimpiarCampos()
        {
            txtCodigoRol.Text = "";
            txtNombreRol.Text = "";
            cboxEstado.Text = "";
            txtNivelAcceso.Text = "";
            txtDescripcion.Text = "";
            dtpFechaAuditoria.Value = DateTime.Now;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmRoles_Load(object sender, EventArgs e)
        {
            lblFecha.Text = clroles.MtdFechaActual().ToString("dd/MM/yyyy");
            mtdConsultarRoles();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (txtNombreRol.Text == "" || cboxEstado.Text == "" || txtNivelAcceso.Text == "" || txtDescripcion.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string NombreRol = txtNombreRol.Text;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = "Administrador";
                    string NivelAcceso = txtNivelAcceso.Text;
                    string Descripcion = txtDescripcion.Text;
                    DateTime FechaAuditoria = dtpFechaAuditoria.Value;
                    DateTime FechaCreacion = clroles.MtdFechaActual();

                    cdroles.MtdAgregarRol(NombreRol, Estado, UsuarioAuditoria, Convert.ToInt32(NivelAcceso), Descripcion, FechaAuditoria, FechaCreacion);
                    MessageBox.Show("Rol agregado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarRoles();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoRol.Text = dgvRoles.SelectedCells[0].Value.ToString();
            txtNombreRol.Text = dgvRoles.SelectedCells[1].Value.ToString();
            cboxEstado.Text = dgvRoles.SelectedCells[2].Value.ToString();
            txtNivelAcceso.Text = dgvRoles.SelectedCells[4].Value.ToString();
            txtDescripcion.Text = dgvRoles.SelectedCells[5].Value.ToString();
            dtpFechaAuditoria.Value = Convert.ToDateTime(dgvRoles.SelectedCells[6].Value);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigoRol.Text == "" || txtNombreRol.Text == "" || cboxEstado.Text == "" || txtNivelAcceso.Text == "" || txtDescripcion.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoRol = int.Parse(txtCodigoRol.Text);
                    string NombreRol = txtNombreRol.Text;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = "Administrador";
                    string NivelAcceso = txtNivelAcceso.Text;
                    string Descripcion = txtDescripcion.Text;
                    DateTime FechaAuditoria = dtpFechaAuditoria.Value;
                    DateTime FechaCreacion = clroles.MtdFechaActual();
                    cdroles.MtdActualizarRol(CodigoRol, NombreRol, Estado, UsuarioAuditoria, Convert.ToInt32(NivelAcceso), Descripcion, FechaAuditoria, FechaCreacion);
                    MessageBox.Show("Rol actualizado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarRoles();
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
            if(txtCodigoRol.Text == "")
            {
                MessageBox.Show("Por favor seleccione un rol para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoRol = int.Parse(txtCodigoRol.Text);
                    cdroles.MtdEliminarRol(CodigoRol);
                    MessageBox.Show("Rol eliminado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarRoles();
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
