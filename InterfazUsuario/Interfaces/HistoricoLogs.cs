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
    public partial class HistoricoLogs : Form, IObserverIdioma
    {
        BLL_Registro BLLRegistro;
        BLL_Idioma BLLIdioma;
        public HistoricoLogs()
        {
            BLLRegistro = new BLL_Registro();
            BLLIdioma = new BLL_Idioma();

            AdministradorIdioma.Instancia.Registrar(this);

            Validate();

            InitializeComponent();
        }

        private void HistoricoLogs_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        public void Actualizar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BLLRegistro.ListarRegistros();
        }

        public void ActualizarBuscar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BLLRegistro.BuscarRegistro(dateTimePicker1.Value.Date);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarBuscar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ActualizarIdioma(int Idioma)
        {
            btnActualizar.Text = BLLIdioma.GetTraduccion(btnActualizar.Tag.ToString(), Idioma);
            btnBuscar.Text = BLLIdioma.GetTraduccion(btnBuscar.Tag.ToString(), Idioma);
        }
    }
}
