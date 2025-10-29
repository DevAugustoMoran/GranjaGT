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
    public partial class FrmGranjas : Form
    {
        CDgranjas cdgranjas = new CDgranjas();
        CLgranjas clgranjas = new CLgranjas();

        public FrmGranjas()
        {
            InitializeComponent();
        }

        public void MtdConsultarGranjas()
        {
            DataTable dtgranjas = cdgranjas.MtdConsultarGranjas();
            dgvGranjas.DataSource = dtgranjas;
        }
        public void MtdLimpiarCampos()
        {
            txtCodigoGranja.Text = "";
            txtNombre.Text = "";
            txtDirección.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            cboxEstadoGranja.Text = "";
        }


        private void FrmGranjas_Load(object sender, EventArgs e)
        {
            lblFecha.Text = clgranjas.MtdFechaActual().ToString("dd/MM/yyyy");
            MtdConsultarGranjas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtDirección.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || cboxEstadoGranja.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string Nombre = txtNombre.Text;
                    string Direccion = txtDirección.Text;
                    string Telefono = txtTelefono.Text;
                    string Correo = txtCorreo.Text;
                    string EstadoGranja = cboxEstadoGranja.Text;
                    string UsuarioAuditoria = "Administrador";
                    DateTime FechaAuditoria = DateTime.Today;
                    cdgranjas.MtdAgregarGranja(Nombre, Direccion, Telefono, Correo, EstadoGranja, UsuarioAuditoria, FechaAuditoria.ToString());
                    MessageBox.Show("Granja agregada correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarGranjas();
                    MtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvGranjas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoGranja.Text = dgvGranjas.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvGranjas.SelectedCells[1].Value.ToString();
            txtDirección.Text = dgvGranjas.SelectedCells[2].Value.ToString();
            txtTelefono.Text = dgvGranjas.SelectedCells[3].Value.ToString();
            txtCorreo.Text = dgvGranjas.SelectedCells[4].Value.ToString();
            cboxEstadoGranja.Text = dgvGranjas.SelectedCells[5].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigoGranja.Text == "" || txtNombre.Text == "" || txtDirección.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || cboxEstadoGranja.Text == "")
            {
                MessageBox.Show("Por favor seleccione una granja para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoGranja = Convert.ToInt32(txtCodigoGranja.Text);
                    string Nombre = txtNombre.Text;
                    string Direccion = txtDirección.Text;
                    string Telefono = txtTelefono.Text;
                    string Correo = txtCorreo.Text;
                    string EstadoGranja = cboxEstadoGranja.Text;
                    string UsuarioAuditoria = "Administrador";
                    DateTime FechaAuditoria = DateTime.Today;
                    cdgranjas.MtdActualizarGranja(CodigoGranja, Nombre, Direccion, Telefono, Correo, EstadoGranja, UsuarioAuditoria, FechaAuditoria.ToString());
                    MessageBox.Show("Granja actualizada correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarGranjas();
                    MtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigoGranja.Text == "")
            {
                MessageBox.Show("Por favor seleccione una granja para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoGranja = Convert.ToInt32(txtCodigoGranja.Text);
                    cdgranjas.MtdEliminarGranja(CodigoGranja);
                    MessageBox.Show("Granja eliminada correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarGranjas();
                    MtdLimpiarCampos();
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
