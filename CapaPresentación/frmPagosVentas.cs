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
    public partial class frmPagosVentas: Form
    {
        CDpagosventas cd_pagosventas = new CDpagosventas();
        CLpagosVentas cl_pagosventas = new CLpagosVentas();

        //LLENAR COMBOBOX CON LISTA DE VENTAS
        private void MtdMostrarListaVentas()
        {
            var ListaVentas = cd_pagosventas.MtdListarVentas();

            foreach (var Ventas in ListaVentas)
            {
                cboxCodigoVenta.Items.Add(Ventas);
            }

            cboxCodigoVenta.DisplayMember = "Text";
            cboxCodigoVenta.ValueMember = "Value";
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
            MtdMostrarListaVentas();
            MtdConsultarVentas();
            lblFecha.Text = cl_pagosventas.MtdFechaActual().ToString("dd/MM/yyyy");
        }

        private void mtdLimpiarCampos()
        {
            txtCodigoPago.Text = "";
            cboxCodigoVenta.Text = "";
            lblMonto.Text = "";
            cboxTipoPago.Text = "";
            txtNumReferencia.Text = "";
            cboxEstado.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoVenta = int.Parse(cboxCodigoVenta.Text.Split('-')[0].Trim());
                decimal Monto = decimal.Parse(lblMonto.Text);
                string TipoPago = cboxTipoPago.Text;
                string NumReferencia = txtNumReferencia.Text;
                DateTime FechaPago = dtpFechaPago.Value;
                string Estado = cboxEstado.Text;
                string UsuarioAuditoria = "Admin"; //Hay que cambiarlo
                DateTime FechaAuditoria = cl_pagosventas.MtdFechaActual();

                cd_pagosventas.MtdAgregarPagosVentas(CodigoVenta, Monto, TipoPago, NumReferencia, FechaPago, Estado, UsuarioAuditoria, FechaAuditoria);
                MessageBox.Show("Pago agregado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarVentas();
                mtdLimpiarCampos();
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
                int CodigoPago = int.Parse(txtCodigoPago.Text);
                int CodigoVenta = int.Parse(cboxCodigoVenta.Text.Split('-')[0].Trim());
                decimal Monto = decimal.Parse(lblMonto.Text);
                string TipoPago = cboxTipoPago.Text;
                string NumReferencia = txtNumReferencia.Text;
                DateTime FechaPago = dtpFechaPago.Value;
                string Estado = cboxEstado.Text;
                string UsuarioAuditoria = "Admin"; //Hay que cambiarlo
                DateTime FechaAuditoria = cl_pagosventas.MtdFechaActual();

                cd_pagosventas.MtdActualizarPagosVentas(CodigoPago, CodigoVenta, Monto, TipoPago, NumReferencia, FechaPago, Estado, UsuarioAuditoria, FechaAuditoria);
                MessageBox.Show("Pago actualizado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarVentas();
                mtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cboxCodigoVenta.Text = dgvPagosVentas.SelectedCells[1].Value.ToString();
            lblMonto.Text = dgvPagosVentas.SelectedCells[2].Value.ToString();
            cboxTipoPago.Text = dgvPagosVentas.SelectedCells[3].Value.ToString();
            txtNumReferencia.Text = dgvPagosVentas.SelectedCells[4].Value.ToString();
            dtpFechaPago.Text = dgvPagosVentas.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgvPagosVentas.SelectedCells[6].Value.ToString();
        }

        private void cboxCodigoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMonto.Text = cd_pagosventas.MtdMonto(int.Parse(cboxCodigoVenta.Text.Split('-')[0].Trim())).ToString("0.00");
        }
    }
}
