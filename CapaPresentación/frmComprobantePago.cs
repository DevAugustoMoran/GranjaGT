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
    public partial class frmComprobantePago: Form
    {
        public string CodigoPagoAMostrar { get; set; }

        public frmComprobantePago()
        {
            InitializeComponent();
        }

        private void frmComprobantePago_Load(object sender, EventArgs e)
        {
            try
            {

                    if (string.IsNullOrEmpty(CodigoPagoAMostrar))
                    {
                    MessageBox.Show("No se especificó un código de pago.");
                    this.Close();
                    return;
                    }

                rvComprobantePago.ProcessingMode = ProcessingMode.Remote;
                string urlPublica = "http://ec2-3-15-196-194.us-east-2.compute.amazonaws.com/ReportServer";
                rvComprobantePago.ServerReport.ReportServerUrl = new Uri(urlPublica);
                rvComprobantePago.ServerReport.ReportPath = "/Comprobantes/ComprobantePagos";

                string ec2User = "Administrator";
                string ec2Pass = "0n$uWytHI@Jas&UBLfJ!*EMkKfENeA4=";

                rvComprobantePago.ServerReport.ReportServerCredentials.NetworkCredentials =
                new System.Net.NetworkCredential(ec2User, ec2Pass);

                List<ReportParameter> parametros = new List<ReportParameter>();
                parametros.Add(new ReportParameter("CodigoPago", CodigoPagoAMostrar));
                rvComprobantePago.ServerReport.SetParameters(parametros);

                rvComprobantePago.RefreshReport();

                }
            catch (Exception ex)
            {
                    MessageBox.Show("Error al cargar el reporte: " + ex.Message);
            }
        }
    }
}
