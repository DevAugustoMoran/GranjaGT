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
    public partial class frmInventarios: Form
    {

        CDinventarios cd_inventarios = new CDinventarios();
        CLinventarios cl_inventarios = new CLinventarios();

        public frmInventarios()
        {
            InitializeComponent();
        }

        private void frmInventarios_Load(object sender, EventArgs e)
        {
            MtdMostrarListaGranjas();
            MtdMostrarListaInsumos();
            MtdConsultarInventarios();
            lblFecha.Text = cl_inventarios.MtdFechaActual().ToString("dd/MM/yyyy");
        }

        private void MtdMostrarListaGranjas()
        {
            var ListaGranjas = cd_inventarios.MtdListarGranjas();

            foreach (var Granjas in ListaGranjas)
            {
                cboxCodigoGranja.Items.Add(Granjas);
            }

            cboxCodigoGranja.DisplayMember = "Text";
            cboxCodigoGranja.ValueMember = "Value";
        }

        private void MtdMostrarListaInsumos()
        {
            var ListaInsumos = cd_inventarios.MtdListarInsumos();

            foreach (var Insumos in ListaInsumos)
            {
                cboxCodigoInsumo.Items.Add(Insumos);
            }

            cboxCodigoInsumo.DisplayMember = "Text";
            cboxCodigoInsumo.ValueMember = "Value";
        }

        private void MtdConsultarInventarios()
        {
            DataTable dt_inventarios = cd_inventarios.MtdConsultarInventario();
            dgvInventario.DataSource = dt_inventarios;
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoInventario.Text = "";
            cboxCodigoGranja.Text = "";
            cboxCodigoInsumo.Text = "";
            txtCantidadDisponible.Text = "";
            txtCostoUnitario.Text = "";
            lblCostoTotal.Text = "-";
            dtpFechaRegistro.Value = DateTime.Now;
            cboxEstado.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoGranja = int.Parse(cboxCodigoGranja.Text.Split('-')[0].Trim());
                int CodigoInsumo = int.Parse(cboxCodigoInsumo.Text.Split('-')[0].Trim());
                decimal CantidadDisponible = decimal.Parse(txtCantidadDisponible.Text);
                decimal CostoUnitario = decimal.Parse(txtCostoUnitario.Text);
                decimal CostoTotal = 20; //Hay que cambiarlo
                DateTime FechaRegistro = dtpFechaRegistro.Value;
                string Estado = cboxEstado.Text;
                string UsuarioAuditoria = "Admin"; //Hay que cambiarlo
                DateTime FechaAuditoria = cl_inventarios.MtdFechaActual();

                cd_inventarios.MtdAgregarInventario(CodigoGranja, CodigoInsumo, CantidadDisponible, CostoUnitario, CostoTotal, FechaRegistro, Estado, UsuarioAuditoria, FechaAuditoria);
                MessageBox.Show("inventario agregado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                int CodigoInventario = int.Parse(txtCodigoInventario.Text);
                int CodigoGranja = int.Parse(cboxCodigoGranja.Text.Split('-')[0].Trim());
                int CodigoInsumo = int.Parse(cboxCodigoInsumo.Text.Split('-')[0].Trim());
                decimal CantidadDisponible = decimal.Parse(txtCantidadDisponible.Text);
                decimal CostoUnitario = decimal.Parse(txtCostoUnitario.Text);
                decimal CostoTotal = 20; //Hay que cambiarlo
                DateTime FechaRegistro = dtpFechaRegistro.Value;
                string Estado = cboxEstado.Text;
                string UsuarioAuditoria = "Admin"; //Hay que cambiarlo
                DateTime FechaAuditoria = cl_inventarios.MtdFechaActual();

                cd_inventarios.MtdActualizarInventario(CodigoInventario, CodigoGranja, CodigoInsumo, CantidadDisponible, CostoUnitario, CostoTotal, FechaRegistro, Estado, UsuarioAuditoria, FechaAuditoria);
                MessageBox.Show("inventario actualizado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int CodigoInventario = int.Parse(txtCodigoInventario.Text);

            cd_inventarios.MtdEliminarInventario(CodigoInventario);
            MessageBox.Show("Inventario eliminado correctamente", "Eliminar Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MtdConsultarInventarios();
            MtdLimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoInventario.Text = dgvInventario.SelectedCells[0].Value.ToString();
            cboxCodigoGranja.Text = dgvInventario.SelectedCells[1].Value.ToString();
            cboxCodigoInsumo.Text = dgvInventario.SelectedCells[2].Value.ToString();
            txtCantidadDisponible.Text = dgvInventario.SelectedCells[3].Value.ToString();
            txtCostoUnitario.Text = dgvInventario.SelectedCells[4].Value.ToString();
            lblCostoTotal.Text = dgvInventario.SelectedCells[5].Value.ToString();
            dtpFechaRegistro.Text = dgvInventario.SelectedCells[6].Value.ToString();
            cboxEstado.Text = dgvInventario.SelectedCells[7].Value.ToString();
        }
    }
}
