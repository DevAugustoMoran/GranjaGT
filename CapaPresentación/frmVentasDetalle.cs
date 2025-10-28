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
    public partial class frmVentasDetalle: Form
    {
        CDventasDetalle cd_ventasdetalle = new CDventasDetalle();
        CLventasDetalle cl_ventasdetalle = new CLventasDetalle();

        public frmVentasDetalle()
        {
            InitializeComponent();
        }

        private void frmVentasDetalle_Load(object sender, EventArgs e)
        {
            MtdMostrarListaVenta();
            MtdMostrarListaAnimal();
            MtdMostrarListaCultivo();
            MtdMostrarListaProducto();
            mtdConsultarVentasDetalle();
            lblFecha.Text = cl_ventasdetalle.MtdFechaActual().ToString("dd/MM/yyyy");
        }

        private void MtdMostrarListaVenta()
        {
            var ListaVentas = cd_ventasdetalle.MtdListarVentas();

            foreach (var Ventas in ListaVentas)
            {
                cboxCodigoVenta.Items.Add(Ventas);
            }

            cboxCodigoVenta.DisplayMember = "Text";
            cboxCodigoVenta.ValueMember = "Value";
        }

        private void MtdMostrarListaAnimal()
        {
            var ListaAnimal = cd_ventasdetalle.MtdListarAnimal();

            foreach (var Animal in ListaAnimal)
            {
                cboxCodigoAnimal.Items.Add(Animal);
            }

            cboxCodigoAnimal.DisplayMember = "Text";
            cboxCodigoAnimal.ValueMember = "Value";
        }

        private void MtdMostrarListaCultivo()
        {
            var ListaCultivo = cd_ventasdetalle.MtdListarCultivo();

            foreach (var Cultivo in ListaCultivo)
            {
                cboxCodigoCultivo.Items.Add(Cultivo);
            }

            cboxCodigoCultivo.DisplayMember = "Text";
            cboxCodigoCultivo.ValueMember = "Value";
        }

        private void MtdMostrarListaProducto()
        {
            var ListaProductos = cd_ventasdetalle.MtdListarProducto();

            foreach (var Productos in ListaProductos)
            {
                cboxCodigoProducto.Items.Add(Productos);
            }

            cboxCodigoProducto.DisplayMember = "Text";
            cboxCodigoProducto.ValueMember = "Value";
        }

        private void mtdConsultarVentasDetalle()
        {
            DataTable dtVentasDetalle = cd_ventasdetalle.MtdConsultarVentasDetalle();
            dgvVentasDetalle.DataSource = dtVentasDetalle;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoVenta = int.Parse(cboxCodigoVenta.Text.Split('-')[0].Trim());
                int CodigoAnimal = int.Parse(cboxCodigoAnimal.Text.Split('-')[0].Trim());
                int CodigoCultivo = int.Parse(cboxCodigoCultivo.Text.Split('-')[0].Trim());
                int CodigoProducto = int.Parse(cboxCodigoProducto.Text.Split('-')[0].Trim());
                decimal Cantidad = decimal.Parse(txtCantidad.Text);
                decimal PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                decimal Total = 10; //Hay que cambiarlo
                decimal Descuento = decimal.Parse(txtDescuento.Text);
                decimal Impuesto = decimal.Parse(txtImpuesto.Text);
                decimal TotalVenta = 20; //Hay que cambiarlo
                string Estado = cboxEstado.Text;
                string UsuarioAuditoria = "Admin"; //Hay que cambiarlo
                DateTime FechaAuditoria = cl_ventasdetalle.MtdFechaActual();

                cd_ventasdetalle.MtdAgregarVentasDetalle(CodigoVenta, CodigoAnimal, CodigoCultivo, CodigoProducto, Cantidad, PrecioUnitario, Total, Descuento, Impuesto, TotalVenta, Estado, UsuarioAuditoria, FechaAuditoria);
                MessageBox.Show("Detalle de venta agregado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dgvVentasDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoDetalle.Text = dgvVentasDetalle.SelectedCells[0].Value.ToString();
            cboxCodigoVenta.Text = dgvVentasDetalle.SelectedCells[1].Value.ToString();
            cboxCodigoAnimal.Text = dgvVentasDetalle.SelectedCells[2].Value.ToString();
            cboxCodigoCultivo.Text = dgvVentasDetalle.SelectedCells[3].Value.ToString();
            cboxCodigoProducto.Text = dgvVentasDetalle.SelectedCells[4].Value.ToString();
            txtCantidad.Text = dgvVentasDetalle.SelectedCells[5].Value.ToString();
            txtPrecioUnitario.Text = dgvVentasDetalle.SelectedCells[6].Value.ToString();
            lblTotal.Text = dgvVentasDetalle.SelectedCells[7].Value.ToString();
            txtDescuento.Text = dgvVentasDetalle.SelectedCells[8].Value.ToString();
            txtImpuesto.Text = dgvVentasDetalle.SelectedCells[9].Value.ToString();
            lblTotalVenta.Text = dgvVentasDetalle.SelectedCells[10].Value.ToString();
            cboxEstado.Text = dgvVentasDetalle.SelectedCells[11].Value.ToString();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dgvConsumos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}
