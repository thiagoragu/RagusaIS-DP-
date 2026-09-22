using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using InterfazUsuario.Interfaces;
using Servicios;

namespace InterfazUsuario
{
    public partial class MenuSeleccion : Form, IObserverIdioma
    {
        BLL_Usuario BLLUsuario;
        BLL_Registro BLLRegistro;
        BLL_Idioma BLL_Idioma;

        BE_Permiso RegistroHistorico = new BE_PermisoS("", 2, false);
        BE_Permiso Idioma = new BE_PermisoS("", 1, false);
        BE_Permiso ManejoUsuarios = new BE_PermisoS("",18, false);
        BE_Permiso ControlPermisos = new BE_PermisoS("", 19, false);
        BE_Permiso HistoricoLogueos = new BE_PermisoS("", 20, false);
        BE_Permiso ControlProductos = new BE_PermisoS("", 21, false);
        BE_Permiso ControlStock = new BE_PermisoS("", 21, false);

        public MenuSeleccion()
        {
            BLLUsuario = new BLL_Usuario();
            BLLRegistro = new BLL_Registro();
            BLL_Idioma = new BLL_Idioma();

            AdministradorIdioma.Instancia.Registrar(this);

            Validate();
            
            InitializeComponent();
        }

        private void controlIdiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Idioma formulario = new Idioma();
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void MenuSeleccion_Load(object sender, EventArgs e)
        {
            ObtenerIdiomas();
        }

        public bool Validar()
        {
            BE_Usuario usuario = SesionSingleton.Instance.Usuario;

            if (SesionSingleton.Instance.EstaLogueado())
            {

                lblEstado.Text = "Logueado";

                this.mnuRegistroHistoricos.Enabled = usuario.ListaPermisos.Any(p => p.TienePermiso(RegistroHistorico));
                this.mnuControlIdiomas.Enabled = usuario.ListaPermisos.Any(p => p.TienePermiso(Idioma));
                this.mnuManejoUsuarios.Enabled = usuario.ListaPermisos.Any(p => p.TienePermiso(ManejoUsuarios));
                this.mnuControlPermisos.Enabled = usuario.ListaPermisos.Any(p => p.TienePermiso(ControlPermisos));
                this.mnuHistoricoLogueos.Enabled = usuario.ListaPermisos.Any(p => p.TienePermiso(HistoricoLogueos));
                this.mnuControlProductos.Enabled = usuario.ListaPermisos.Any(p => p.TienePermiso(ControlProductos));
                this.mnuControlStock.Enabled = usuario.ListaPermisos.Any(p => p.TienePermiso(ControlStock));
                this.mnuUsuario.Enabled = false;
            }
            else
            {
                lblEstado.Text = "Deslogueado";
                this.mnuRegistroHistoricos.Enabled = false;
                this.mnuControlIdiomas.Enabled = false;
                this.mnuManejoUsuarios.Enabled = false;
                this.mnuControlPermisos.Enabled = false;
                this.mnuHistoricoLogueos.Enabled = false;
                this.mnuControlProductos.Enabled = false;
                this.mnuControlStock.Enabled = false;
                this.mnuUsuario.Enabled = true;
            }
            return true;
        }

        private void mnuUsuario_Click(object sender, EventArgs e)
        {
            Usuario formulario = new Usuario();
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void btnDesloguearse_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    foreach (Form formHijo in this.MdiChildren)
                    {
                        formHijo.Close();
                    }

                    BLLUsuario.Desloguearse();

                    BE_Registro Registro = new BE_Registro();
                    Registro.Nombre = Interfaces.Usuario.NombreUsuario;
                    Registro.Fecha = DateTime.Now;
                    Registro.Tipo = "Log-Out";

                    BLLRegistro.CrearRegistro(Registro);

                    MessageBox.Show("Sesion cerrada correctamente");
                }
                Validar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay ninguna sesion iniciada");
            }
            
        }

        private void mnuManejoUsuarios_Click(object sender, EventArgs e)
        {
            ManejoUsuarios formulario = new ManejoUsuarios();
            formulario.MdiParent = this;
            ObtenerIdiomas();
            formulario.Show();
        }

        private void mnuControlPermisos_Click(object sender, EventArgs e)
        {
            Permisos formulario = new Permisos();
            formulario.MdiParent = this;
            ObtenerIdiomas();
            formulario.Show();
        }

        private void mnuHistoricoLogueos_Click(object sender, EventArgs e)
        {
            HistoricoLogs formulario = new HistoricoLogs();
            formulario.MdiParent = this;
            ObtenerIdiomas();
            formulario.Show();
        }

        private void mnuControlProductos_Click(object sender, EventArgs e)
        {
            Productos formulario = new Productos();
            formulario.MdiParent = this;
            ObtenerIdiomas();
            formulario.Show();
        }

        private void mnuRegistroHistoricos_Click(object sender, EventArgs e)
        {
            HistoricoProductos formulario = new HistoricoProductos();
            formulario.MdiParent = this;
            ObtenerIdiomas();
            formulario.Show();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            AdministradorIdioma.Instancia.CambiarIdioma((BE_Idioma)comboBox1.SelectedItem);
        }

        public void ActualizarIdioma(int Idioma)
        {
           this.mnuUsuario.Text = BLL_Idioma.GetTraduccion(this.mnuUsuario.Tag.ToString(), Idioma);
           this.mnuManejoUsuarios.Text = BLL_Idioma.GetTraduccion(this.mnuManejoUsuarios.Tag.ToString(), Idioma);
           this.mnuControlPermisos.Text = BLL_Idioma.GetTraduccion(this.mnuControlPermisos.Tag.ToString(), Idioma);
           this.mnuControlIdiomas.Text = BLL_Idioma.GetTraduccion(this.mnuControlIdiomas.Tag.ToString(), Idioma);
           this.mnuHistoricoLogueos.Text = BLL_Idioma.GetTraduccion(this.mnuHistoricoLogueos.Tag.ToString(), Idioma);
           this.mnuControlProductos.Text = BLL_Idioma.GetTraduccion(this.mnuControlProductos.Tag.ToString(), Idioma);
           this.mnuControlStock.Text = BLL_Idioma.GetTraduccion(this.mnuControlStock.Tag.ToString(), Idioma);
           this.mnuRegistroHistoricos.Text = BLL_Idioma.GetTraduccion(this.mnuRegistroHistoricos.Tag.ToString(), Idioma);
           this.lblEstado.Text = BLL_Idioma.GetTraduccion(this.lblEstado.Tag.ToString(), Idioma);
           this.btnDesloguearse.Text = BLL_Idioma.GetTraduccion(this.btnDesloguearse.Tag.ToString(), Idioma);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void ObtenerIdiomas()
        {
            this.comboBox1.DataSource = BLL_Idioma.GetIdiomas();
        }

        private void MenuSeleccion_MouseClick(object sender, MouseEventArgs e)
        {
            ObtenerIdiomas();
        }

        private void MenuSeleccion_Click(object sender, EventArgs e)
        {
            ObtenerIdiomas();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlStock formulario = new ControlStock();
            formulario.MdiParent = this;
            ObtenerIdiomas();
            formulario.Show();
        }
    }
}
