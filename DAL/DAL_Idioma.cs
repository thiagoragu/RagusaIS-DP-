using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Idioma
    {
        DAL_BaseDatos DAL = new DAL_BaseDatos();

        public List<BE_Idioma> ObtenerIdiomas()
        {
            List<BE_Idioma> ListaIdiomas = new List<BE_Idioma>();
            string Consulta = "S_ObtenerIdiomas";
            var Tabla = DAL.LeerBase(Consulta, null);

            if (Tabla.Rows.Count > 0)
            {
                foreach (System.Data.DataRow Row in Tabla.Rows)
                {
                    ListaIdiomas.Add(new BE_Idioma
                    {
                        ID = Convert.ToInt32(Row["ID"]),
                        Idioma = Row["Idioma"]?.ToString()
                    });
                }
            }
            return ListaIdiomas;
        }

        public bool AgregarIdiomas(string Idioma)
        {
            string Consulta = "S_AgregarIdiomas";
            Hashtable TablaH = new Hashtable();
            TablaH.Add("@NombreIdioma", Idioma);
            return DAL.EscribirBase(Consulta, TablaH);
        }

        public string ObtenerTraduccion(string key, int idIdioma)
        {
            string Consulta = "S_ObtenerTraduccion";
            var TablaH = new System.Collections.Hashtable();
            TablaH.Add("@Key", key);
            TablaH.Add("@IdIdioma", idIdioma);
            var Tabla = DAL.LeerBase(Consulta, TablaH);

            if (Tabla.Rows.Count > 0)
            {
                return Tabla.Rows[0]["Traduccion"]?.ToString();
            }
            return null;
        }

        public List<BE_Traduccion> ObtenerTraducciones(int ID)
        {
            List<BE_Traduccion> ListaTraducciones = new List<BE_Traduccion>();
            string Consulta = "S_ObtenerTraducciones";
            Hashtable TablaH = new Hashtable();
            TablaH.Add("@IDIdioma", ID);

            DataTable Tabla = DAL.LeerBase(Consulta,TablaH);

            if(Tabla.Rows.Count > 0)
            {
                foreach(DataRow Row in Tabla.Rows)
                {
                    BE_Traduccion Traduccion =  new BE_Traduccion();
                    Traduccion.IDIdioma = Convert.ToInt32(Row["IDIdioma"]);
                    Traduccion.IDTag = Convert.ToInt32(Row["IDTag"]);
                    Traduccion.Tag = Row["Tag"].ToString();
                    Traduccion.Traduccion = Row["Traduccion"].ToString();
                    ListaTraducciones.Add(Traduccion);
                }
            }
            return ListaTraducciones;
        }

        public Dictionary<int, string> ObtenerTags()
        {
            Dictionary <int, string> Traducciones = new Dictionary<int, string>();
            string Consulta = "S_ObtenerTags";

            DataTable Tabla = DAL.LeerBase(Consulta, null);

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow row in Tabla.Rows)
                {
                    string TAG = row["Tag"].ToString();
                    int ID = Convert.ToInt32(row["ID"]);
                    Traducciones.Add(ID, TAG);
                }
            }
            return Traducciones;
        }
    }
}
