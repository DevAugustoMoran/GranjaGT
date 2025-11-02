namespace CapaPresentación
{
    partial class frmComprobantePago
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
            this.rvComprobantePago = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvComprobantePago
            // 
            this.rvComprobantePago.Location = new System.Drawing.Point(-1, -2);
            this.rvComprobantePago.Name = "rvComprobantePago";
            this.rvComprobantePago.ServerReport.BearerToken = null;
            this.rvComprobantePago.Size = new System.Drawing.Size(836, 1063);
            this.rvComprobantePago.TabIndex = 1;
            // 
            // frmComprobantePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 1061);
            this.Controls.Add(this.rvComprobantePago);
            this.Name = "frmComprobantePago";
            this.Text = "frmComprobantePago";
            this.Load += new System.EventHandler(this.frmComprobantePago_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvComprobantePago;
    }
}