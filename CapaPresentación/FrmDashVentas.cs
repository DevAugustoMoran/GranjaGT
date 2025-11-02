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
    public partial class FrmDashVentas : Form
    {
        public FrmDashVentas()
        {
            InitializeComponent();
            this.Load += FrmDashVentas_Load;
        }

        private async void FrmDashVentas_Load(object sender, EventArgs e)
        {
            // Inicializa el control WebView2
            await webView21.EnsureCoreWebView2Async(null);

            // Pega tu URL segura de Power BI aquí
            string powerBiUrl = "https://app.powerbi.com/reportEmbed?reportId=5229552a-5e80-4e31-be50-5c4b87190f82&autoAuth=true&ctid=5f53b4ce-63d4-4ee8-88d2-22f0b2d4b27a";

            webView21.CoreWebView2.Navigate(powerBiUrl);
        }
    }
}
