namespace PrestamosApp
{
    partial class FrmPrincipal
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
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnPrestamos = new System.Windows.Forms.Button();
            this.btnPagos = new System.Windows.Forms.Button();
            this.btnReporteCliente = new System.Windows.Forms.Button();
            this.btnReporteMorosos = new System.Windows.Forms.Button();
            this.btnReporteMoras = new System.Windows.Forms.Button();
            this.btnReporteFinanciero = new System.Windows.Forms.Button();
            this.btnReporteAmortizacion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnClientes.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClientes.Location = new System.Drawing.Point(-3, -1);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(110, 36);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnPrestamos
            // 
            this.btnPrestamos.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPrestamos.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrestamos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrestamos.Location = new System.Drawing.Point(86, -1);
            this.btnPrestamos.Name = "btnPrestamos";
            this.btnPrestamos.Size = new System.Drawing.Size(110, 36);
            this.btnPrestamos.TabIndex = 1;
            this.btnPrestamos.Text = "Prestamos";
            this.btnPrestamos.UseVisualStyleBackColor = false;
            this.btnPrestamos.Click += new System.EventHandler(this.btnPrestamos_Click);
            // 
            // btnPagos
            // 
            this.btnPagos.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPagos.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPagos.Location = new System.Drawing.Point(186, -1);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Size = new System.Drawing.Size(110, 36);
            this.btnPagos.TabIndex = 2;
            this.btnPagos.Text = "Pagos";
            this.btnPagos.UseVisualStyleBackColor = false;
            this.btnPagos.Click += new System.EventHandler(this.btnPagos_Click);
            // 
            // btnReporteCliente
            // 
            this.btnReporteCliente.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReporteCliente.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteCliente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReporteCliente.Location = new System.Drawing.Point(283, -1);
            this.btnReporteCliente.Name = "btnReporteCliente";
            this.btnReporteCliente.Size = new System.Drawing.Size(110, 36);
            this.btnReporteCliente.TabIndex = 3;
            this.btnReporteCliente.Text = "RptCliente";
            this.btnReporteCliente.UseVisualStyleBackColor = false;
            this.btnReporteCliente.Click += new System.EventHandler(this.btnReporteCliente_Click);
            // 
            // btnReporteMorosos
            // 
            this.btnReporteMorosos.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReporteMorosos.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteMorosos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReporteMorosos.Location = new System.Drawing.Point(386, -1);
            this.btnReporteMorosos.Name = "btnReporteMorosos";
            this.btnReporteMorosos.Size = new System.Drawing.Size(110, 36);
            this.btnReporteMorosos.TabIndex = 4;
            this.btnReporteMorosos.Text = "RptMorosos";
            this.btnReporteMorosos.UseVisualStyleBackColor = false;
            this.btnReporteMorosos.Click += new System.EventHandler(this.btnReporteMorosos_Click);
            // 
            // btnReporteMoras
            // 
            this.btnReporteMoras.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReporteMoras.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteMoras.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReporteMoras.Location = new System.Drawing.Point(489, -1);
            this.btnReporteMoras.Name = "btnReporteMoras";
            this.btnReporteMoras.Size = new System.Drawing.Size(110, 36);
            this.btnReporteMoras.TabIndex = 5;
            this.btnReporteMoras.Text = "ReporteMoras";
            this.btnReporteMoras.UseVisualStyleBackColor = false;
            this.btnReporteMoras.Click += new System.EventHandler(this.btnReporteMoras_Click);
            // 
            // btnReporteFinanciero
            // 
            this.btnReporteFinanciero.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReporteFinanciero.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteFinanciero.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReporteFinanciero.Location = new System.Drawing.Point(586, -1);
            this.btnReporteFinanciero.Name = "btnReporteFinanciero";
            this.btnReporteFinanciero.Size = new System.Drawing.Size(110, 36);
            this.btnReporteFinanciero.TabIndex = 6;
            this.btnReporteFinanciero.Text = "RptFinanciero";
            this.btnReporteFinanciero.UseVisualStyleBackColor = false;
            this.btnReporteFinanciero.Click += new System.EventHandler(this.btnReporteFinanciero_Click);
            // 
            // btnReporteAmortizacion
            // 
            this.btnReporteAmortizacion.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReporteAmortizacion.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteAmortizacion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReporteAmortizacion.Location = new System.Drawing.Point(691, -1);
            this.btnReporteAmortizacion.Name = "btnReporteAmortizacion";
            this.btnReporteAmortizacion.Size = new System.Drawing.Size(124, 36);
            this.btnReporteAmortizacion.TabIndex = 7;
            this.btnReporteAmortizacion.Text = "RptAmortizacion";
            this.btnReporteAmortizacion.UseVisualStyleBackColor = false;
            this.btnReporteAmortizacion.Click += new System.EventHandler(this.btnReporteAmortizacion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Location = new System.Drawing.Point(864, -1);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(53, 44);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Neutrons Demo", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(-6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(691, 135);
            this.label1.TabIndex = 9;
            this.label1.Text = "Reportes en C";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SisemaPrestamo.Properties.Resources._5674015;
            this.pictureBox1.Location = new System.Drawing.Point(708, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 208);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnReporteAmortizacion);
            this.Controls.Add(this.btnReporteFinanciero);
            this.Controls.Add(this.btnReporteMoras);
            this.Controls.Add(this.btnReporteMorosos);
            this.Controls.Add(this.btnReporteCliente);
            this.Controls.Add(this.btnPagos);
            this.Controls.Add(this.btnPrestamos);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.label1);
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnPrestamos;
        private System.Windows.Forms.Button btnPagos;
        private System.Windows.Forms.Button btnReporteCliente;
        private System.Windows.Forms.Button btnReporteMorosos;
        private System.Windows.Forms.Button btnReporteMoras;
        private System.Windows.Forms.Button btnReporteFinanciero;
        private System.Windows.Forms.Button btnReporteAmortizacion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}