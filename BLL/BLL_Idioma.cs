using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Idioma
    {
        public DAL_Idioma DAL_Idioma;

        public BLL_Idioma()
        {
            DAL_Idioma = new DAL_Idioma();
        }

        public List<BE_Idioma> GetIdiomas()
        {
            return DAL_Idioma.ObtenerIdiomas();
        }

        public string GetTraduccion(string key, int idIdioma)
        {
            return DAL_Idioma.ObtenerTraduccion(key, idIdioma);
        }

        public bool AgregarIdioma(string Idioma)
        {
            return DAL_Idioma.AgregarIdiomas(Idioma);
        }

        public List<BE_Traduccion> ObtenerTraducciones(int IDIdioma)
        {
            List<BE_Traduccion> ListaTraducciones = DAL_Idioma.ObtenerTraducciones(IDIdioma);

            Dictionary<int, string> Diccionario = DAL_Idioma.ObtenerTags();

            foreach(BE_Traduccion Traduccion in ListaTraducciones)
            {
                if (Diccionario[Traduccion.IDTag] != null)
                {
                    Diccionario.Remove(Traduccion.IDTag);
                }
            }
            foreach(int IDTag in Diccionario.Keys)
            {
                BE_Traduccion Traduccion = new BE_Traduccion();
                Traduccion.IDTag = IDTag;
                Traduccion.Tag = Diccionario[IDTag];
                Traduccion.IDIdioma = IDIdioma;
                ListaTraducciones.Add(Traduccion);
            }
            return ListaTraducciones;
        }
    }
}
