namespace CapaPresentación
{
    partial class frmComprobanteEnvio
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
            this.rvComprobanteEnvio = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvComprobanteEnvio
            // 
            this.rvComprobanteEnvio.Location = new System.Drawing.Point(0, -1);
            this.rvComprobanteEnvio.Name = "rvComprobanteEnvio";
            this.rvComprobanteEnvio.ServerReport.BearerToken = null;
            this.rvComprobanteEnvio.Size = new System.Drawing.Size(836, 1066);
            this.rvComprobanteEnvio.TabIndex = 0;
            // 
            // frmComprobanteEnvio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 1061);
            this.Controls.Add(this.rvComprobanteEnvio);
            this.Name = "frmComprobanteEnvio";
            this.Text = "frmComprobanteEnvio";
            this.Load += new System.EventHandler(this.frmComprobanteEnvio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvComprobanteEnvio;
    }
}