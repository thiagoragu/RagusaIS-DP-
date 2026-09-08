using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Traduccion
    {
        DAL_BaseDatos DALBaseDatos;

        public DAL_Traduccion()
        {
            DALBaseDatos = new DAL_BaseDatos();
        }
        
        public bool CrearTraduccion(int IDTag, int IDIdioma)
        {
            string Consulta = "S_CrearTraduccion";
            Hashtable TablaH1 = new Hashtable();
            TablaH1["IDTag"] = IDTag;
            TablaH1["IDIdioma"] = IDIdioma;

            return DALBaseDatos.EscribirBase(Consulta, TablaH1);
        }

        public bool ModificarTraduccion(int IDIdioma, int IDTag, string Traduccion)
        {
            string Consulta = "S_ModificarTraduccion";
            Hashtable TablaH = new Hashtable();
            TablaH.Add("@IDIdioma", IDIdioma);
            TablaH.Add("@IDTag", IDTag);
            TablaH.Add("@Traduccion", Traduccion);

            return DALBaseDatos.EscribirBase(Consulta, TablaH);
        }
    }
}
