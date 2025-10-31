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
    public partial class frmPagosVentas: Form
    {
        CDpagosventas cd_pagosventas = new CDpagosventas();
        CLpagosVentas cl_pagosventas = new CLpagosVentas();

        //LLENAR COMBOBOX CON LISTA DE VENTAS
        private void MtdMostrarListaDetallesVentas()
        {
            var ListaDetalles = cd_pagosventas.MtdListarDetallesVentas();

            foreach (var Detalles in ListaDetalles)
            {
                cboxCodigoDetalle.Items.Add(Detalles);
            }

            cboxCodigoDetalle.DisplayMember = "Text";
            cboxCodigoDetalle.ValueMember = "Value";
        }

        private void MtdConsultarVentas()
        {
            DataTable dtVentas = cd_pagosventas.MtdConsultarPagosVentas();
            dgvPagosVentas.DataSource = dtVentas;
        }

        public frmPagosVentas()
        {
            InitializeComponent();
        }

        private void frmPagosVentas_Load(object sender, EventArgs e)
        {
            MtdMostrarListaDetallesVentas();
            MtdConsultarVentas();
            lblFecha.Text = cl_pagosventas.MtdFechaActual().ToString("dd/MM/yyyy");
        }

        private void mtdLimpiarCampos()
        {
            txtCodigoPago.Text = "";
            cboxCodigoDetalle.Text = "";
            lblMonto.Text = "";
            cboxTipoPago.Text = "";
            txtNumReferencia.Text = "";
            cboxEstado.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboxCodigoDetalle.Text == "" || cboxTipoPago.Text == "" || txtNumReferencia.Text == "" || dtpFechaPago.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoVenta = int.Parse(cboxCodigoDetalle.Text.Split('-')[0].Trim());
                    decimal Monto = decimal.Parse(lblMonto.Text);
                    string TipoPago = cboxTipoPago.Text;
                    string NumReferencia = txtNumReferencia.Text;
                    DateTime FechaPago = dtpFechaPago.Value;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = UserCache.Nombre;
                    DateTime FechaAuditoria = cl_pagosventas.MtdFechaActual();
                    int CodigoDetalle = int.Parse(cboxCodigoDetalle.Text.Split('-')[0].Trim());

                    cd_pagosventas.MtdAgregarPagosVentas(Monto, TipoPago, NumReferencia, FechaPago, Estado, UsuarioAuditoria, FechaAuditoria, CodigoDetalle);
                    MessageBox.Show("Pago agregado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarVentas();
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
            if (cboxCodigoDetalle.Text == "" || cboxTipoPago.Text == "" || txtNumReferencia.Text == "" || dtpFechaPago.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoPago = int.Parse(txtCodigoPago.Text);
                    int CodigoVenta = int.Parse(cboxCodigoDetalle.Text.Split('-')[0].Trim());
                    decimal Monto = decimal.Parse(lblMonto.Text);
                    string TipoPago = cboxTipoPago.Text;
                    string NumReferencia = txtNumReferencia.Text;
                    DateTime FechaPago = dtpFechaPago.Value;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = UserCache.Nombre;
                    DateTime FechaAuditoria = cl_pagosventas.MtdFechaActual();
                    int CodigoDetalle = int.Parse(cboxCodigoDetalle.Text.Split('-')[0].Trim());

                    cd_pagosventas.MtdActualizarPagosVentas(CodigoPago, Monto, TipoPago, NumReferencia, FechaPago, Estado, UsuarioAuditoria, FechaAuditoria, CodigoDetalle);
                    MessageBox.Show("Pago actualizado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarVentas();
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
            int CodigoPago = int.Parse(txtCodigoPago.Text);

            cd_pagosventas.MtdEliminarPagosVentas(CodigoPago);
            MessageBox.Show("Pago eliminado correctamente", "Eliminar Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MtdConsultarVentas();
            mtdLimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPagosVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoPago.Text = dgvPagosVentas.SelectedCells[0].Value.ToString();
            cboxCodigoDetalle.Text = dgvPagosVentas.SelectedCells[8].Value.ToString();
            lblMonto.Text = dgvPagosVentas.SelectedCells[1].Value.ToString();
            cboxTipoPago.Text = dgvPagosVentas.SelectedCells[2].Value.ToString();
            txtNumReferencia.Text = dgvPagosVentas.SelectedCells[3].Value.ToString();
            dtpFechaPago.Text = dgvPagosVentas.SelectedCells[4].Value.ToString();
            cboxEstado.Text = dgvPagosVentas.SelectedCells[5].Value.ToString();
        }

        private void cboxCodigoDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMonto.Text = cd_pagosventas.MtdMonto(int.Parse(cboxCodigoDetalle.Text.Split('-')[0].Trim())).ToString("0.00");
        }
    }
}
