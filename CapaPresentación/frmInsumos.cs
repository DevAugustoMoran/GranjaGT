using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaLogica;

namespace CapaPresentación
{
    public partial class frmInsumos: Form
    {
        CDinsumos cd_insumos = new CDinsumos();
        CLinsumos cl_insumos = new CLinsumos();

        public frmInsumos()
        {
            InitializeComponent();
        }

        private void frmInsumos_Load(object sender, EventArgs e)
        {
            MtdMostrarListaProveedores();
            MtdConsultarInventarios();
            lblFecha.Text = cl_insumos.MtdFechaActual().ToString("dd/MM/yyyy");
        }

        private void MtdMostrarListaProveedores()
        {
            var ListaProveedores = cd_insumos.MtdListarProveedores();

            foreach (var Proveedores in ListaProveedores)
            {
                cboxCodigoProveedor.Items.Add(Proveedores);
            }

            cboxCodigoProveedor.DisplayMember = "Text";
            cboxCodigoProveedor.ValueMember = "Value";
        }

        private void MtdConsultarInventarios()
        {
            DataTable dt_inventarios = cd_insumos.MtdConsultarInsumos();
            dgvInsumos.DataSource = dt_inventarios;
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoInsumo.Text = "";
            cboxCodigoProveedor.Text = "";
            txtNombre.Text = "";
            cboxTipoInsumo.Text = "";
            txtCostoUnitario.Text = "";
            cboxUnidadMedida.Text = "";
            txtPeso.Text = "";
            txtObservacion.Text = "";
            cboxEstado.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoProveedor = int.Parse(cboxCodigoProveedor.Text.Split('-')[0].Trim());
                string Nombre = txtNombre.Text;
                string TipoInsumo = cboxTipoInsumo.Text;
                decimal CostoUnitario = decimal.Parse(txtCostoUnitario.Text);
                string UnidadMedida = cboxUnidadMedida.Text;
                decimal Peso = decimal.Parse(txtPeso.Text);
                string Observacion = txtObservacion.Text;
                string Estado = cboxEstado.Text;
                string UsuarioAuditoria = "Admin"; //Hay que cambiarlo
                DateTime FechaAuditoria = cl_insumos.MtdFechaActual();

                cd_insumos.MtdAgregarInsumos(CodigoProveedor, Nombre, TipoInsumo, CostoUnitario, UnidadMedida, Peso, Observacion, Estado, UsuarioAuditoria, FechaAuditoria);
                MessageBox.Show("Insumo agregado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarInventarios();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoInsumo = int.Parse(txtCodigoInsumo.Text);
                int CodigoProveedor = int.Parse(cboxCodigoProveedor.Text.Split('-')[0].Trim());
                string Nombre = txtNombre.Text;
                string TipoInsumo = cboxTipoInsumo.Text;
                decimal CostoUnitario = decimal.Parse(txtCostoUnitario.Text);
                string UnidadMedida = cboxUnidadMedida.Text;
                decimal Peso = decimal.Parse(txtPeso.Text);
                string Observacion = txtObservacion.Text;
                string Estado = cboxEstado.Text;
                string UsuarioAuditoria = "Admin"; //Hay que cambiarlo
                DateTime FechaAuditoria = cl_insumos.MtdFechaActual();

                cd_insumos.MtdActualizarInsumos(CodigoInsumo, CodigoProveedor, Nombre, TipoInsumo, CostoUnitario, UnidadMedida, Peso, Observacion, Estado, UsuarioAuditoria, FechaAuditoria);
                MessageBox.Show("Insumo actualizado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarInventarios();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int CodigoInsumo = int.Parse(txtCodigoInsumo.Text);

            cd_insumos.MtdEliminarInsumos(CodigoInsumo);
            MessageBox.Show("Insumo eliminado correctamente", "Eliminar Insumo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MtdConsultarInventarios();
            MtdLimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvInsumos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoInsumo.Text = dgvInsumos.SelectedCells[0].Value.ToString();
            cboxCodigoProveedor.Text = dgvInsumos.SelectedCells[1].Value.ToString();
            txtNombre.Text = dgvInsumos.SelectedCells[2].Value.ToString();
            cboxTipoInsumo.Text = dgvInsumos.SelectedCells[3].Value.ToString();
            txtCostoUnitario.Text = dgvInsumos.SelectedCells[4].Value.ToString();
            cboxUnidadMedida.Text = dgvInsumos.SelectedCells[5].Value.ToString();
            txtPeso.Text = dgvInsumos.SelectedCells[6].Value.ToString();
            txtObservacion.Text = dgvInsumos.SelectedCells[7].Value.ToString();
            cboxEstado.Text = dgvInsumos.SelectedCells[8].Value.ToString();
        }
    }
}
