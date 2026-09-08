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
using System.Windows.Forms.VisualStyles;

namespace InterfazUsuario.Interfaces
{
    public partial class ManejoUsuarios : Form, IObserverIdioma
    {
        BLL_Usuario BLLUsuario;
        BLL_Idioma BLLIdioma;
        BLL_Permiso BLLPermiso;
        BE_Usuario Usuario;
        public ManejoUsuarios()
        {
            BLLUsuario = new BLL_Usuario();
            BLLIdioma = new BLL_Idioma();
            BLLPermiso = new BLL_Permiso();

            AdministradorIdioma.Instancia.Registrar(this);
            Validate();
            InitializeComponent();

        }

        public void ActualizarForm()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = BLLUsuario.ObtenerUsuarios();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbNombre.Text == string.Empty || txbContrasena.Text == string.Empty)
                {
                    MessageBox.Show("Se deben llenar los campos correspondientes");
                }
                else if (txbNombre.Text.Length < 4 || txbContrasena.Text.Length < 4)
                {
                    MessageBox.Show("El nombre y la contrasena deben superar los 4 caracteres");
                }
                else
                {
                    BE_Usuario UsuarioCreado = new BE_Usuario();
                    UsuarioCreado.Nombre = txbNombre.Text;
                    UsuarioCreado.Contrasena = txbContrasena.Text;
                    UsuarioCreado.Permiso = (BE_Permiso)lsbPermiso.SelectedItem;

                    BE_Permiso PermisoSeleccionado = (BE_Permiso)lsbPermiso.SelectedItem;
                    UsuarioCreado.ID = PermisoSeleccionado.ID;

                    if (BLLUsuario.AgregarUsuario(UsuarioCreado) == true) 
                    {
                        MessageBox.Show("Se agrego el usuario correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el usuario");
                    }
                    ActualizarForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ActualizarIdioma(int Idioma)
        {
            lblNombre.Text = BLLIdioma.GetTraduccion(lblNombre.Tag.ToString(), Idioma);
            lblContrasena.Text = BLLIdioma.GetTraduccion(lblContrasena.Tag.ToString(), Idioma);
            lblPermiso.Text = BLLIdioma.GetTraduccion(lblPermiso.Tag.ToString(), Idioma);
            btnAgregar.Text = BLLIdioma.GetTraduccion(btnAgregar.Tag.ToString(), Idioma);
            btnBorrar.Text = BLLIdioma.GetTraduccion(btnBorrar.Tag.ToString(), Idioma);
            btnModificar.Text = BLLIdioma.GetTraduccion(btnModificar.Tag.ToString(), Idioma);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow?.DataBoundItem != null && dataGridView1.CurrentRow != null)
                {
                    BE_Usuario UsuarioSeleccionado = (BE_Usuario)dataGridView1.CurrentRow.DataBoundItem;

                    BE_Usuario UsuarioUtilizado = new BE_Usuario();
                    UsuarioUtilizado.Nombre = SesionSingleton.Instance.Usuario.Nombre;
                    UsuarioUtilizado.Contrasena = SesionSingleton.Instance.Usuario.Contrasena;

                    if(BLLUsuario.VerificarUsuario(UsuarioUtilizado,UsuarioSeleccionado) == true)
                    {
                        BLLUsuario.EliminarUsuario(UsuarioSeleccionado);
                        ActualizarForm();
                    }
                    else
                    {
                        MessageBox.Show("No puede borrar el mismo usuario que se está utilizando. Error");
                    }
                }
                else 
                {
                    MessageBox.Show("Debe seleccionar un Usuario para borrar. Se procede a no realizar cambios");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbNombre.Text == string.Empty || txbContrasena.Text == string.Empty)
                {
                    MessageBox.Show("Se deben llenar los campos correspondientes");
                }
                else if (txbNombre.Text.Length < 4 || txbContrasena.Text.Length < 4)
                {
                    MessageBox.Show("El nombre y la contrasena deben superar los 4 caracteres");
                }
                else
                {
                    if(dataGridView1.CurrentRow != null && dataGridView1.CurrentRow?.DataBoundItem != null)
                    {
                        BE_Usuario UsuarioSeleccionado = (BE_Usuario)dataGridView1.CurrentRow.DataBoundItem;
                        BE_Usuario UsuarioModificado = new BE_Usuario();
                        UsuarioModificado.Nombre = txbNombre.Text;
                        UsuarioModificado.Contrasena = txbContrasena.Text;
                        UsuarioModificado.ID = UsuarioSeleccionado.ID;
                        UsuarioModificado.Permiso = (BE_Permiso)lsbPermiso.SelectedItem;

                        BLLUsuario.ModificarUsuario(UsuarioModificado);
                        ActualizarForm();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManejoUsuarios_Load(object sender, EventArgs e)
        {
            ActualizarForm();
            CargarComboBox();
        }

        public void CargarComboBox()
        {
            lsbPermiso.DataSource = null;
            lsbPermiso.DataSource = BLLPermiso.ObtenerPermisoC();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BE_Usuario UsuarioSeleccionado = (BE_Usuario)dataGridView1.CurrentRow.DataBoundItem;

            txbNombre.Text = UsuarioSeleccionado.Nombre;
            txbContrasena.Text = UsuarioSeleccionado.Contrasena;

            Usuario = (BE_Usuario)this.dataGridView1.CurrentRow.DataBoundItem;
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = Usuario.ListaPermisos;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
