namespace CapaPresentación
{
    partial class frmMenuComprobantes
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
            this.txtCodigoPago = new System.Windows.Forms.TextBox();
            this.txtCodigoEnvio = new System.Windows.Forms.TextBox();
            this.txtCodigoDetalle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDashboardPagos = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDashVentas = new System.Windows.Forms.Button();
            this.btnComprobanteVenta = new System.Windows.Forms.Button();
            this.btnComprobanteEnvio = new System.Windows.Forms.Button();
            this.btnComprobantePago = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCodigoPago
            // 
            this.txtCodigoPago.ForeColor = System.Drawing.Color.LightGray;
            this.txtCodigoPago.Location = new System.Drawing.Point(125, 272);
            this.txtCodigoPago.Name = "txtCodigoPago";
            this.txtCodigoPago.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoPago.TabIndex = 1;
            this.txtCodigoPago.Text = "Codigo Pago";
            this.txtCodigoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoPago.Enter += new System.EventHandler(this.txtCodigoPago_Enter);
            this.txtCodigoPago.Leave += new System.EventHandler(this.txtCodigoPago_Leave);
            // 
            // txtCodigoEnvio
            // 
            this.txtCodigoEnvio.ForeColor = System.Drawing.Color.LightGray;
            this.txtCodigoEnvio.Location = new System.Drawing.Point(363, 272);
            this.txtCodigoEnvio.Name = "txtCodigoEnvio";
            this.txtCodigoEnvio.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoEnvio.TabIndex = 3;
            this.txtCodigoEnvio.Text = "Codigo Envio";
            this.txtCodigoEnvio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoEnvio.Enter += new System.EventHandler(this.txtCodigoEnvio_Enter);
            this.txtCodigoEnvio.Leave += new System.EventHandler(this.txtCodigoEnvio_Leave);
            // 
            // txtCodigoDetalle
            // 
            this.txtCodigoDetalle.ForeColor = System.Drawing.Color.LightGray;
            this.txtCodigoDetalle.Location = new System.Drawing.Point(624, 272);
            this.txtCodigoDetalle.Name = "txtCodigoDetalle";
            this.txtCodigoDetalle.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoDetalle.TabIndex = 5;
            this.txtCodigoDetalle.Text = "Codigo Detalle";
            this.txtCodigoDetalle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoDetalle.Enter += new System.EventHandler(this.txtCodigoDetalle_Enter);
            this.txtCodigoDetalle.Leave += new System.EventHandler(this.txtCodigoDetalle_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "COMPROBANTE PAGOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(312, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "COMPROBANTE ENVÍOS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(574, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "COMPROBANTE VENTAS";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calisto MT", 20F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(212, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(490, 31);
            this.label11.TabIndex = 83;
            this.label11.Text = "DASHBOARDS Y COMPROBANTES";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 20);
            this.label4.TabIndex = 85;
            this.label4.Text = "DASHBOARD VENTAS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(312, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 20);
            this.label5.TabIndex = 87;
            this.label5.Text = "DASHBOARD GRANJAS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(582, 372);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 20);
            this.label6.TabIndex = 89;
            this.label6.Text = "DASHBOARD PAGOS";
            // 
            // btnDashboardPagos
            // 
            this.btnDashboardPagos.BackgroundImage = global::CapaPresentación.Properties.Resources.ssrs_logo;
            this.btnDashboardPagos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDashboardPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboardPagos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDashboardPagos.Location = new System.Drawing.Point(578, 395);
            this.btnDashboardPagos.Name = "btnDashboardPagos";
            this.btnDashboardPagos.Size = new System.Drawing.Size(201, 136);
            this.btnDashboardPagos.TabIndex = 88;
            this.btnDashboardPagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDashboardPagos.UseVisualStyleBackColor = true;
            this.btnDashboardPagos.Click += new System.EventHandler(this.btnDashboardPagos_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::CapaPresentación.Properties.Resources.Excel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(316, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 136);
            this.button2.TabIndex = 86;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnDashVentas
            // 
            this.btnDashVentas.BackgroundImage = global::CapaPresentación.Properties.Resources.PowerBi;
            this.btnDashVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDashVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashVentas.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDashVentas.Location = new System.Drawing.Point(73, 395);
            this.btnDashVentas.Name = "btnDashVentas";
            this.btnDashVentas.Size = new System.Drawing.Size(201, 136);
            this.btnDashVentas.TabIndex = 84;
            this.btnDashVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDashVentas.UseVisualStyleBackColor = true;
            this.btnDashVentas.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnComprobanteVenta
            // 
            this.btnComprobanteVenta.BackgroundImage = global::CapaPresentación.Properties.Resources.Ventas;
            this.btnComprobanteVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnComprobanteVenta.Location = new System.Drawing.Point(578, 122);
            this.btnComprobanteVenta.Name = "btnComprobanteVenta";
            this.btnComprobanteVenta.Size = new System.Drawing.Size(201, 136);
            this.btnComprobanteVenta.TabIndex = 4;
            this.btnComprobanteVenta.UseVisualStyleBackColor = true;
            this.btnComprobanteVenta.Click += new System.EventHandler(this.btnComprobanteVenta_Click);
            // 
            // btnComprobanteEnvio
            // 
            this.btnComprobanteEnvio.BackgroundImage = global::CapaPresentación.Properties.Resources.Envío;
            this.btnComprobanteEnvio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnComprobanteEnvio.Location = new System.Drawing.Point(316, 122);
            this.btnComprobanteEnvio.Name = "btnComprobanteEnvio";
            this.btnComprobanteEnvio.Size = new System.Drawing.Size(201, 136);
            this.btnComprobanteEnvio.TabIndex = 2;
            this.btnComprobanteEnvio.UseVisualStyleBackColor = true;
            this.btnComprobanteEnvio.Click += new System.EventHandler(this.btnComprobanteEnvio_Click);
            // 
            // btnComprobantePago
            // 
            this.btnComprobantePago.BackgroundImage = global::CapaPresentación.Properties.Resources.Pago;
            this.btnComprobantePago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnComprobantePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprobantePago.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnComprobantePago.Location = new System.Drawing.Point(73, 120);
            this.btnComprobantePago.Name = "btnComprobantePago";
            this.btnComprobantePago.Size = new System.Drawing.Size(201, 136);
            this.btnComprobantePago.TabIndex = 0;
            this.btnComprobantePago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnComprobantePago.UseVisualStyleBackColor = true;
            this.btnComprobantePago.Click += new System.EventHandler(this.btnComprobantePago_Click);
            // 
            // frmMenuComprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 601);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDashboardPagos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDashVentas);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoDetalle);
            this.Controls.Add(this.btnComprobanteVenta);
            this.Controls.Add(this.txtCodigoEnvio);
            this.Controls.Add(this.btnComprobanteEnvio);
            this.Controls.Add(this.txtCodigoPago);
            this.Controls.Add(this.btnComprobantePago);
            this.Name = "frmMenuComprobantes";
            this.Text = "frmComprobantes";
            this.Load += new System.EventHandler(this.frmMenuComprobantes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnComprobantePago;
        private System.Windows.Forms.TextBox txtCodigoPago;
        private System.Windows.Forms.TextBox txtCodigoEnvio;
        private System.Windows.Forms.Button btnComprobanteEnvio;
        private System.Windows.Forms.TextBox txtCodigoDetalle;
        private System.Windows.Forms.Button btnComprobanteVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDashVentas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDashboardPagos;
    }
}