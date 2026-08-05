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
using Servicios;

namespace InterfazUsuario.Interfaces
{
    public partial class Productos : Form, IObserverIdioma
    {
        BLL_Producto BLLProducto;
        BE_Producto BEProducto;
        BLL_Historico BLLHistorico;
        BLL_Idioma BLLIdioma;
        public Productos()
        {
            BLLProducto = new BLL_Producto();
            BEProducto = new BE_Producto();
            BLLHistorico = new BLL_Historico();
            BLLIdioma = new BLL_Idioma();

            AdministradorIdioma.Instancia.Registrar(this);

            Validate();

            InitializeComponent();
        }

        public void ActualizarIdioma(int Idioma)
        {
            this.lblTexto.Text = BLLIdioma.GetTraduccion(this.lblTexto.Tag.ToString(), Idioma);
            this.lblNombre.Text = BLLIdioma.GetTraduccion(this.lblNombre.Tag.ToString(), Idioma);
            this.lblDescripcion.Text = BLLIdioma.GetTraduccion(this.lblDescripcion.Tag.ToString(), Idioma);
            this.lblPrecio.Text = BLLIdioma.GetTraduccion(this.lblPrecio.Tag.ToString(), Idioma);
            this.btnAgregar.Text = BLLIdioma.GetTraduccion(this.btnAgregar.Tag.ToString(), Idioma);
            this.btnEliminar.Text = BLLIdioma.GetTraduccion(this.btnEliminar.Tag.ToString(), Idioma);
            this.btnModificar.Text = BLLIdioma.GetTraduccion(this.btnModificar.Tag.ToString(), Idioma);
        }

        public void Cargar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BLLProducto.ListarProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Producto Producto = new BE_Producto();
                Producto.Nombre = textBox1.Text;
                Producto.Descripcion = textBox2.Text;
                Producto.Precio = Convert.ToInt16(textBox3.Text);

                string dv = BLLProducto.CalcularDVH(Producto.ToString());
                Producto.DV = dv;

                BLLProducto.AgregarProducto(Producto);
                Cargar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Producto Producto = (BE_Producto)dataGridView1.CurrentRow.DataBoundItem;
                BLLProducto.EliminarProducto(Producto);
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Producto Producto = (BE_Producto)dataGridView1.CurrentRow.DataBoundItem;

                BE_Historico HistoricoViejo = new BE_Historico();
                BE_Historico HistoricoNuevo = new BE_Historico();

                HistoricoViejo.IDProducto = Producto.ID;
                HistoricoViejo.NombreAnterior = Producto.Nombre;
                HistoricoViejo.DescripcionAnterior = Producto.Descripcion;
                HistoricoViejo.PrecioAnterior = Producto.Precio;

                BEProducto.Nombre = textBox1.Text;
                BEProducto.Descripcion = textBox2.Text;
                BEProducto.Precio = Convert.ToInt16(textBox3.Text);
                BEProducto.ID = Producto.ID;
                string ProductoDVNuevo = BEProducto.ToString();
                BEProducto.DV = BLLProducto.CalcularDVH(ProductoDVNuevo);

                HistoricoNuevo.NombreProducto = BEProducto.Nombre;
                HistoricoNuevo.Descripcion = BEProducto.Descripcion;
                HistoricoNuevo.FechaCambio = DateTime.Now;
                HistoricoNuevo.PrecioProducto = BEProducto.Precio;

                BLLProducto.ModificarProducto(BEProducto);
                BLLHistorico.AgregarHistorico(HistoricoNuevo, HistoricoViejo);
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
