namespace PrestamosApp.Formularios
{
    partial class FrmPagos
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
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.chkFuePagado = new System.Windows.Forms.ComboBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lblPrestamo = new System.Windows.Forms.Label();
            this.chkPagado = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPagos
            // 
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Location = new System.Drawing.Point(333, 45);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.RowHeadersWidth = 51;
            this.dgvPagos.RowTemplate.Height = 24;
            this.dgvPagos.Size = new System.Drawing.Size(607, 254);
            this.dgvPagos.TabIndex = 0;
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.Location = new System.Drawing.Point(372, 332);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(211, 48);
            this.btnRegistrarPago.TabIndex = 1;
            this.btnRegistrarPago.Text = "Registrar";
            this.btnRegistrarPago.UseVisualStyleBackColor = true;
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            // 
            // chkFuePagado
            // 
            this.chkFuePagado.FormattingEnabled = true;
            this.chkFuePagado.Location = new System.Drawing.Point(39, 101);
            this.chkFuePagado.Name = "chkFuePagado";
            this.chkFuePagado.Size = new System.Drawing.Size(133, 24);
            this.chkFuePagado.TabIndex = 2;
            this.chkFuePagado.Click += new System.EventHandler(this.FrmPagos_Load);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(719, 332);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(194, 48);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // lblPrestamo
            // 
            this.lblPrestamo.AutoSize = true;
            this.lblPrestamo.Location = new System.Drawing.Point(36, 73);
            this.lblPrestamo.Name = "lblPrestamo";
            this.lblPrestamo.Size = new System.Drawing.Size(106, 16);
            this.lblPrestamo.TabIndex = 4;
            this.lblPrestamo.Text = "Elegir Préstamo:";
            // 
            // chkPagado
            // 
            this.chkPagado.AutoSize = true;
            this.chkPagado.Location = new System.Drawing.Point(47, 151);
            this.chkPagado.Name = "chkPagado";
            this.chkPagado.Size = new System.Drawing.Size(103, 20);
            this.chkPagado.TabIndex = 5;
            this.chkPagado.Text = "Fue pagado";
            this.chkPagado.UseVisualStyleBackColor = true;
            // 
            // FrmPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 450);
            this.Controls.Add(this.chkPagado);
            this.Controls.Add(this.lblPrestamo);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.chkFuePagado);
            this.Controls.Add(this.btnRegistrarPago);
            this.Controls.Add(this.dgvPagos);
            this.Name = "FrmPagos";
            this.Text = "FrmPagos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.ComboBox chkFuePagado;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblPrestamo;
        private System.Windows.Forms.CheckBox chkPagado;
    }
}