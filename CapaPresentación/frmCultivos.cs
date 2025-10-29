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
    public partial class frmCultivos: Form
    {
        CDcultivos cdcultivos = new CDcultivos();
        CLcultivos clcultivos = new CLcultivos();

        public frmCultivos()
        {
            InitializeComponent();
        }

        public void mtdConsultarCultivos()
        {
            DataTable dtcultivos = cdcultivos.MtdConsultarCultivos();
            dgvCultivos.DataSource = dtcultivos;
        }

        public void mtdLimpiarCampos()
        {
            txtCodigoCultivo.Text = "";
            txtTipoCultivo.Text = "";
            dtpFechaSiembra.Value = DateTime.Today;
            dtpFechaCosecha.Value = DateTime.Today;
            txtCantidadCosecha.Text = "";
            txtPrecio.Text = "";
            txtUbicacion.Text = "";
            txtObservacion.Text = "";
            cboxEstado.Text = "";
        }

        private void frmCultivos_Load(object sender, EventArgs e)
        {
            lblFecha.Text = clcultivos.MtdFechaActual().ToString("dd/MM/yyyy");
            mtdConsultarCultivos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtTipoCultivo.Text == "" || txtCantidadCosecha.Text == "" || txtPrecio.Text == "" || txtUbicacion.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string TipoCultivo = txtTipoCultivo.Text;
                    DateTime Fechasiembra = dtpFechaSiembra.Value;
                    DateTime FechaCosecha = dtpFechaCosecha.Value;
                    Decimal CantidadCosecha = Convert.ToDecimal(txtCantidadCosecha.Text);
                    Decimal Precio = Convert.ToDecimal(txtPrecio.Text);
                    string Ubicacion = txtUbicacion.Text;
                    string Observacion = txtObservacion.Text;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = "Administrador";
                    DateTime FechaAuditoria = clcultivos.MtdFechaActual();
                    cdcultivos.MtdAgregarCultivo(TipoCultivo, Fechasiembra, FechaCosecha, CantidadCosecha, Precio, Ubicacion, Observacion, Estado, UsuarioAuditoria, FechaAuditoria);
                    MessageBox.Show("Cultivo agregado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarCultivos();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCultivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoCultivo.Text = dgvCultivos.SelectedCells[0].Value.ToString();
            txtTipoCultivo.Text = dgvCultivos.SelectedCells[1].Value.ToString();
            dtpFechaSiembra.Value = Convert.ToDateTime(dgvCultivos.SelectedCells[2].Value.ToString());
            dtpFechaCosecha.Value = Convert.ToDateTime(dgvCultivos.SelectedCells[3].Value.ToString());
            txtCantidadCosecha.Text = dgvCultivos.SelectedCells[4].Value.ToString();
            txtPrecio.Text = dgvCultivos.SelectedCells[5].Value.ToString();
            txtUbicacion.Text = dgvCultivos.SelectedCells[6].Value.ToString();
            txtObservacion.Text = dgvCultivos.SelectedCells[7].Value.ToString();
            cboxEstado.Text = dgvCultivos.SelectedCells[8].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigoCultivo.Text == "" || txtTipoCultivo.Text == "" || txtCantidadCosecha.Text == "" || txtPrecio.Text == "" || txtUbicacion.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoCultivo = Convert.ToInt32(txtCodigoCultivo.Text);
                    string TipoCultivo = txtTipoCultivo.Text;
                    DateTime Fechasiembra = dtpFechaSiembra.Value;
                    DateTime FechaCosecha = dtpFechaCosecha.Value;
                    Decimal CantidadCosecha = Convert.ToDecimal(txtCantidadCosecha.Text);
                    Decimal Precio = Convert.ToDecimal(txtPrecio.Text);
                    string Ubicacion = txtUbicacion.Text;
                    string Observacion = txtObservacion.Text;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = "Administrador";
                    DateTime FechaAuditoria = clcultivos.MtdFechaActual();
                    cdcultivos.MtdActualizarCultivo(CodigoCultivo, TipoCultivo, Fechasiembra, FechaCosecha, CantidadCosecha, Precio, Ubicacion, Observacion, Estado, UsuarioAuditoria, FechaAuditoria);
                    MessageBox.Show("Cultivo actualizado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarCultivos();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigoCultivo.Text == "")
            {
                MessageBox.Show("Por favor seleccione un cultivo para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoCultivo = Convert.ToInt32(txtCodigoCultivo.Text);
                    cdcultivos.MtdEliminarCultivo(CodigoCultivo);
                    MessageBox.Show("Cultivo eliminado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarCultivos();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
