namespace PresentacionSeguridad
{
    partial class _00010_AsignarUsuarioPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00010_AsignarUsuarioPerfil));
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
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
            this.pnlPerfil = new System.Windows.Forms.Panel();
            this.btnNuevoPerfil = new System.Windows.Forms.Button();
            this.cmbPerfil = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscarAsignado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaAsignado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscarNoAsignado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaNoAsignado)).BeginInit();
            this.pnlPerfil.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(864, 47);
            this.Menu.TabIndex = 4;
            this.Menu.Text = "toolStrip1";
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
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(390, 319);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(79, 44);
            this.btnQuitar.TabIndex = 63;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(390, 256);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(79, 44);
            this.btnAgregar.TabIndex = 62;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnDesmarcarAsignado
            // 
            this.btnDesmarcarAsignado.Location = new System.Drawing.Point(621, 524);
            this.btnDesmarcarAsignado.Name = "btnDesmarcarAsignado";
            this.btnDesmarcarAsignado.Size = new System.Drawing.Size(135, 23);
            this.btnDesmarcarAsignado.TabIndex = 61;
            this.btnDesmarcarAsignado.Text = "Desmarcar Todo";
            this.btnDesmarcarAsignado.UseVisualStyleBackColor = true;
            this.btnDesmarcarAsignado.Click += new System.EventHandler(this.btnDesmarcarAsignado_Click);
            // 
            // btnMarcarAsignado
            // 
            this.btnMarcarAsignado.Location = new System.Drawing.Point(484, 524);
            this.btnMarcarAsignado.Name = "btnMarcarAsignado";
            this.btnMarcarAsignado.Size = new System.Drawing.Size(135, 23);
            this.btnMarcarAsignado.TabIndex = 60;
            this.btnMarcarAsignado.Text = "Marcar Todo";
            this.btnMarcarAsignado.UseVisualStyleBackColor = true;
            this.btnMarcarAsignado.Click += new System.EventHandler(this.btnMarcarAsignado_Click);
            // 
            // btnBuscarAsignado
            // 
            this.btnBuscarAsignado.Location = new System.Drawing.Point(762, 572);
            this.btnBuscarAsignado.Name = "btnBuscarAsignado";
            this.btnBuscarAsignado.Size = new System.Drawing.Size(59, 23);
            this.btnBuscarAsignado.TabIndex = 59;
            this.btnBuscarAsignado.Text = "Buscar";
            this.btnBuscarAsignado.UseVisualStyleBackColor = true;
            this.btnBuscarAsignado.Click += new System.EventHandler(this.btnBuscarAsignado_Click);
            // 
            // txtBuscarAsignado
            // 
            this.txtBuscarAsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarAsignado.Location = new System.Drawing.Point(525, 573);
            this.txtBuscarAsignado.Name = "txtBuscarAsignado";
            this.txtBuscarAsignado.Size = new System.Drawing.Size(231, 22);
            this.txtBuscarAsignado.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(525, 554);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 17);
            this.label1.TabIndex = 57;
            this.label1.Text = "Busqueda";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgBuscarAsignado
            // 
            this.imgBuscarAsignado.BackColor = System.Drawing.Color.Transparent;
            this.imgBuscarAsignado.Location = new System.Drawing.Point(487, 554);
            this.imgBuscarAsignado.Name = "imgBuscarAsignado";
            this.imgBuscarAsignado.Size = new System.Drawing.Size(33, 39);
            this.imgBuscarAsignado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBuscarAsignado.TabIndex = 56;
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
            this.dgvGrillaAsignado.Location = new System.Drawing.Point(484, 229);
            this.dgvGrillaAsignado.Name = "dgvGrillaAsignado";
            this.dgvGrillaAsignado.RowHeadersVisible = false;
            this.dgvGrillaAsignado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrillaAsignado.Size = new System.Drawing.Size(337, 289);
            this.dgvGrillaAsignado.TabIndex = 55;
            this.dgvGrillaAsignado.DataSourceChanged += new System.EventHandler(this.dgvGrillaAsignado_DataSourceChanged);
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
            this.lblTituloAsignado.Location = new System.Drawing.Point(484, 201);
            this.lblTituloAsignado.Name = "lblTituloAsignado";
            this.lblTituloAsignado.Size = new System.Drawing.Size(337, 28);
            this.lblTituloAsignado.TabIndex = 54;
            this.lblTituloAsignado.Text = "Lista de Usuarios Asignados";
            this.lblTituloAsignado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDesmarcarNoAsignado
            // 
            this.btnDesmarcarNoAsignado.Location = new System.Drawing.Point(181, 524);
            this.btnDesmarcarNoAsignado.Name = "btnDesmarcarNoAsignado";
            this.btnDesmarcarNoAsignado.Size = new System.Drawing.Size(135, 23);
            this.btnDesmarcarNoAsignado.TabIndex = 52;
            this.btnDesmarcarNoAsignado.Text = "Desmarcar Todo";
            this.btnDesmarcarNoAsignado.UseVisualStyleBackColor = true;
            this.btnDesmarcarNoAsignado.Click += new System.EventHandler(this.btnDesmarcarNoAsignado_Click);
            // 
            // btnMarcarNoAsignado
            // 
            this.btnMarcarNoAsignado.Location = new System.Drawing.Point(40, 524);
            this.btnMarcarNoAsignado.Name = "btnMarcarNoAsignado";
            this.btnMarcarNoAsignado.Size = new System.Drawing.Size(135, 23);
            this.btnMarcarNoAsignado.TabIndex = 51;
            this.btnMarcarNoAsignado.Text = "Marcar Todo";
            this.btnMarcarNoAsignado.UseVisualStyleBackColor = true;
            this.btnMarcarNoAsignado.Click += new System.EventHandler(this.btnMarcarNoAsignado_Click);
            // 
            // btnBuscarNoAsignado
            // 
            this.btnBuscarNoAsignado.Location = new System.Drawing.Point(318, 572);
            this.btnBuscarNoAsignado.Name = "btnBuscarNoAsignado";
            this.btnBuscarNoAsignado.Size = new System.Drawing.Size(59, 23);
            this.btnBuscarNoAsignado.TabIndex = 50;
            this.btnBuscarNoAsignado.Text = "Buscar";
            this.btnBuscarNoAsignado.UseVisualStyleBackColor = true;
            this.btnBuscarNoAsignado.Click += new System.EventHandler(this.btnBuscarNoAsignado_Click);
            // 
            // txtBuscarNoAsignado
            // 
            this.txtBuscarNoAsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarNoAsignado.Location = new System.Drawing.Point(81, 573);
            this.txtBuscarNoAsignado.Name = "txtBuscarNoAsignado";
            this.txtBuscarNoAsignado.Size = new System.Drawing.Size(231, 22);
            this.txtBuscarNoAsignado.TabIndex = 49;
            // 
            // lblBuscar
            // 
            this.lblBuscar.BackColor = System.Drawing.Color.Transparent;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblBuscar.Location = new System.Drawing.Point(81, 554);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(231, 17);
            this.lblBuscar.TabIndex = 48;
            this.lblBuscar.Text = "Busqueda";
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgBuscarNoAsignado
            // 
            this.imgBuscarNoAsignado.BackColor = System.Drawing.Color.Transparent;
            this.imgBuscarNoAsignado.Location = new System.Drawing.Point(43, 554);
            this.imgBuscarNoAsignado.Name = "imgBuscarNoAsignado";
            this.imgBuscarNoAsignado.Size = new System.Drawing.Size(33, 39);
            this.imgBuscarNoAsignado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBuscarNoAsignado.TabIndex = 47;
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
            this.dgvGrillaNoAsignado.Location = new System.Drawing.Point(40, 229);
            this.dgvGrillaNoAsignado.Name = "dgvGrillaNoAsignado";
            this.dgvGrillaNoAsignado.RowHeadersVisible = false;
            this.dgvGrillaNoAsignado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrillaNoAsignado.Size = new System.Drawing.Size(337, 289);
            this.dgvGrillaNoAsignado.TabIndex = 46;
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
            this.lblTituloNoAsignado.Location = new System.Drawing.Point(40, 201);
            this.lblTituloNoAsignado.Name = "lblTituloNoAsignado";
            this.lblTituloNoAsignado.Size = new System.Drawing.Size(337, 28);
            this.lblTituloNoAsignado.TabIndex = 45;
            this.lblTituloNoAsignado.Text = "Lista de Usuarios No Asignados";
            this.lblTituloNoAsignado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPerfil
            // 
            this.pnlPerfil.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlPerfil.Controls.Add(this.btnNuevoPerfil);
            this.pnlPerfil.Controls.Add(this.cmbPerfil);
            this.pnlPerfil.Controls.Add(this.label2);
            this.pnlPerfil.Location = new System.Drawing.Point(3, 115);
            this.pnlPerfil.Name = "pnlPerfil";
            this.pnlPerfil.Size = new System.Drawing.Size(861, 59);
            this.pnlPerfil.TabIndex = 64;
            // 
            // btnNuevoPerfil
            // 
            this.btnNuevoPerfil.Location = new System.Drawing.Point(462, 17);
            this.btnNuevoPerfil.Name = "btnNuevoPerfil";
            this.btnNuevoPerfil.Size = new System.Drawing.Size(40, 24);
            this.btnNuevoPerfil.TabIndex = 27;
            this.btnNuevoPerfil.Text = "...";
            this.btnNuevoPerfil.UseVisualStyleBackColor = true;
            this.btnNuevoPerfil.Click += new System.EventHandler(this.btnNuevoPerfil_Click);
            // 
            // cmbPerfil
            // 
            this.cmbPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPerfil.FormattingEnabled = true;
            this.cmbPerfil.Location = new System.Drawing.Point(71, 17);
            this.cmbPerfil.Name = "cmbPerfil";
            this.cmbPerfil.Size = new System.Drawing.Size(385, 24);
            this.cmbPerfil.TabIndex = 26;
            this.cmbPerfil.SelectionChangeCommitted += new System.EventHandler(this.cmbPerfil_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(24, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Perfil";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _00010_AsignarUsuarioPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 681);
            this.Controls.Add(this.pnlPerfil);
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
            this.Controls.Add(this.Menu);
            this.Name = "_00010_AsignarUsuarioPerfil";
            this.Text = "_00010_AsignarUsuarioPerfil";
            this.Load += new System.EventHandler(this._00010_AsignarUsuarioPerfil_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscarAsignado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaAsignado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscarNoAsignado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaNoAsignado)).EndInit();
            this.pnlPerfil.ResumeLayout(false);
            this.pnlPerfil.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu;
        private System.Windows.Forms.ToolStripButton btnSalir;
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
        private System.Windows.Forms.Panel pnlPerfil;
        private System.Windows.Forms.Button btnNuevoPerfil;
        private System.Windows.Forms.ComboBox cmbPerfil;
        private System.Windows.Forms.Label label2;
    }
}