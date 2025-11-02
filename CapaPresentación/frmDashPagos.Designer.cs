namespace CapaPresentación
{
    partial class frmDashPagos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rvDashboardPagos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvDashboardPagos
            // 
            this.rvDashboardPagos.Location = new System.Drawing.Point(0, -2);
            this.rvDashboardPagos.Name = "rvDashboardPagos";
            this.rvDashboardPagos.ServerReport.BearerToken = null;
            this.rvDashboardPagos.Size = new System.Drawing.Size(938, 603);
            this.rvDashboardPagos.TabIndex = 0;
            // 
            // frmDashPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 601);
            this.Controls.Add(this.rvDashboardPagos);
            this.Name = "frmDashPagos";
            this.Text = "frmDashPagos";
            this.Load += new System.EventHandler(this.frmDashPagos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvDashboardPagos;
    }
}