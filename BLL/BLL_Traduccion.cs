using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Traduccion
    {
        public DAL_Traduccion DALTraduccion = new DAL_Traduccion();
        public bool ModificarTraduccion (int IDIdioma, int IDTag, string Traduccion)
        {
            return DALTraduccion.ModificarTraduccion(IDIdioma, IDTag, Traduccion);
        }
    }
}
