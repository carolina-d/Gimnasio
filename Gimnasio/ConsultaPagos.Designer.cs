namespace Gimnasio
{
    partial class ConsultaPagos
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
            this.txtBusquedaConsultaPago = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscarConsultaPago = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaPago)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConsultaPago
            // 
            this.dgvConsultaPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultaPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsultaPago.Location = new System.Drawing.Point(0, 135);
            this.dgvConsultaPago.Margin = new System.Windows.Forms.Padding(2);
            this.dgvConsultaPago.MultiSelect = false;
            this.dgvConsultaPago.Name = "dgvConsultaPago";
            this.dgvConsultaPago.RowTemplate.Height = 24;
            this.dgvConsultaPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultaPago.Size = new System.Drawing.Size(747, 420);
            this.dgvConsultaPago.TabIndex = 4;
            this.dgvConsultaPago.DataSourceChanged += new System.EventHandler(this.dgvConsultaPago_DataSourceChanged);
            this.dgvConsultaPago.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvConsultaPago_RowPrePaint);
            // 
            // txtBusquedaConsultaPago
            // 
            this.txtBusquedaConsultaPago.Location = new System.Drawing.Point(106, 21);
            this.txtBusquedaConsultaPago.Margin = new System.Windows.Forms.Padding(2);
            this.txtBusquedaConsultaPago.Name = "txtBusquedaConsultaPago";
            this.txtBusquedaConsultaPago.Size = new System.Drawing.Size(324, 20);
            this.txtBusquedaConsultaPago.TabIndex = 9;
            this.txtBusquedaConsultaPago.TextChanged += new System.EventHandler(this.txtBusquedaConsultaPago_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Buscar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnBuscarConsultaPago
            // 
            this.btnBuscarConsultaPago.Location = new System.Drawing.Point(447, 16);
            this.btnBuscarConsultaPago.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarConsultaPago.Name = "btnBuscarConsultaPago";
            this.btnBuscarConsultaPago.Size = new System.Drawing.Size(82, 28);
            this.btnBuscarConsultaPago.TabIndex = 7;
            this.btnBuscarConsultaPago.Text = "Buscar";
            this.btnBuscarConsultaPago.UseVisualStyleBackColor = true;
            this.btnBuscarConsultaPago.Click += new System.EventHandler(this.btnBuscarConsultaPago_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuscarConsultaPago);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBusquedaConsultaPago);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 75);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ConsultaPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 577);
            this.Controls.Add(this.dgvConsultaPago);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultaPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultaPagos";
            this.Load += new System.EventHandler(this.ConsultaPagos_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dgvConsultaPago, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaPago)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsultaPago;
        private System.Windows.Forms.TextBox txtBusquedaConsultaPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarConsultaPago;
        private System.Windows.Forms.Panel panel1;
    }
}