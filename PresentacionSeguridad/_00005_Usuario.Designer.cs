namespace PresentacionSeguridad
{
    partial class _00005_Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00005_Usuario));
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.btnCrearUsuario = new System.Windows.Forms.ToolStripButton();
            this.btnRestablecer = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnBloquear = new System.Windows.Forms.ToolStripButton();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            this.btnBusar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.imgBuscar = new System.Windows.Forms.PictureBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.btnMarcarTodo = new System.Windows.Forms.Button();
            this.btnDesmarcarTodo = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCrearUsuario,
            this.btnRestablecer,
            this.btnSalir,
            this.toolStripSeparator1,
            this.btnActualizar,
            this.btnBloquear});
            this.Menu.Location = new System.Drawing.Point(0, 60);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(785, 47);
            this.Menu.TabIndex = 4;
            this.Menu.Text = "toolStrip1";
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnCrearUsuario.Image")));
            this.btnCrearUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(82, 44);
            this.btnCrearUsuario.Text = "Crear Usuario";
            this.btnCrearUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Image = ((System.Drawing.Image)(resources.GetObject("btnRestablecer.Image")));
            this.btnRestablecer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRestablecer.Name = "btnRestablecer";
            this.btnRestablecer.Size = new System.Drawing.Size(134, 44);
            this.btnRestablecer.Text = "Restablecer Contraseña";
            this.btnRestablecer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRestablecer.Click += new System.EventHandler(this.btnRestablecer_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(63, 44);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnBloquear
            // 
            this.btnBloquear.Image = ((System.Drawing.Image)(resources.GetObject("btnBloquear.Image")));
            this.btnBloquear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.Size = new System.Drawing.Size(101, 44);
            this.btnBloquear.Text = "Bloquear Usuario";
            this.btnBloquear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBloquear.Click += new System.EventHandler(this.btnBloquear_Click);
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.Controls.Add(this.btnBusar);
            this.pnlBuscar.Controls.Add(this.label1);
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.imgBuscar);
            this.pnlBuscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBuscar.Location = new System.Drawing.Point(0, 107);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(785, 60);
            this.pnlBuscar.TabIndex = 5;
            // 
            // btnBusar
            // 
            this.btnBusar.Location = new System.Drawing.Point(469, 17);
            this.btnBusar.Name = "btnBusar";
            this.btnBusar.Size = new System.Drawing.Size(82, 27);
            this.btnBusar.TabIndex = 3;
            this.btnBusar.Text = "Buscar";
            this.btnBusar.UseVisualStyleBackColor = true;
            this.btnBusar.Click += new System.EventHandler(this.btnBusar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(117, 21);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(337, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            // 
            // imgBuscar
            // 
            this.imgBuscar.Image = global::PresentacionSeguridad.Properties.Resources.Buscar;
            this.imgBuscar.Location = new System.Drawing.Point(14, 10);
            this.imgBuscar.Name = "imgBuscar";
            this.imgBuscar.Size = new System.Drawing.Size(40, 40);
            this.imgBuscar.TabIndex = 0;
            this.imgBuscar.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.AllowUserToAddRows = false;
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvUsuario.Location = new System.Drawing.Point(0, 167);
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.Size = new System.Drawing.Size(785, 335);
            this.dgvUsuario.TabIndex = 6;
            this.dgvUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuario_CellContentClick);
            // 
            // btnMarcarTodo
            // 
            this.btnMarcarTodo.Image = ((System.Drawing.Image)(resources.GetObject("btnMarcarTodo.Image")));
            this.btnMarcarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcarTodo.Location = new System.Drawing.Point(497, 508);
            this.btnMarcarTodo.Name = "btnMarcarTodo";
            this.btnMarcarTodo.Size = new System.Drawing.Size(125, 34);
            this.btnMarcarTodo.TabIndex = 7;
            this.btnMarcarTodo.Text = "Marcar Todo";
            this.btnMarcarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMarcarTodo.UseVisualStyleBackColor = true;
            this.btnMarcarTodo.Click += new System.EventHandler(this.btnMarcarTodo_Click);
            // 
            // btnDesmarcarTodo
            // 
            this.btnDesmarcarTodo.Image = ((System.Drawing.Image)(resources.GetObject("btnDesmarcarTodo.Image")));
            this.btnDesmarcarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesmarcarTodo.Location = new System.Drawing.Point(648, 508);
            this.btnDesmarcarTodo.Name = "btnDesmarcarTodo";
            this.btnDesmarcarTodo.Size = new System.Drawing.Size(125, 34);
            this.btnDesmarcarTodo.TabIndex = 8;
            this.btnDesmarcarTodo.Text = "Desmarcar Todo";
            this.btnDesmarcarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDesmarcarTodo.UseVisualStyleBackColor = true;
            this.btnDesmarcarTodo.Click += new System.EventHandler(this.btnDesmarcarTodo_Click);
            // 
            // _00005_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 573);
            this.Controls.Add(this.btnDesmarcarTodo);
            this.Controls.Add(this.btnMarcarTodo);
            this.Controls.Add(this.dgvUsuario);
            this.Controls.Add(this.pnlBuscar);
            this.Controls.Add(this.Menu);
            this.Name = "_00005_Usuario";
            this.Text = "_00005_Usuario";
            this.Load += new System.EventHandler(this._00005_Usuario_Load);
            this.Controls.SetChildIndex(this.Menu, 0);
            this.Controls.SetChildIndex(this.pnlBuscar, 0);
            this.Controls.SetChildIndex(this.dgvUsuario, 0);
            this.Controls.SetChildIndex(this.btnMarcarTodo, 0);
            this.Controls.SetChildIndex(this.btnDesmarcarTodo, 0);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.pnlBuscar.ResumeLayout(false);
            this.pnlBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu;
        private System.Windows.Forms.ToolStripButton btnCrearUsuario;
        
        private System.Windows.Forms.ToolStripButton btnRestablecer;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.Button btnBusar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.PictureBox imgBuscar;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.ToolStripButton btnBloquear;
        private System.Windows.Forms.Button btnDesmarcarTodo;
        private System.Windows.Forms.Button btnMarcarTodo;
    }
}