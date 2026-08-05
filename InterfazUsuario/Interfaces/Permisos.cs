using BE;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazUsuario.Interfaces
{
    public partial class Permisos : Form, IObserverIdioma
    {
        private BLL_Permiso BLL_Permiso;
        public BLL_Idioma BLLIdioma;
        public Permisos()
        {
            InitializeComponent();
            BLL_Permiso = new BLL_Permiso();
            BLLIdioma = new BLL_Idioma();

            AdministradorIdioma.Instancia.Registrar(this);

            Validate();
        }

        private void Permisos_Load(object sender, EventArgs e)
        {
            CargarPermisos();
        }

        private void CargarPermisos()
        {
            cargarArbolPermisos();
            cargarPermisosSimples();
        }

        private void cargarPermisosSimples()
        {
            this.listBox1.DataSource = null;
            this.listBox1.DataSource = BLL_Permiso.ObtenerPermisos();
        }

        private void cargarArbolPermisos()
        {
            this.treeView1.Nodes.Clear();

            foreach (BE_Permiso permiso in BLL_Permiso.ObtenerPermisosArbol())
            {
                this.treeView1.Nodes.Add(crearNodoPermiso(permiso));
                treeView1.ExpandAll();
            }
        }

        private TreeNode crearNodoPermiso(BE_Permiso permiso)
        {
            TreeNode node = null;
            try
            {
                node = new TreeNode(permiso.Nombre);
                node.Tag = permiso.ID;

                if (permiso is BE_PermisoC compuesto)
                {
                    foreach (var subPermission in compuesto.ObtenerPermisos())
                    {
                        node.Nodes.Add(crearNodoPermiso(subPermission));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crear Nodo");
            }
            return node;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<BE_Permiso> permisosSeleccionados = new List<BE_Permiso>();
                string permisoNombre = this.textBox1.Text;

                if (!string.IsNullOrEmpty(permisoNombre))
                {
                    foreach (BE_Permiso perm in this.listBox1.SelectedItems)
                    {
                        permisosSeleccionados.Add(perm);
                    }

                    int IDPermisoC = BLL_Permiso.AgregarPermisoCompuesto(permisoNombre);

                    foreach (BE_Permiso Permisos in permisosSeleccionados)
                    {
                        if (BLL_Permiso.GeneraCiclo(IDPermisoC, Permisos.ID))
                        {
                            MessageBox.Show("No se puede asignar '" + Permisos.Nombre + "' porque generaria una referencia circular.");
                            continue;
                        }
                        BLL_Permiso.AgregarRelacionPH(IDPermisoC, Permisos.ID);
                    }
                }
                MessageBox.Show("Se Agregó el permiso correctamente");
                CargarPermisos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<BE_Permiso> permisosSeleccionados = new List<BE_Permiso>();
            string PermisoNombreNuevo = this.textBox2.Text;
            TreeNode NodoSeleccionado = treeView1.SelectedNode;
            int IDPermisoSeleccionado = (int)NodoSeleccionado.Tag;

            if (!string.IsNullOrEmpty(PermisoNombreNuevo))
            {
                foreach (BE_Permiso perm in this.listBox1.SelectedItems)
                {
                    if (perm.ID == IDPermisoSeleccionado)
                    {
                        MessageBox.Show("No se puede asignar el mismo permiso a si mismo. Se procede a agregar el resto");
                    }
                    else if (BLL_Permiso.GeneraCiclo(IDPermisoSeleccionado, perm.ID))
                    {
                        MessageBox.Show("No se puede asignar '" + perm.Nombre + "' porque generaria una referencia circular. Se procede a agregar el resto");
                    }
                    else
                    {
                        permisosSeleccionados.Add(perm);
                    }
                }

                BLL_Permiso.EliminarRelacionesPermisoC(IDPermisoSeleccionado);

                foreach (BE_Permiso Permisos in permisosSeleccionados)
                {
                    BLL_Permiso.ModificarRelacion(IDPermisoSeleccionado, Permisos.ID);
                }
                BLL_Permiso.ModificarNombre(IDPermisoSeleccionado, PermisoNombreNuevo);
                MessageBox.Show("Se modificó el permiso correctamente");
                CargarPermisos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos un permiso para realizar la nueva relacion");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode NodoSeleccionado = treeView1.SelectedNode;
                int IDPermisoPadre = (int)NodoSeleccionado.Tag;

                BLL_Permiso.EliminarPermiso(IDPermisoPadre);
                CargarPermisos();
                MessageBox.Show("Se eliminó el permiso correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ActualizarIdioma(int Idioma)
        {
            this.lblCrearPermiso.Text = BLLIdioma.GetTraduccion(lblCrearPermiso.Tag.ToString(), Idioma);
            this.lblModificarPermiso.Text = BLLIdioma.GetTraduccion(lblModificarPermiso.Tag.ToString(), Idioma);
            this.btnCrearPermiso.Text = BLLIdioma.GetTraduccion(btnCrearPermiso.Tag.ToString(), Idioma);
            this.btnEliminarPermiso.Text = BLLIdioma.GetTraduccion(btnEliminarPermiso.Tag.ToString(), Idioma);
            this.btnModificarPermiso.Text = BLLIdioma.GetTraduccion(btnModificarPermiso.Tag.ToString(), Idioma);
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            TreeNode NodoSeleccionado = treeView1.SelectedNode;

            textBox2.Text = NodoSeleccionado.Text;
        }
    }
}
