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
    public partial class frmProductos: Form
    {
        CDproductos cdproductos = new CDproductos();
        CLproductos clproductos = new CLproductos();

        public frmProductos()
        {
            InitializeComponent();
        }

        public void mtdConsultarProductos()
        {
            DataTable dtproductos = cdproductos.MtdConsultarProductos();
            dgvProductos.DataSource = dtproductos;
        }

        public void mtdLimpiarCampos()
        {
            txtCodigoProducto.Text = "";
            txtNombre.Text = "";
            cboxTipoProducto.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            dtpFechaIngreso.Value = DateTime.Today;
            dtpFechaVencimiento.Value = DateTime.Today;
            cboxEstado.Text = "";

        }


        private void frmProductos_Load(object sender, EventArgs e)
        {
            lblFecha.Text = clproductos.MtdFechaActual().ToString("dd/MM/yyyy");
            mtdConsultarProductos();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoProducto.Text = dgvProductos.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvProductos.SelectedCells[1].Value.ToString();
            cboxTipoProducto.Text = dgvProductos.SelectedCells[2].Value.ToString();
            txtPrecio.Text = dgvProductos.SelectedCells[3].Value.ToString();
            txtStock.Text = dgvProductos.SelectedCells[4].Value.ToString();
            dtpFechaIngreso.Value = Convert.ToDateTime(dgvProductos.SelectedCells[5].Value);
            dtpFechaVencimiento.Value = Convert.ToDateTime(dgvProductos.SelectedCells[6].Value);
            cboxEstado.Text = dgvProductos.SelectedCells[7].Value.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtdLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text == "")
            {
                MessageBox.Show("Por favor seleccione un producto para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoProducto = Convert.ToInt32(txtCodigoProducto.Text);
                    cdproductos.MtdEliminarProducto(CodigoProducto);
                    MessageBox.Show("Producto eliminado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarProductos();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || cboxTipoProducto.Text == "" || txtPrecio.Text == "" || txtStock.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string Nombre = txtNombre.Text;
                    string TipoProducto = cboxTipoProducto.Text;
                    Decimal Precio = Convert.ToDecimal(txtPrecio.Text);
                    int Stock = Convert.ToInt32(txtStock.Text);
                    DateTime FechaIngreso = dtpFechaIngreso.Value;
                    DateTime FechaVencimiento = dtpFechaVencimiento.Value;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = "Administrador";
                    DateTime FechaAuditoria = clproductos.MtdFechaActual();
                    cdproductos.MtdAgregarProducto(Nombre, TipoProducto, Precio, Stock, FechaIngreso, FechaVencimiento, Estado, UsuarioAuditoria, FechaAuditoria);
                    MessageBox.Show("Producto agregado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarProductos();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text == "" || txtNombre.Text == "" || cboxTipoProducto.Text == "" || txtPrecio.Text == "" || txtStock.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor seleccione un producto para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoProducto = Convert.ToInt32(txtCodigoProducto.Text);
                    string Nombre = txtNombre.Text;
                    string TipoProducto = cboxTipoProducto.Text;
                    Decimal Precio = Convert.ToDecimal(txtPrecio.Text);
                    int Stock = Convert.ToInt32(txtStock.Text);
                    DateTime FechaIngreso = dtpFechaIngreso.Value;
                    DateTime FechaVencimiento = dtpFechaVencimiento.Value;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = "Administrador";
                    DateTime FechaAuditoria = clproductos.MtdFechaActual();
                    cdproductos.MtdActualizarProducto(CodigoProducto, Nombre, TipoProducto, Precio, Stock, FechaIngreso, FechaVencimiento, Estado, UsuarioAuditoria, FechaAuditoria);
                    MessageBox.Show("Producto actualizado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarProductos();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
