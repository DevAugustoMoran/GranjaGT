namespace CapaPresentación
{
    partial class frmComprobanteVenta
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
            this.rvComprobanteVenta = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvComprobanteVenta
            // 
            this.rvComprobanteVenta.Location = new System.Drawing.Point(0, 0);
            this.rvComprobanteVenta.Name = "rvComprobanteVenta";
            this.rvComprobanteVenta.ServerReport.BearerToken = null;
            this.rvComprobanteVenta.Size = new System.Drawing.Size(833, 1059);
            this.rvComprobanteVenta.TabIndex = 0;
            // 
            // frmComprobanteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 1061);
            this.Controls.Add(this.rvComprobanteVenta);
            this.Name = "frmComprobanteVenta";
            this.Text = "frmComprobanteVenta";
            this.Load += new System.EventHandler(this.frmComprobanteVenta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvComprobanteVenta;
    }
}