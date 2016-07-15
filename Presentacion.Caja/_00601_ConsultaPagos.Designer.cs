namespace Presentacion.Caja
{
    partial class _00601_ConsultaPagos
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
            this.dgvConsultaPago = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaPago)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConsultaPago
            // 
            this.dgvConsultaPago.AllowUserToAddRows = false;
            this.dgvConsultaPago.AllowUserToDeleteRows = false;
            this.dgvConsultaPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultaPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsultaPago.Location = new System.Drawing.Point(0, 60);
            this.dgvConsultaPago.Name = "dgvConsultaPago";
            this.dgvConsultaPago.ReadOnly = true;
            this.dgvConsultaPago.Size = new System.Drawing.Size(630, 314);
            this.dgvConsultaPago.TabIndex = 3;
            // 
            // _00601_ConsultaPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 396);
            this.Controls.Add(this.dgvConsultaPago);
            this.Name = "_00601_ConsultaPagos";
            this.Text = "_00601_ConsultaPagos";
            this.Load += new System.EventHandler(this._00601_ConsultaPagos_Load);
            this.Controls.SetChildIndex(this.dgvConsultaPago, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsultaPago;
    }
}