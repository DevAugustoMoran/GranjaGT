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
    public partial class frmMenuComprobantes: Form
    {
        public frmMenuComprobantes()
        {
            InitializeComponent();
        }

        private void frmComprobantes_Load(object sender, EventArgs e)
        {

        }

        private void btnComprobantePago_Click(object sender, EventArgs e)
        {
            string idDePago = txtCodigoPago.Text;

            frmComprobantePago formularioReporte = new frmComprobantePago();

            formularioReporte.CodigoPagoAMostrar = idDePago;

            formularioReporte.Show();
        }

        private void frmMenuComprobantes_Load(object sender, EventArgs e)
        {
           
        }

        private void btnComprobanteEnvio_Click(object sender, EventArgs e)
        {
            string idDePago = txtCodigoEnvio.Text;

            frmComprobanteEnvio formularioReporte = new frmComprobanteEnvio();

            formularioReporte.CodigoPagoAMostrar = idDePago;

            formularioReporte.Show();
        }

        private void btnComprobanteVenta_Click(object sender, EventArgs e)
        {
            string idDePago = txtCodigoDetalle.Text;

            frmComprobanteVenta formularioReporte = new frmComprobanteVenta();

            formularioReporte.CodigoPagoAMostrar = idDePago;

            formularioReporte.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigoPago_Enter(object sender, EventArgs e)
        {
            if (txtCodigoPago.Text == "Codigo Pago")
            {
                
                txtCodigoPago.Text = "";

                txtCodigoPago.ForeColor = Color.Black;
            }
        }

        private void txtCodigoPago_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoPago.Text))
            {
                txtCodigoPago.Text = "Codigo Pago";

                txtCodigoPago.ForeColor = Color.LightGray;
            }
        }

        private void txtCodigoEnvio_Enter(object sender, EventArgs e)
        {
            if (txtCodigoEnvio.Text == "Codigo Envio")
            {

                txtCodigoEnvio.Text = "";

                txtCodigoEnvio.ForeColor = Color.Black;
            }

        }

        private void txtCodigoEnvio_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoEnvio.Text))
            {
                txtCodigoEnvio.Text = "Codigo Envio";

                txtCodigoEnvio.ForeColor = Color.LightGray;
            }
        }

        private void txtCodigoDetalle_Enter(object sender, EventArgs e)
        {
            if (txtCodigoDetalle.Text == "Codigo Detalle")
            {

                txtCodigoDetalle.Text = "";

                txtCodigoDetalle.ForeColor = Color.Black;
            }
        }

        private void txtCodigoDetalle_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoDetalle.Text))
            {
                txtCodigoDetalle.Text = "Codigo Detalle";

                txtCodigoDetalle.ForeColor = Color.LightGray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            FrmDashVentas FormDash = new FrmDashVentas();



            FormDash.Show();
        }
    }
}
