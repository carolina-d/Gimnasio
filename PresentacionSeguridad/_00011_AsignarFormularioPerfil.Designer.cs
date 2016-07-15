namespace PresentacionSeguridad
{
    partial class _00011_AsignarFormularioPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00011_AsignarFormularioPerfil));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.pnlEmpresa = new System.Windows.Forms.Panel();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.cmbPerfil = new System.Windows.Forms.ComboBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnDesmarcarAsignado = new System.Windows.Forms.Button();
            this.btnMarcarAsignado = new System.Windows.Forms.Button();
            this.btnBuscarAsignado = new System.Windows.Forms.Button();
            this.txtBuscarAsignado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imgBuscarAsignado = new System.Windows.Forms.PictureBox();
            this.dgvGrillaAsignado = new System.Windows.Forms.DataGridView();
            this.ItemAsignados = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTituloAsignado = new System.Windows.Forms.Label();
            this.btnDesmarcarNoAsignado = new System.Windows.Forms.Button();
            this.btnMarcarNoAsignado = new System.Windows.Forms.Button();
            this.btnBuscarNoAsignado = new System.Windows.Forms.Button();
            this.txtBuscarNoAsignado = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.imgBuscarNoAsignado = new System.Windows.Forms.PictureBox();
            this.dgvGrillaNoAsignado = new System.Windows.Forms.DataGridView();
            this.ItemNoAsignados = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTituloNoAsignado = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.pnlEmpresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscarAsignado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaAsignado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscarNoAsignado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaNoAsignado)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(839, 47);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(33, 44);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlEmpresa
            // 
            this.pnlEmpresa.Controls.Add(this.lblEmpresa);
            this.pnlEmpresa.Controls.Add(this.cmbPerfil);
            this.pnlEmpresa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEmpresa.Location = new System.Drawing.Point(0, 47);
            this.pnlEmpresa.Name = "pnlEmpresa";
            this.pnlEmpresa.Size = new System.Drawing.Size(839, 43);
            this.pnlEmpresa.TabIndex = 13;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(62, 16);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(30, 13);
            this.lblEmpresa.TabIndex = 1;
            this.lblEmpresa.Text = "Perfil";
            // 
            // cmbPerfil
            // 
            this.cmbPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerfil.FormattingEnabled = true;
            this.cmbPerfil.Location = new System.Drawing.Point(98, 11);
            this.cmbPerfil.Name = "cmbPerfil";
            this.cmbPerfil.Size = new System.Drawing.Size(606, 21);
            this.cmbPerfil.TabIndex = 0;
            this.cmbPerfil.SelectionChangeCommitted += new System.EventHandler(this.cmbPerfil_SelectionChangeCommitted);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(378, 258);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(79, 44);
            this.btnQuitar.TabIndex = 81;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(378, 195);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(79, 44);
            this.btnAgregar.TabIndex = 80;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnDesmarcarAsignado
            // 
            this.btnDesmarcarAsignado.Location = new System.Drawing.Point(609, 463);
            this.btnDesmarcarAsignado.Name = "btnDesmarcarAsignado";
            this.btnDesmarcarAsignado.Size = new System.Drawing.Size(135, 23);
            this.btnDesmarcarAsignado.TabIndex = 79;
            this.btnDesmarcarAsignado.Text = "Desmarcar Todo";
            this.btnDesmarcarAsignado.UseVisualStyleBackColor = true;
            this.btnDesmarcarAsignado.Click += new System.EventHandler(this.btnDesmarcarAsignado_Click);
            // 
            // btnMarcarAsignado
            // 
            this.btnMarcarAsignado.Location = new System.Drawing.Point(472, 463);
            this.btnMarcarAsignado.Name = "btnMarcarAsignado";
            this.btnMarcarAsignado.Size = new System.Drawing.Size(135, 23);
            this.btnMarcarAsignado.TabIndex = 78;
            this.btnMarcarAsignado.Text = "Marcar Todo";
            this.btnMarcarAsignado.UseVisualStyleBackColor = true;
            this.btnMarcarAsignado.Click += new System.EventHandler(this.btnMarcarAsignado_Click);
            // 
            // btnBuscarAsignado
            // 
            this.btnBuscarAsignado.Location = new System.Drawing.Point(750, 511);
            this.btnBuscarAsignado.Name = "btnBuscarAsignado";
            this.btnBuscarAsignado.Size = new System.Drawing.Size(59, 23);
            this.btnBuscarAsignado.TabIndex = 77;
            this.btnBuscarAsignado.Text = "Buscar";
            this.btnBuscarAsignado.UseVisualStyleBackColor = true;
            this.btnBuscarAsignado.Click += new System.EventHandler(this.btnBuscarAsignado_Click);
            // 
            // txtBuscarAsignado
            // 
            this.txtBuscarAsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarAsignado.Location = new System.Drawing.Point(513, 512);
            this.txtBuscarAsignado.Name = "txtBuscarAsignado";
            this.txtBuscarAsignado.Size = new System.Drawing.Size(231, 22);
            this.txtBuscarAsignado.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(513, 493);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 17);
            this.label1.TabIndex = 75;
            this.label1.Text = "Busqueda";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgBuscarAsignado
            // 
            this.imgBuscarAsignado.BackColor = System.Drawing.Color.Transparent;
            this.imgBuscarAsignado.Location = new System.Drawing.Point(475, 493);
            this.imgBuscarAsignado.Name = "imgBuscarAsignado";
            this.imgBuscarAsignado.Size = new System.Drawing.Size(33, 39);
            this.imgBuscarAsignado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBuscarAsignado.TabIndex = 74;
            this.imgBuscarAsignado.TabStop = false;
            // 
            // dgvGrillaAsignado
            // 
            this.dgvGrillaAsignado.AllowUserToAddRows = false;
            this.dgvGrillaAsignado.AllowUserToDeleteRows = false;
            this.dgvGrillaAsignado.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrillaAsignado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrillaAsignado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemAsignados});
            this.dgvGrillaAsignado.Location = new System.Drawing.Point(472, 168);
            this.dgvGrillaAsignado.Name = "dgvGrillaAsignado";
            this.dgvGrillaAsignado.RowHeadersVisible = false;
            this.dgvGrillaAsignado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrillaAsignado.Size = new System.Drawing.Size(337, 289);
            this.dgvGrillaAsignado.TabIndex = 73;
            this.dgvGrillaAsignado.DataSourceChanged += new System.EventHandler(this.dgvGrillaAsignado_DataSourceChanged);
            this.dgvGrillaAsignado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrillaAsignado_CellContentClick);
            // 
            // ItemAsignados
            // 
            this.ItemAsignados.Frozen = true;
            this.ItemAsignados.HeaderText = "Item";
            this.ItemAsignados.Name = "ItemAsignados";
            this.ItemAsignados.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemAsignados.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ItemAsignados.Width = 40;
            // 
            // lblTituloAsignado
            // 
            this.lblTituloAsignado.BackColor = System.Drawing.Color.SteelBlue;
            this.lblTituloAsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAsignado.ForeColor = System.Drawing.Color.White;
            this.lblTituloAsignado.Location = new System.Drawing.Point(472, 140);
            this.lblTituloAsignado.Name = "lblTituloAsignado";
            this.lblTituloAsignado.Size = new System.Drawing.Size(337, 28);
            this.lblTituloAsignado.TabIndex = 72;
            this.lblTituloAsignado.Text = "Lista de Usuarios Asignados";
            this.lblTituloAsignado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDesmarcarNoAsignado
            // 
            this.btnDesmarcarNoAsignado.Location = new System.Drawing.Point(169, 463);
            this.btnDesmarcarNoAsignado.Name = "btnDesmarcarNoAsignado";
            this.btnDesmarcarNoAsignado.Size = new System.Drawing.Size(135, 23);
            this.btnDesmarcarNoAsignado.TabIndex = 71;
            this.btnDesmarcarNoAsignado.Text = "Desmarcar Todo";
            this.btnDesmarcarNoAsignado.UseVisualStyleBackColor = true;
            this.btnDesmarcarNoAsignado.Click += new System.EventHandler(this.btnDesmarcarNoAsignado_Click);
            // 
            // btnMarcarNoAsignado
            // 
            this.btnMarcarNoAsignado.Location = new System.Drawing.Point(28, 463);
            this.btnMarcarNoAsignado.Name = "btnMarcarNoAsignado";
            this.btnMarcarNoAsignado.Size = new System.Drawing.Size(135, 23);
            this.btnMarcarNoAsignado.TabIndex = 70;
            this.btnMarcarNoAsignado.Text = "Marcar Todo";
            this.btnMarcarNoAsignado.UseVisualStyleBackColor = true;
            this.btnMarcarNoAsignado.Click += new System.EventHandler(this.btnMarcarNoAsignado_Click);
            // 
            // btnBuscarNoAsignado
            // 
            this.btnBuscarNoAsignado.Location = new System.Drawing.Point(306, 511);
            this.btnBuscarNoAsignado.Name = "btnBuscarNoAsignado";
            this.btnBuscarNoAsignado.Size = new System.Drawing.Size(59, 23);
            this.btnBuscarNoAsignado.TabIndex = 69;
            this.btnBuscarNoAsignado.Text = "Buscar";
            this.btnBuscarNoAsignado.UseVisualStyleBackColor = true;
            this.btnBuscarNoAsignado.Click += new System.EventHandler(this.btnBuscarNoAsignado_Click);
            // 
            // txtBuscarNoAsignado
            // 
            this.txtBuscarNoAsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarNoAsignado.Location = new System.Drawing.Point(69, 512);
            this.txtBuscarNoAsignado.Name = "txtBuscarNoAsignado";
            this.txtBuscarNoAsignado.Size = new System.Drawing.Size(231, 22);
            this.txtBuscarNoAsignado.TabIndex = 68;
            // 
            // lblBuscar
            // 
            this.lblBuscar.BackColor = System.Drawing.Color.Transparent;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblBuscar.Location = new System.Drawing.Point(69, 493);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(231, 17);
            this.lblBuscar.TabIndex = 67;
            this.lblBuscar.Text = "Busqueda";
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgBuscarNoAsignado
            // 
            this.imgBuscarNoAsignado.BackColor = System.Drawing.Color.Transparent;
            this.imgBuscarNoAsignado.Location = new System.Drawing.Point(31, 493);
            this.imgBuscarNoAsignado.Name = "imgBuscarNoAsignado";
            this.imgBuscarNoAsignado.Size = new System.Drawing.Size(33, 39);
            this.imgBuscarNoAsignado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBuscarNoAsignado.TabIndex = 66;
            this.imgBuscarNoAsignado.TabStop = false;
            // 
            // dgvGrillaNoAsignado
            // 
            this.dgvGrillaNoAsignado.AllowUserToAddRows = false;
            this.dgvGrillaNoAsignado.AllowUserToDeleteRows = false;
            this.dgvGrillaNoAsignado.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrillaNoAsignado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrillaNoAsignado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNoAsignados});
            this.dgvGrillaNoAsignado.Location = new System.Drawing.Point(28, 168);
            this.dgvGrillaNoAsignado.Name = "dgvGrillaNoAsignado";
            this.dgvGrillaNoAsignado.RowHeadersVisible = false;
            this.dgvGrillaNoAsignado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrillaNoAsignado.Size = new System.Drawing.Size(337, 289);
            this.dgvGrillaNoAsignado.TabIndex = 65;
            this.dgvGrillaNoAsignado.DataSourceChanged += new System.EventHandler(this.dgvGrillaNoAsignado_DataSourceChanged);
            this.dgvGrillaNoAsignado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrillaNoAsignado_CellContentClick);
            // 
            // ItemNoAsignados
            // 
            this.ItemNoAsignados.Frozen = true;
            this.ItemNoAsignados.HeaderText = "Item";
            this.ItemNoAsignados.Name = "ItemNoAsignados";
            this.ItemNoAsignados.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemNoAsignados.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ItemNoAsignados.Width = 40;
            // 
            // lblTituloNoAsignado
            // 
            this.lblTituloNoAsignado.BackColor = System.Drawing.Color.SteelBlue;
            this.lblTituloNoAsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloNoAsignado.ForeColor = System.Drawing.Color.White;
            this.lblTituloNoAsignado.Location = new System.Drawing.Point(28, 140);
            this.lblTituloNoAsignado.Name = "lblTituloNoAsignado";
            this.lblTituloNoAsignado.Size = new System.Drawing.Size(337, 28);
            this.lblTituloNoAsignado.TabIndex = 64;
            this.lblTituloNoAsignado.Text = "Lista de Usuarios No Asignados";
            this.lblTituloNoAsignado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _00011_AsignarFormularioPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 576);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnDesmarcarAsignado);
            this.Controls.Add(this.btnMarcarAsignado);
            this.Controls.Add(this.btnBuscarAsignado);
            this.Controls.Add(this.txtBuscarAsignado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgBuscarAsignado);
            this.Controls.Add(this.dgvGrillaAsignado);
            this.Controls.Add(this.lblTituloAsignado);
            this.Controls.Add(this.btnDesmarcarNoAsignado);
            this.Controls.Add(this.btnMarcarNoAsignado);
            this.Controls.Add(this.btnBuscarNoAsignado);
            this.Controls.Add(this.txtBuscarNoAsignado);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.imgBuscarNoAsignado);
            this.Controls.Add(this.dgvGrillaNoAsignado);
            this.Controls.Add(this.lblTituloNoAsignado);
            this.Controls.Add(this.pnlEmpresa);
            this.Controls.Add(this.toolStrip1);
            this.Name = "_00011_AsignarFormularioPerfil";
            this.Text = "_00011_AsignarFormularioPerfil";
            this.Load += new System.EventHandler(this._00011_AsignarFormularioPerfil_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlEmpresa.ResumeLayout(false);
            this.pnlEmpresa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscarAsignado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaAsignado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscarNoAsignado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaNoAsignado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Panel pnlEmpresa;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.ComboBox cmbPerfil;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnDesmarcarAsignado;
        private System.Windows.Forms.Button btnMarcarAsignado;
        private System.Windows.Forms.Button btnBuscarAsignado;
        private System.Windows.Forms.TextBox txtBuscarAsignado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imgBuscarAsignado;
        private System.Windows.Forms.DataGridView dgvGrillaAsignado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ItemAsignados;
        private System.Windows.Forms.Label lblTituloAsignado;
        private System.Windows.Forms.Button btnDesmarcarNoAsignado;
        private System.Windows.Forms.Button btnMarcarNoAsignado;
        private System.Windows.Forms.Button btnBuscarNoAsignado;
        private System.Windows.Forms.TextBox txtBuscarNoAsignado;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.PictureBox imgBuscarNoAsignado;
        private System.Windows.Forms.DataGridView dgvGrillaNoAsignado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ItemNoAsignados;
        private System.Windows.Forms.Label lblTituloNoAsignado;
    }
}