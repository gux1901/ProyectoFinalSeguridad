namespace InterfazSeguridad
{
    partial class ValidarTarjeta
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
            this.btnProcesar = new System.Windows.Forms.Button();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.txbTarjeta = new System.Windows.Forms.TextBox();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(12, 73);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(75, 23);
            this.btnProcesar.TabIndex = 0;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Location = new System.Drawing.Point(22, 34);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(40, 13);
            this.lblTarjeta.TabIndex = 1;
            this.lblTarjeta.Text = "Tarjeta";
            // 
            // txbTarjeta
            // 
            this.txbTarjeta.Location = new System.Drawing.Point(96, 34);
            this.txbTarjeta.Name = "txbTarjeta";
            this.txbTarjeta.Size = new System.Drawing.Size(157, 20);
            this.txbTarjeta.TabIndex = 2;
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.Location = new System.Drawing.Point(14, 122);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(73, 13);
            this.lblProcesando.TabIndex = 3;
            this.lblProcesando.Text = "Procesando...";
            // 
            // ValidarTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 450);
            this.Controls.Add(this.lblProcesando);
            this.Controls.Add(this.txbTarjeta);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.btnProcesar);
            this.Name = "ValidarTarjeta";
            this.Text = "ValidarTarjeta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.TextBox txbTarjeta;
        private System.Windows.Forms.Label lblProcesando;
    }
}