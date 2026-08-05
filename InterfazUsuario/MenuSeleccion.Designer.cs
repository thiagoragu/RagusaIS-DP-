namespace InterfazUsuario
{
    partial class MenuSeleccion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManejoUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuControlPermisos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuControlIdiomas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistoricoLogueos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuControlProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistroHistoricos = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnDesloguearse = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsuario,
            this.mnuManejoUsuarios,
            this.mnuControlPermisos,
            this.mnuControlIdiomas,
            this.mnuHistoricoLogueos,
            this.mnuControlProductos,
            this.mnuRegistroHistoricos,
            this.permisosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(978, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuUsuario
            // 
            this.mnuUsuario.Name = "mnuUsuario";
            this.mnuUsuario.Size = new System.Drawing.Size(59, 20);
            this.mnuUsuario.Tag = "Menu_Usuario";
            this.mnuUsuario.Text = "Usuario";
            this.mnuUsuario.Click += new System.EventHandler(this.mnuUsuario_Click);
            // 
            // mnuManejoUsuarios
            // 
            this.mnuManejoUsuarios.Enabled = false;
            this.mnuManejoUsuarios.Name = "mnuManejoUsuarios";
            this.mnuManejoUsuarios.Size = new System.Drawing.Size(123, 20);
            this.mnuManejoUsuarios.Tag = "Menu_ManejoUsuario";
            this.mnuManejoUsuarios.Text = "Manejo de Usuarios";
            this.mnuManejoUsuarios.Click += new System.EventHandler(this.mnuManejoUsuarios_Click);
            // 
            // mnuControlPermisos
            // 
            this.mnuControlPermisos.Enabled = false;
            this.mnuControlPermisos.Name = "mnuControlPermisos";
            this.mnuControlPermisos.Size = new System.Drawing.Size(126, 20);
            this.mnuControlPermisos.Tag = "Menu_ControlPermisos";
            this.mnuControlPermisos.Text = "Control de Permisos";
            this.mnuControlPermisos.Click += new System.EventHandler(this.mnuControlPermisos_Click);
            // 
            // mnuControlIdiomas
            // 
            this.mnuControlIdiomas.Enabled = false;
            this.mnuControlIdiomas.Name = "mnuControlIdiomas";
            this.mnuControlIdiomas.Size = new System.Drawing.Size(120, 20);
            this.mnuControlIdiomas.Tag = "Menu_Controlidiomas";
            this.mnuControlIdiomas.Text = "Control de Idiomas";
            this.mnuControlIdiomas.Click += new System.EventHandler(this.controlIdiomasToolStripMenuItem_Click);
            // 
            // mnuHistoricoLogueos
            // 
            this.mnuHistoricoLogueos.Enabled = false;
            this.mnuHistoricoLogueos.Name = "mnuHistoricoLogueos";
            this.mnuHistoricoLogueos.Size = new System.Drawing.Size(115, 20);
            this.mnuHistoricoLogueos.Tag = "Menu_HistoricoLogueos";
            this.mnuHistoricoLogueos.Text = "Historico Logueos";
            this.mnuHistoricoLogueos.Click += new System.EventHandler(this.mnuHistoricoLogueos_Click);
            // 
            // mnuControlProductos
            // 
            this.mnuControlProductos.Enabled = false;
            this.mnuControlProductos.Name = "mnuControlProductos";
            this.mnuControlProductos.Size = new System.Drawing.Size(132, 20);
            this.mnuControlProductos.Tag = "Menu_ControlProductos";
            this.mnuControlProductos.Text = "Control de Productos";
            this.mnuControlProductos.Click += new System.EventHandler(this.mnuControlProductos_Click);
            // 
            // mnuRegistroHistoricos
            // 
            this.mnuRegistroHistoricos.Enabled = false;
            this.mnuRegistroHistoricos.Name = "mnuRegistroHistoricos";
            this.mnuRegistroHistoricos.Size = new System.Drawing.Size(134, 20);
            this.mnuRegistroHistoricos.Tag = "Menu_RegistroHistoricos";
            this.mnuRegistroHistoricos.Text = "Registro de Historicos";
            this.mnuRegistroHistoricos.Click += new System.EventHandler(this.mnuRegistroHistoricos_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblEstado.Location = new System.Drawing.Point(12, 345);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(39, 17);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Tag = "Menu_Estado";
            this.lblEstado.Text = "Estado";
            this.lblEstado.UseCompatibleTextRendering = true;
            // 
            // btnDesloguearse
            // 
            this.btnDesloguearse.AutoSize = true;
            this.btnDesloguearse.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDesloguearse.Location = new System.Drawing.Point(12, 365);
            this.btnDesloguearse.Name = "btnDesloguearse";
            this.btnDesloguearse.Size = new System.Drawing.Size(103, 28);
            this.btnDesloguearse.TabIndex = 4;
            this.btnDesloguearse.Tag = "Menu_Desloguearse";
            this.btnDesloguearse.Text = "Desloguearse";
            this.btnDesloguearse.UseCompatibleTextRendering = true;
            this.btnDesloguearse.UseVisualStyleBackColor = true;
            this.btnDesloguearse.Click += new System.EventHandler(this.btnDesloguearse_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(883, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(83, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // permisosToolStripMenuItem
            // 
            //this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            //this.permisosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            //this.permisosToolStripMenuItem.Text = "Permisos";
            //this.permisosToolStripMenuItem.Click += new System.EventHandler(this.permisosToolStripMenuItem_Click);
            // 
            // MenuSeleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 401);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnDesloguearse);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuSeleccion";
            this.Tag = "MenuSeleccion_Form";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MenuSeleccion_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuario;
        private System.Windows.Forms.ToolStripMenuItem mnuManejoUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuControlPermisos;
        private System.Windows.Forms.ToolStripMenuItem mnuControlIdiomas;
        private System.Windows.Forms.ToolStripMenuItem mnuHistoricoLogueos;
        private System.Windows.Forms.ToolStripMenuItem mnuControlProductos;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistroHistoricos;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnDesloguearse;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
    }
}

