namespace PresentacionSpinning
{
    partial class _00503_TurnoSpinning_ABM
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
            this.pnlReserva = new System.Windows.Forms.Panel();
            this.mtbHora = new System.Windows.Forms.MaskedTextBox();
            this.btnConsultaClase = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.nudSenia = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechaReserva = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlSocio = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlReserva.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSenia)).BeginInit();
            this.pnlSocio.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReserva
            // 
            this.pnlReserva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReserva.Controls.Add(this.mtbHora);
            this.pnlReserva.Controls.Add(this.btnConsultaClase);
            this.pnlReserva.Controls.Add(this.label8);
            this.pnlReserva.Controls.Add(this.nudSenia);
            this.pnlReserva.Controls.Add(this.label7);
            this.pnlReserva.Controls.Add(this.label6);
            this.pnlReserva.Controls.Add(this.dtpFechaReserva);
            this.pnlReserva.Controls.Add(this.label5);
            this.pnlReserva.Location = new System.Drawing.Point(7, 305);
            this.pnlReserva.Name = "pnlReserva";
            this.pnlReserva.Size = new System.Drawing.Size(688, 80);
            this.pnlReserva.TabIndex = 5;
            // 
            // mtbHora
            // 
            this.mtbHora.Location = new System.Drawing.Point(244, 39);
            this.mtbHora.Mask = "00:00";
            this.mtbHora.Name = "mtbHora";
            this.mtbHora.Size = new System.Drawing.Size(70, 20);
            this.mtbHora.TabIndex = 15;
            this.mtbHora.ValidatingType = typeof(System.DateTime);
            // 
            // btnConsultaClase
            // 
            this.btnConsultaClase.Location = new System.Drawing.Point(443, 28);
            this.btnConsultaClase.Name = "btnConsultaClase";
            this.btnConsultaClase.Size = new System.Drawing.Size(75, 42);
            this.btnConsultaClase.TabIndex = 14;
            this.btnConsultaClase.Text = "Consultar Clases";
            this.btnConsultaClase.UseVisualStyleBackColor = true;
            this.btnConsultaClase.Click += new System.EventHandler(this.btnConsultaClase_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(208, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Hora";
            // 
            // nudSenia
            // 
            this.nudSenia.DecimalPlaces = 2;
            this.nudSenia.Location = new System.Drawing.Point(358, 40);
            this.nudSenia.Name = "nudSenia";
            this.nudSenia.Size = new System.Drawing.Size(59, 20);
            this.nudSenia.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Seña";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fecha Reserva";
            // 
            // dtpFechaReserva
            // 
            this.dtpFechaReserva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaReserva.Location = new System.Drawing.Point(106, 40);
            this.dtpFechaReserva.Name = "dtpFechaReserva";
            this.dtpFechaReserva.Size = new System.Drawing.Size(96, 20);
            this.dtpFechaReserva.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(686, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Datos de la Reserva";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSocio
            // 
            this.pnlSocio.BackColor = System.Drawing.Color.White;
            this.pnlSocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSocio.Controls.Add(this.label1);
            this.pnlSocio.Location = new System.Drawing.Point(6, 125);
            this.pnlSocio.Name = "pnlSocio";
            this.pnlSocio.Size = new System.Drawing.Size(689, 158);
            this.pnlSocio.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(687, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datos del Socio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _00503_TurnoSpinning_ABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 425);
            this.Controls.Add(this.pnlSocio);
            this.Controls.Add(this.pnlReserva);
            this.Name = "_00503_TurnoSpinning_ABM";
            this.Text = "_00503_TurnoSpinning_ABM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this._00503_TurnoSpinning_ABM_FormClosing);
            this.Load += new System.EventHandler(this._00503_TurnoSpinning_ABM_Load);
            this.Controls.SetChildIndex(this.pnlReserva, 0);
            this.Controls.SetChildIndex(this.pnlSocio, 0);
            this.pnlReserva.ResumeLayout(false);
            this.pnlReserva.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSenia)).EndInit();
            this.pnlSocio.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlReserva;
        private System.Windows.Forms.MaskedTextBox mtbHora;
        private System.Windows.Forms.Button btnConsultaClase;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudSenia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFechaReserva;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlSocio;
        private System.Windows.Forms.Label label1;
    }
}