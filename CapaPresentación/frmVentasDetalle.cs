using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaLogica;
using CapaPresentacion.Seguridad;

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
            cboxCodigoAnimal.Items.Add("Ninguno");
            cboxCodigoCultivo.Items.Add("Ninguno");
            cboxCodigoProducto.Items.Add("Ninguno");

            cboxCodigoAnimal.SelectedIndex = 0;
            cboxCodigoCultivo.SelectedIndex = 0;
            cboxCodigoProducto.SelectedIndex = 0;

            this.cboxCodigoAnimal.SelectedIndexChanged += new System.EventHandler(this.AnyComboBox_SelectedIndexChanged);
            this.cboxCodigoCultivo.SelectedIndexChanged += new System.EventHandler(this.AnyComboBox_SelectedIndexChanged);
            this.cboxCodigoProducto.SelectedIndexChanged += new System.EventHandler(this.AnyComboBox_SelectedIndexChanged);

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

        private void mtdLimpiarCampos()
        {
            txtCodigoDetalle.Text = "";
            cboxCodigoVenta.Text = "";
            cboxCodigoAnimal.Text = "";
            cboxCodigoCultivo.Text = "";
            cboxCodigoProducto.Text = "";
            txtCantidad.Text = "";
            txtPrecioUnitario.Text = "";
            lblTotal.Text = "-";
            txtDescuento.Text = "";
            txtImpuesto.Text = "";
            lblTotalVenta.Text = "-";
            cboxEstado.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboxCodigoVenta.Text == "" || cboxCodigoAnimal.Text == "" || cboxCodigoCultivo.Text == "" || cboxCodigoProducto.Text == "" || txtCantidad.Text == "" 
                || txtPrecioUnitario.Text == "" || txtDescuento.Text == "" || txtImpuesto.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoVenta = int.Parse(cboxCodigoVenta.Text.Split('-')[0].Trim());

                    int CodigoAnimal = 0;
                    int CodigoCultivo = 0;
                    int CodigoProducto = 0;

                    if (cboxCodigoAnimal.Enabled && cboxCodigoAnimal.Text != "Ninguno")
                    {
                        CodigoAnimal = int.Parse(cboxCodigoAnimal.Text.Split('-')[0].Trim());
                    }

                    if (cboxCodigoCultivo.Enabled && cboxCodigoCultivo.Text != "Ninguno")
                    {
                        CodigoCultivo = int.Parse(cboxCodigoCultivo.Text.Split('-')[0].Trim());
                    }

                    if (cboxCodigoProducto.Enabled && cboxCodigoProducto.Text != "Ninguno")
                    {
                        CodigoProducto = int.Parse(cboxCodigoProducto.Text.Split('-')[0].Trim());
                    }

                   /* int CodigoAnimal = int.Parse(cboxCodigoAnimal.Text.Split('-')[0].Trim());
                    int CodigoCultivo = int.Parse(cboxCodigoCultivo.Text.Split('-')[0].Trim());
                    int CodigoProducto = int.Parse(cboxCodigoProducto.Text.Split('-')[0].Trim()); */
                    decimal Cantidad = decimal.Parse(txtCantidad.Text);
                    decimal PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                    decimal Total = cl_ventasdetalle.MtdCalcularTotal(Cantidad, PrecioUnitario);
                    decimal Descuento = decimal.Parse(txtDescuento.Text);
                    decimal Impuesto = decimal.Parse(txtImpuesto.Text);
                    decimal TotalVenta = cl_ventasdetalle.MtdCalcularTotalVenta(Total, Descuento, Impuesto);
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = UserCache.Nombre;
                    DateTime FechaAuditoria = cl_ventasdetalle.MtdFechaActual();

                    cd_ventasdetalle.MtdAgregarVentasDetalle(CodigoVenta, CodigoAnimal, CodigoCultivo, CodigoProducto, Cantidad, PrecioUnitario, Total, Descuento, Impuesto, TotalVenta, Estado, UsuarioAuditoria, FechaAuditoria);
                    MessageBox.Show("Detalle de venta agregado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarVentasDetalle();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cboxCodigoVenta.Text == "" || cboxCodigoAnimal.Text == "" || cboxCodigoCultivo.Text == "" || cboxCodigoProducto.Text == "" || txtCantidad.Text == ""
                || txtPrecioUnitario.Text == "" || txtDescuento.Text == "" || txtImpuesto.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoDetalle = int.Parse(txtCodigoDetalle.Text);
                    int CodigoVenta = int.Parse(cboxCodigoVenta.Text.Split('-')[0].Trim());

                    int CodigoAnimal = 0;
                    int CodigoCultivo = 0;
                    int CodigoProducto = 0;

                    if (cboxCodigoAnimal.Enabled && cboxCodigoAnimal.Text != "Ninguno")
                    {
                        CodigoAnimal = int.Parse(cboxCodigoAnimal.Text.Split('-')[0].Trim());
                    }

                    if (cboxCodigoCultivo.Enabled && cboxCodigoCultivo.Text != "Ninguno")
                    {
                        CodigoCultivo = int.Parse(cboxCodigoCultivo.Text.Split('-')[0].Trim());
                    }

                    if (cboxCodigoProducto.Enabled && cboxCodigoProducto.Text != "Ninguno")
                    {
                        CodigoProducto = int.Parse(cboxCodigoProducto.Text.Split('-')[0].Trim());
                    }

                   /*

                    int CodigoAnimal = int.Parse(cboxCodigoAnimal.Text.Split('-')[0].Trim());
                    int CodigoCultivo = int.Parse(cboxCodigoCultivo.Text.Split('-')[0].Trim());
                    int CodigoProducto = int.Parse(cboxCodigoProducto.Text.Split('-')[0].Trim()); */
                    decimal Cantidad = decimal.Parse(txtCantidad.Text);
                    decimal PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                    decimal Total = cl_ventasdetalle.MtdCalcularTotal(Cantidad, PrecioUnitario);
                    decimal Descuento = decimal.Parse(txtDescuento.Text);
                    decimal Impuesto = decimal.Parse(txtImpuesto.Text);
                    decimal TotalVenta = cl_ventasdetalle.MtdCalcularTotalVenta(Total, Descuento, Impuesto);
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = UserCache.Nombre;
                    DateTime FechaAuditoria = cl_ventasdetalle.MtdFechaActual();

                    cd_ventasdetalle.MtdActualizarVentasDetalle(CodigoDetalle, CodigoVenta, CodigoAnimal, CodigoCultivo, CodigoProducto, Cantidad, PrecioUnitario, Total, Descuento, Impuesto, TotalVenta, Estado, UsuarioAuditoria, FechaAuditoria);
                    MessageBox.Show("Detalle de venta actualizado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarVentasDetalle();
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
            int CodigoDetalle = int.Parse(txtCodigoDetalle.Text);

            cd_ventasdetalle.MtdEliminarVentasDetalle(CodigoDetalle);
            MessageBox.Show("Detalle de venta eliminado correctamente", "Eliminar Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            mtdConsultarVentasDetalle();
            mtdLimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtdLimpiarCampos();
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

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                lblTotal.Text = "-";
            }
            else if(txtPrecioUnitario.Text != "")
            {
                lblTotal.Text = cl_ventasdetalle.MtdCalcularTotal(decimal.Parse(txtCantidad.Text), decimal.Parse(txtPrecioUnitario.Text)).ToString();
                
                if(txtDescuento.Text != "" && txtImpuesto.Text != "")
                {
                    lblTotalVenta.Text = cl_ventasdetalle.MtdCalcularTotalVenta(decimal.Parse(lblTotal.Text), decimal.Parse(txtDescuento.Text), decimal.Parse(txtImpuesto.Text)).ToString();
                }
            }
        }

        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioUnitario.Text == "")
            {
                lblTotal.Text = "-";
            }
            else if(txtCantidad.Text != "")
            {
                lblTotal.Text = cl_ventasdetalle.MtdCalcularTotal(decimal.Parse(txtCantidad.Text), decimal.Parse(txtPrecioUnitario.Text)).ToString();
                
                if (txtDescuento.Text != "" && txtImpuesto.Text != "")
                {
                    lblTotalVenta.Text = cl_ventasdetalle.MtdCalcularTotalVenta(decimal.Parse(lblTotal.Text), decimal.Parse(txtDescuento.Text), decimal.Parse(txtImpuesto.Text)).ToString();
                }
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (txtDescuento.Text == "")
            {
                lblTotalVenta.Text = "-";
            }
            else if (txtImpuesto.Text != "" && txtCantidad.Text != "" && txtPrecioUnitario.Text != "")
            {
                lblTotalVenta.Text = cl_ventasdetalle.MtdCalcularTotalVenta(decimal.Parse(lblTotal.Text), decimal.Parse(txtDescuento.Text), decimal.Parse(txtImpuesto.Text)).ToString();

                if (txtCantidad.Text != "" && txtPrecioUnitario.Text != "")
                {
                    lblTotal.Text = cl_ventasdetalle.MtdCalcularTotal(decimal.Parse(txtCantidad.Text), decimal.Parse(txtPrecioUnitario.Text)).ToString();
                }
            }
        }

        private void txtImpuesto_TextChanged(object sender, EventArgs e)
        {
            if (txtImpuesto.Text == "")
            {
                lblTotalVenta.Text = "-";
            }
            else if (txtDescuento.Text != "" && txtCantidad.Text != "" && txtPrecioUnitario.Text != "")
            {
                lblTotalVenta.Text = cl_ventasdetalle.MtdCalcularTotalVenta(decimal.Parse(lblTotal.Text), decimal.Parse(txtDescuento.Text), decimal.Parse(txtImpuesto.Text)).ToString();
                
                if (txtCantidad.Text != "" && txtPrecioUnitario.Text != "")
                {
                    lblTotal.Text = cl_ventasdetalle.MtdCalcularTotal(decimal.Parse(txtCantidad.Text), decimal.Parse(txtPrecioUnitario.Text)).ToString();
                }
            }
        }

        private void AnyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox activeComboBox = (ComboBox)sender;

            if (activeComboBox.SelectedItem == null)
                return;

            bool isNinguno = (activeComboBox.SelectedItem.ToString() == "Ninguno");

            cboxCodigoAnimal.Enabled = isNinguno;
            cboxCodigoCultivo.Enabled = isNinguno;
            cboxCodigoProducto.Enabled = isNinguno;

            activeComboBox.Enabled = true;
        }

    }
}
