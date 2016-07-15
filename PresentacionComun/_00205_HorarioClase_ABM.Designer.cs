namespace PresentacionComun
{
    partial class _00205_HorarioClase_ABM
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00205_HorarioClase_ABM));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDias = new System.Windows.Forms.ComboBox();
            this.lblDias = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.cmbClase = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNuevaEmpresa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Hora";
            // 
            // cmbDias
            // 
            this.cmbDias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDias.FormattingEnabled = true;
            this.cmbDias.Location = new System.Drawing.Point(149, 182);
            this.cmbDias.Name = "cmbDias";
            this.cmbDias.Size = new System.Drawing.Size(238, 21);
            this.cmbDias.TabIndex = 10;
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Location = new System.Drawing.Point(108, 185);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(30, 13);
            this.lblDias.TabIndex = 9;
            this.lblDias.Text = "Días";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 1000;
            this.errorProvider.ContainerControl = this;
            // 
            // dtpHora
            // 
            this.dtpHora.CustomFormat = "hh:mm";
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(149, 214);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(100, 20);
            this.dtpHora.TabIndex = 13;
            // 
            // cmbClase
            // 
            this.cmbClase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClase.FormattingEnabled = true;
            this.cmbClase.Location = new System.Drawing.Point(149, 153);
            this.cmbClase.Name = "cmbClase";
            this.cmbClase.Size = new System.Drawing.Size(238, 21);
            this.cmbClase.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Clase";
            // 
            // btnNuevaEmpresa
            // 
            this.btnNuevaEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaEmpresa.Image")));
            this.btnNuevaEmpresa.Location = new System.Drawing.Point(394, 151);
            this.btnNuevaEmpresa.Name = "btnNuevaEmpresa";
            this.btnNuevaEmpresa.Size = new System.Drawing.Size(53, 26);
            this.btnNuevaEmpresa.TabIndex = 27;
            this.btnNuevaEmpresa.Text = "...";
            this.btnNuevaEmpresa.UseVisualStyleBackColor = true;
            this.btnNuevaEmpresa.Click += new System.EventHandler(this.btnNuevaEmpresa_Click);
            // 
            // _00205_HorarioClase_ABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 312);
            this.Controls.Add(this.btnNuevaEmpresa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbClase);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDias);
            this.Controls.Add(this.lblDias);
            this.Name = "_00205_HorarioClase_ABM";
            this.Text = "_00205_HorarioClase_ABM";
            this.Controls.SetChildIndex(this.lblDias, 0);
            this.Controls.SetChildIndex(this.cmbDias, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpHora, 0);
            this.Controls.SetChildIndex(this.cmbClase, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnNuevaEmpresa, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDias;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClase;
        private System.Windows.Forms.Button btnNuevaEmpresa;
    }
}