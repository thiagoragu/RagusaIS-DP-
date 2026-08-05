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
    public partial class Idioma : Form, IObserverIdioma
    {
        BLL_Idioma BLLIdioma;
        BE_Idioma BEIdioma;
        BLL_Traduccion BLL_Traduccion;
        public Idioma()
        {
            BLLIdioma = new BLL_Idioma();
            BEIdioma = new BE_Idioma();
            BLL_Traduccion = new BLL_Traduccion();

            AdministradorIdioma.Instancia.Registrar(this);
            Validate();

            InitializeComponent();
        }

        private void Idioma_Load(object sender, EventArgs e)
        {
            CargarListaIdioma();
        }

        public void CargarListaIdioma()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BLLIdioma.GetIdiomas();
        }
        public void CargarListaTraducciones(int ID)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = BLLIdioma.ObtenerTraducciones(ID);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BE_Idioma Idioma = (BE_Idioma)dataGridView1.CurrentRow.DataBoundItem;
            CargarListaTraducciones(Idioma.ID);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == null && textBox1.Text == "")
                {
                    string IdiomaNuevo = textBox1.Text;
                    BLLIdioma.AgregarIdioma(IdiomaNuevo);
                    CargarListaIdioma();
                }
                else
                {
                    MessageBox.Show("Debe introducir algun texto para crear el Idioma. Se procede a no crearlo");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView2.CurrentRow?.DataBoundItem != null && dataGridView2.CurrentRow != null)
                {
                    BE_Traduccion Traduccion = (BE_Traduccion)dataGridView2.CurrentRow.DataBoundItem;

                    int IDIdioma = Traduccion.IDIdioma;
                    int IDTag = Traduccion.IDTag;
                    string TraduccionNueva = textBox2.Text;

                    if(TraduccionNueva != null && TraduccionNueva != "")
                    {
                        BLL_Traduccion.ModificarTraduccion(IDIdioma, IDTag, TraduccionNueva);
                        CargarListaIdioma();
                    }
                    else
                    {
                        MessageBox.Show("Se debe escribir al menos un caracter en la nueva traducción. No se realizaron cambios");
                    }
                }
                else
                {
                    MessageBox.Show("Se debe seleccionar un Idioma para modificar su traducción. Se procede a no realizar cambios");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ActualizarIdioma(int Idioma)
        {
            lblIdioma.Text = BLLIdioma.GetTraduccion(lblIdioma.Tag.ToString(), Idioma);
            lblTraducciones.Text = BLLIdioma.GetTraduccion(lblTraducciones.Tag.ToString(), Idioma);
            btnAgregarIdioma.Text = BLLIdioma.GetTraduccion(btnAgregarIdioma.Tag.ToString(), Idioma);
            btnModificarIdioma.Text = BLLIdioma.GetTraduccion(btnModificarIdioma.Tag.ToString(), Idioma);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BE_Traduccion Traduccion = (BE_Traduccion)dataGridView2.CurrentRow.DataBoundItem;

            textBox2.Text = Traduccion.Traduccion;
        }
    }
}
