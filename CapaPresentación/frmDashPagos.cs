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
    public partial class frmDashPagos: Form
    {
        public frmDashPagos()
        {
            InitializeComponent();
        }

        private void frmDashPagos_Load(object sender, EventArgs e)
        {
            try
            {
                rvDashboardPagos.ProcessingMode = ProcessingMode.Remote;
                string urlPublica = "http://ec2-3-15-196-194.us-east-2.compute.amazonaws.com/ReportServer";
                rvDashboardPagos.ServerReport.ReportServerUrl = new Uri(urlPublica);
                rvDashboardPagos.ServerReport.ReportPath = "/Dashboard dbgranjaGT/DashboardPagos";

                string ec2User = "Administrator";
                string ec2Pass = "0n$uWytHI@Jas&UBLfJ!*EMkKfENeA4=";

                rvDashboardPagos.ServerReport.ReportServerCredentials.NetworkCredentials =
                new System.Net.NetworkCredential(ec2User, ec2Pass);

                rvDashboardPagos.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message);
            }
        }
    }
}
