namespace InterfazUsuario.Interfaces
{
    partial class Permisos
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblCrearPermiso = new System.Windows.Forms.Label();
            this.btnCrearPermiso = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblModificarPermiso = new System.Windows.Forms.Label();
            this.btnModificarPermiso = new System.Windows.Forms.Button();
            this.btnEliminarPermiso = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(223, 426);
            this.treeView1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(241, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(120, 433);
            this.listBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(367, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 20);
            this.textBox1.TabIndex = 2;
            // 
            // lblCrearPermiso
            // 
            this.lblCrearPermiso.AutoSize = true;
            this.lblCrearPermiso.Location = new System.Drawing.Point(367, 12);
            this.lblCrearPermiso.Name = "lblCrearPermiso";
            this.lblCrearPermiso.Size = new System.Drawing.Size(128, 13);
            this.lblCrearPermiso.TabIndex = 3;
            this.lblCrearPermiso.Tag = "Permiso_Crear";
            this.lblCrearPermiso.Text = "Crear Permiso Compuesto";
            // 
            // btnCrearPermiso
            // 
            this.btnCrearPermiso.Location = new System.Drawing.Point(367, 53);
            this.btnCrearPermiso.Name = "btnCrearPermiso";
            this.btnCrearPermiso.Size = new System.Drawing.Size(156, 23);
            this.btnCrearPermiso.TabIndex = 4;
            this.btnCrearPermiso.Tag = "Permiso_btnCrear";
            this.btnCrearPermiso.Text = "Crear Permiso Compuesto";
            this.btnCrearPermiso.UseVisualStyleBackColor = true;
            this.btnCrearPermiso.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(367, 118);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(156, 20);
            this.textBox2.TabIndex = 5;
            // 
            // lblModificarPermiso
            // 
            this.lblModificarPermiso.AutoSize = true;
            this.lblModificarPermiso.Location = new System.Drawing.Point(367, 102);
            this.lblModificarPermiso.Name = "lblModificarPermiso";
            this.lblModificarPermiso.Size = new System.Drawing.Size(130, 13);
            this.lblModificarPermiso.TabIndex = 6;
            this.lblModificarPermiso.Tag = "Permiso_ModificarNombre";
            this.lblModificarPermiso.Text = "Modificar Nombre Permiso";
            // 
            // btnModificarPermiso
            // 
            this.btnModificarPermiso.Location = new System.Drawing.Point(367, 144);
            this.btnModificarPermiso.Name = "btnModificarPermiso";
            this.btnModificarPermiso.Size = new System.Drawing.Size(156, 23);
            this.btnModificarPermiso.TabIndex = 7;
            this.btnModificarPermiso.Tag = "Permiso_btnModificar";
            this.btnModificarPermiso.Text = "Modificar Permiso";
            this.btnModificarPermiso.UseVisualStyleBackColor = true;
            this.btnModificarPermiso.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEliminarPermiso
            // 
            this.btnEliminarPermiso.Location = new System.Drawing.Point(367, 203);
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.Size = new System.Drawing.Size(156, 23);
            this.btnEliminarPermiso.TabIndex = 8;
            this.btnEliminarPermiso.Tag = "Permiso_btnEliminar";
            this.btnEliminarPermiso.Text = "Eliminar Permiso Compuesto";
            this.btnEliminarPermiso.UseVisualStyleBackColor = true;
            this.btnEliminarPermiso.Click += new System.EventHandler(this.button3_Click);
            // 
            // Permisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 450);
            this.Controls.Add(this.btnEliminarPermiso);
            this.Controls.Add(this.btnModificarPermiso);
            this.Controls.Add(this.lblModificarPermiso);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnCrearPermiso);
            this.Controls.Add(this.lblCrearPermiso);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.treeView1);
            this.Name = "Permisos";
            this.Text = "Permisos";
            this.Load += new System.EventHandler(this.Permisos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblCrearPermiso;
        private System.Windows.Forms.Button btnCrearPermiso;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblModificarPermiso;
        private System.Windows.Forms.Button btnModificarPermiso;
        private System.Windows.Forms.Button btnEliminarPermiso;
    }
}