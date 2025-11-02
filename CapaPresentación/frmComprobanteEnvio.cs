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
    public partial class frmComprobanteEnvio: Form
    {
        public string CodigoPagoAMostrar { get; set; }

        public frmComprobanteEnvio()
        {
            InitializeComponent();
        }

        private void frmComprobanteEnvio_Load(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(CodigoPagoAMostrar))
                {
                    MessageBox.Show("No se especificó un código de pago.");
                    this.Close();
                    return;
                }

                rvComprobanteEnvio.ProcessingMode = ProcessingMode.Remote;
                string urlPublica = "http://ec2-3-15-196-194.us-east-2.compute.amazonaws.com/ReportServer";
                rvComprobanteEnvio.ServerReport.ReportServerUrl = new Uri(urlPublica);
                rvComprobanteEnvio.ServerReport.ReportPath = "/Comprobantes/ComprobanteEnvios";

                string ec2User = "Administrator";
                string ec2Pass = "0n$uWytHI@Jas&UBLfJ!*EMkKfENeA4=";

                rvComprobanteEnvio.ServerReport.ReportServerCredentials.NetworkCredentials =
                new System.Net.NetworkCredential(ec2User, ec2Pass);

                List<ReportParameter> parametros = new List<ReportParameter>();
                parametros.Add(new ReportParameter("CodigoEnvios", CodigoPagoAMostrar));
                rvComprobanteEnvio.ServerReport.SetParameters(parametros);

                rvComprobanteEnvio.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message);
            }
        }
    }
}
