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
    public partial class ControlStock : Form, IObserverIdioma
    {
        BLL_Stock BLLStock;
        BLL_Idioma BLLIdioma;
        public ControlStock()
        {
            BLLStock = new BLL_Stock();
            BLLIdioma = new BLL_Idioma();

            AdministradorIdioma.Instancia.Registrar(this);
            Validate();
            InitializeComponent();
        }

        public void Actualizar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BLLStock.ListarStock();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Stock StockAgregado = new BE_Stock();
                StockAgregado.Nombre = textBox1.Text;
                StockAgregado.Cantidad = Convert.ToInt32(textBox2.Text);
                StockAgregado.Fecha = DateTime.Now;

                if (comboBox1.Text == "Infusion")
                {
                    StockAgregado.Tipo = 1;
                    BLLStock.AgregarStock(StockAgregado);
                }
                else if (comboBox1.Text == "Alimento")
                {
                    StockAgregado.Tipo = 2;
                    BLLStock.AgregarStock(StockAgregado);
                }
                else if (comboBox1.Text == "Snack")
                {
                    StockAgregado.Tipo = 3;
                    BLLStock.AgregarStock(StockAgregado);
                }
                else
                {
                    MessageBox.Show("No se puede agregar el stock. Error");
                }
                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Stock StockSeleccionado = (BE_Stock)dataGridView1.CurrentRow.DataBoundItem;

                if(StockSeleccionado != null)
                {
                    BLLStock.EliminarStock(StockSeleccionado);
                    Actualizar();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Infusion")
                {
                    BE_Stock StockNuevo = new BE_Stock();
                    StockNuevo.Nombre = textBox1.Text;
                    StockNuevo.Cantidad = Convert.ToInt32(textBox2.Text);
                    StockNuevo.Fecha = DateTime.Now;
                    StockNuevo.Tipo = 1;
                    BE_Stock StockSeleccionado = (BE_Stock)dataGridView1.CurrentRow.DataBoundItem;
                    BLLStock.ModificarStock(StockNuevo, StockSeleccionado);
                }
                else if (comboBox1.Text == "Alimento")
                {
                    BE_Stock StockNuevo = new BE_Stock();
                    StockNuevo.Nombre = textBox1.Text;
                    StockNuevo.Cantidad = Convert.ToInt32(textBox2.Text);
                    StockNuevo.Fecha = DateTime.Now;
                    StockNuevo.Tipo = 2;
                    BE_Stock StockSeleccionado = (BE_Stock)dataGridView1.CurrentRow.DataBoundItem;
                    BLLStock.ModificarStock(StockNuevo, StockSeleccionado);
                }
                else if (textBox2.Text == "Snack")
                {
                    BE_Stock StockNuevo = new BE_Stock();
                    StockNuevo.Nombre = textBox1.Text;
                    StockNuevo.Cantidad = Convert.ToInt32(textBox2.Text);
                    StockNuevo.Fecha = DateTime.Now;
                    StockNuevo.Tipo = 3;
                    BE_Stock StockSeleccionado = (BE_Stock)dataGridView1.CurrentRow.DataBoundItem;
                    BLLStock.ModificarStock(StockNuevo, StockSeleccionado);
                }
                else
                {
                    MessageBox.Show("No se puede agregar el stock. Error");
                }
                Actualizar();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void ControlStock_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        public void ActualizarIdioma(int Idioma)
        {
            lblNombre.Text = BLLIdioma.GetTraduccion(lblNombre.Tag.ToString(), Idioma);
            lblCantidad.Text = BLLIdioma.GetTraduccion(lblCantidad.Tag.ToString(), Idioma);
            lblTipo.Text = BLLIdioma.GetTraduccion(lblTipo.Tag.ToString(), Idioma);
            btnAgregar.Text = BLLIdioma.GetTraduccion(btnAgregar.Tag.ToString(), Idioma);
            btnEliminar.Text = BLLIdioma.GetTraduccion(btnEliminar.Tag.ToString(), Idioma);
            btnModificar.Text = BLLIdioma.GetTraduccion(btnModificar.Tag.ToString(), Idioma);
            btnChequear.Text = BLLIdioma.GetTraduccion(btnChequear.Tag.ToString(), Idioma);
        }

        private void btnChequear_Click(object sender, EventArgs e)
        {
            BE_Stock StockAChequear = (BE_Stock)dataGridView1.CurrentRow.DataBoundItem;

            DateTime fechaAdquisicion = StockAChequear.Fecha;
            DateTime fechaActual = DateTime.Now;

            int diasTranscurridos = (int)(fechaActual - fechaAdquisicion).TotalDays;

            if (diasTranscurridos > 30)
            {
                MessageBox.Show("El producto tiene más de 30 días en stock. Está vencido!");
            }
            else
            {
                MessageBox.Show($"El producto está en regla. Tiene estos días en stock: {diasTranscurridos}");
            }
        }
    }
}
