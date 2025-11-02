using Microsoft.Reporting.WinForms;
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
    public partial class frmComprobanteVenta: Form
    {
        public string CodigoPagoAMostrar { get; set; }
        public frmComprobanteVenta()
        {
            InitializeComponent();
        }

        private void frmComprobanteVenta_Load(object sender, EventArgs e)
        {
           
            try
            {

                if (string.IsNullOrEmpty(CodigoPagoAMostrar))
                {
                    MessageBox.Show("No se especificó un código de pago.");
                    this.Close();
                    return;
                }

                rvComprobanteVenta.ProcessingMode = ProcessingMode.Remote;
                string urlPublica = "http://ec2-3-15-196-194.us-east-2.compute.amazonaws.com/ReportServer";
                rvComprobanteVenta.ServerReport.ReportServerUrl = new Uri(urlPublica);
                rvComprobanteVenta.ServerReport.ReportPath = "/Comprobantes/ComprobantesVentas";

                string ec2User = "Administrator";
                string ec2Pass = "0n$uWytHI@Jas&UBLfJ!*EMkKfENeA4=";

                rvComprobanteVenta.ServerReport.ReportServerCredentials.NetworkCredentials =
                new System.Net.NetworkCredential(ec2User, ec2Pass);

                List<ReportParameter> parametros = new List<ReportParameter>();
                parametros.Add(new ReportParameter("CodigoDetalle", CodigoPagoAMostrar));
                rvComprobanteVenta.ServerReport.SetParameters(parametros);

                rvComprobanteVenta.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message);
            }
        }
    }
}
