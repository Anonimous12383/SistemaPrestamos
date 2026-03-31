using System;

namespace SisemaPrestamo.Formularios
{
    partial class FrmPrestamos
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
            this.txtClienteId = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtMeses = new System.Windows.Forms.TextBox();
            this.lblClienteId = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblMeses = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblTasa = new System.Windows.Forms.Label();
            this.lblInteres = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCuota = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtClienteId
            // 
            this.txtClienteId.Location = new System.Drawing.Point(112, 21);
            this.txtClienteId.Margin = new System.Windows.Forms.Padding(4);
            this.txtClienteId.Name = "txtClienteId";
            this.txtClienteId.Size = new System.Drawing.Size(132, 22);
            this.txtClienteId.TabIndex = 0;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(112, 54);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(132, 22);
            this.txtMonto.TabIndex = 1;
            // 
            // txtMeses
            // 
            this.txtMeses.Location = new System.Drawing.Point(112, 97);
            this.txtMeses.Margin = new System.Windows.Forms.Padding(4);
            this.txtMeses.Name = "txtMeses";
            this.txtMeses.Size = new System.Drawing.Size(132, 22);
            this.txtMeses.TabIndex = 2;
            // 
            // lblClienteId
            // 
            this.lblClienteId.AutoSize = true;
            this.lblClienteId.Location = new System.Drawing.Point(28, 25);
            this.lblClienteId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClienteId.Name = "lblClienteId";
            this.lblClienteId.Size = new System.Drawing.Size(64, 16);
            this.lblClienteId.TabIndex = 3;
            this.lblClienteId.Text = "Cliente ID";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(29, 60);
            this.lblMonto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(44, 16);
            this.lblMonto.TabIndex = 4;
            this.lblMonto.Text = "Monto";
            // 
            // lblMeses
            // 
            this.lblMeses.AutoSize = true;
            this.lblMeses.Location = new System.Drawing.Point(28, 97);
            this.lblMeses.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMeses.Name = "lblMeses";
            this.lblMeses.Size = new System.Drawing.Size(48, 16);
            this.lblMeses.TabIndex = 5;
            this.lblMeses.Text = "Meses";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(277, 17);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(284, 50);
            this.btnCalcular.TabIndex = 6;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(277, 83);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(284, 50);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar Prestamo";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblTasa
            // 
            this.lblTasa.AutoSize = true;
            this.lblTasa.Location = new System.Drawing.Point(158, 174);
            this.lblTasa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTasa.Name = "lblTasa";
            this.lblTasa.Size = new System.Drawing.Size(44, 16);
            this.lblTasa.TabIndex = 8;
            this.lblTasa.Text = "label1";
            this.lblTasa.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblInteres
            // 
            this.lblInteres.AutoSize = true;
            this.lblInteres.Location = new System.Drawing.Point(158, 237);
            this.lblInteres.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInteres.Name = "lblInteres";
            this.lblInteres.Size = new System.Drawing.Size(44, 16);
            this.lblInteres.TabIndex = 9;
            this.lblInteres.Text = "label2";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(158, 302);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 16);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "label3";
            // 
            // lblCuota
            // 
            this.lblCuota.AutoSize = true;
            this.lblCuota.Location = new System.Drawing.Point(158, 358);
            this.lblCuota.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCuota.Name = "lblCuota";
            this.lblCuota.Size = new System.Drawing.Size(44, 16);
            this.lblCuota.TabIndex = 11;
            this.lblCuota.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 174);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tasa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 237);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Interes:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 302);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 358);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Cuota mensual:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(277, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(284, 204);
            this.dataGridView1.TabIndex = 15;
            // 
            // FrmPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 415);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCuota);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblInteres);
            this.Controls.Add(this.lblTasa);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblMeses);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblClienteId);
            this.Controls.Add(this.txtMeses);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtClienteId);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrestamos";
            this.Text = "FrmPrestamos";
            this.Load += new System.EventHandler(this.FrmPrestamos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FrmPrestamos_Load(object sender, EventArgs e)
        {
  
        }

        private void label4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TextBox txtClienteId;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtMeses;
        private System.Windows.Forms.Label lblClienteId;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblMeses;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblTasa;
        private System.Windows.Forms.Label lblInteres;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCuota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}