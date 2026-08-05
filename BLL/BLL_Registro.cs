using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Registro
    {
        DAL_Registro DALRegistro;
        public BLL_Registro()
        {
            DALRegistro = new DAL_Registro();
        }
        public List<BE_Registro> ListarRegistros()
        {
            return DALRegistro.ListarRegistros();
        }

        public bool CrearRegistro(BE_Registro Registro)
        {
            return DALRegistro.CrearRegistro(Registro);
        }

        public List<BE_Registro> BuscarRegistro(DateTime Fecha)
        {
            return DALRegistro.BuscarRegistro(Fecha);
        }
    }
}
