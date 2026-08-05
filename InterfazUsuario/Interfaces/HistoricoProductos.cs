using BE;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazUsuario.Interfaces
{
    public partial class HistoricoProductos : Form, IObserverIdioma
    {
        BLL_Producto BLLProducto;
        BE_Producto BEProducto;
        BLL_Historico BLLHistorico;
        BLL_Idioma BLLIdioma;
        public HistoricoProductos()
        {
            BLLHistorico = new BLL_Historico();
            BLLProducto = new BLL_Producto();
            BEProducto = new BE_Producto();
            BLLIdioma = new BLL_Idioma();

            AdministradorIdioma.Instancia.Registrar(this);

            Validate();

            InitializeComponent();
        }

        private void HistoricoProductos_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        public void Cargar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BLLProducto.ListarProductos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BEProducto = (BE_Producto)dataGridView1.CurrentRow.DataBoundItem;
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = BEProducto.ListaHistorico;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BEProducto = (BE_Producto)dataGridView1.CurrentRow.DataBoundItem;
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = BEProducto.ListaHistorico;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRevertir_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Producto ProductoSeleccionado = (BE_Producto)dataGridView1.CurrentRow.DataBoundItem;
                BE_Historico Historico = (BE_Historico)dataGridView2.CurrentRow.DataBoundItem;

                if (ProductoSeleccionado != null || Historico != null)
                {
                    BE_Historico HistoricoRecuperado = new BE_Historico();
                    BE_Historico HistoricoOlvidado = new BE_Historico();

                    HistoricoOlvidado.NombreProducto = Historico.NombreProducto;
                    HistoricoOlvidado.Descripcion = Historico.Descripcion;
                    HistoricoOlvidado.PrecioProducto = Historico.PrecioProducto;
                    HistoricoOlvidado.IDProducto = ProductoSeleccionado.ID;

                    HistoricoRecuperado.NombreAnterior = Historico.NombreAnterior;
                    HistoricoRecuperado.DescripcionAnterior = Historico.DescripcionAnterior;
                    HistoricoRecuperado.PrecioAnterior = Historico.PrecioAnterior;
                    HistoricoRecuperado.FechaCambio = DateTime.Now;
                    HistoricoRecuperado.IDProducto = ProductoSeleccionado.ID;

                    BE_Producto ProductoNuevo = new BE_Producto();
                    ProductoNuevo.ID = ProductoSeleccionado.ID;
                    ProductoNuevo.Nombre = HistoricoRecuperado.NombreAnterior;
                    ProductoNuevo.Descripcion = HistoricoRecuperado.DescripcionAnterior;
                    ProductoNuevo.Precio = HistoricoRecuperado.PrecioAnterior;
                    string DV = BLLProducto.CalcularDVH(ProductoNuevo.ToString());
                    ProductoNuevo.DV = DV;

                    BLLProducto.ModificarProducto(ProductoNuevo);
                    //BLLHistorico.AgregarHistorico(HistoricoOlvidado, HistoricoRecuperado);
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar un producto y su histórico para continuar. No se realizan cambios.");
            }
        }
        public void ActualizarIdioma(int Idioma)
        {
            btnRevertir.Text = BLLIdioma.GetTraduccion(btnRevertir.Tag.ToString(), Idioma);
        }
    }
}
