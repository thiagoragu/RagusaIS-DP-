using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Microsoft.Win32;
using Servicios;

namespace InterfazUsuario.Interfaces
{
    public partial class Usuario : Form, IObserverIdioma
    {
        BLL_Usuario BLLUsuario;
        BLL_Registro BLLRegistro;
        BLL_Idioma BLLIdioma;
        public static string NombreUsuario;
        public Usuario()
        {
            InitializeComponent();
            BLLUsuario = new BLL_Usuario();
            BLLRegistro = new BLL_Registro();
            BLLIdioma = new BLL_Idioma();

            AdministradorIdioma.Instancia.Registrar(this);

            Validate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                {
                    MessageBox.Show("Se deben llenar los campos");
                }
                else if (textBox1.Text != string.Empty && textBox2.Text == string.Empty)
                {
                    MessageBox.Show("Se deben llenar el campo 'Constrasena'");
                }
                else if (textBox1.Text == string.Empty && textBox2.Text != string.Empty)
                {
                    MessageBox.Show("Se deben llenar el cammpo 'Nombre'");
                }
                else
                {
                    bool res = BLLUsuario.Loguearse(textBox1.Text, textBox2.Text);

                    if (res)
                    {
                        NombreUsuario = textBox1.Text;

                        MenuSeleccion form = (MenuSeleccion)this.MdiParent;
                        form.Validar();
                        btnLoguearse.Enabled = false;

                        BE_Registro Registro = new BE_Registro();
                        Registro.Nombre = textBox1.Text;
                        Registro.Fecha = DateTime.Now;
                        Registro.Tipo = "Log-In";

                        BLLRegistro.CrearRegistro(Registro);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario incorrecto");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Logueado_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        public void ActualizarIdioma(int Idioma)
        {
            this.label1.Text = BLLIdioma.GetTraduccion(label1.Tag.ToString(), Idioma);
            this.label2.Text = BLLIdioma.GetTraduccion(label2.Tag.ToString(), Idioma);
            this.btnLoguearse.Text = BLLIdioma.GetTraduccion(btnLoguearse.Tag.ToString(), Idioma);
            
        }

    }
}
