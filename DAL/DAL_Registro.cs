
using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Registro
    {
        DAL_BaseDatos DAL;
        Hashtable TablaH;
        public DAL_Registro() 
        {
            DAL = new DAL_BaseDatos();
        }

        public List<BE_Registro> ListarRegistros()
        {
            List<BE_Registro> ListaRegistros = new List<BE_Registro>();
            string Consulta = "S_ListarRegistros";
            DataTable Tabla = DAL.LeerBase(Consulta, null);

            if(Tabla.Rows.Count > 0)
            {
                foreach(DataRow Row in Tabla.Rows)
                {
                    BE_Registro Registro = new BE_Registro();
                    Registro.ID = Convert.ToInt32(Row["ID"]);
                    Registro.Nombre = Row["Nombre"].ToString();
                    Registro.Fecha = Convert.ToDateTime(Row["Fecha"]);
                    Registro.Tipo = Row["Tipo"].ToString();

                    ListaRegistros.Add(Registro);
                }
            }
            return ListaRegistros;
        }
        public bool CrearRegistro(BE_Registro Registro)
        {
            string Consulta = "S_CrearRegistro";

            TablaH = new Hashtable();
            TablaH.Add("@Nombre", Registro.Nombre);
            TablaH.Add("@Fecha", Registro.Fecha);
            TablaH.Add("@Tipo", Registro.Tipo);

            return DAL.EscribirBase(Consulta, TablaH);
        }

        public List<BE_Registro> BuscarRegistro(DateTime Fecha)
        {
            List<BE_Registro> ListaRegistrosFecha = new List<BE_Registro>();
            string Consulta = "S_ListarRegistros";
            DataTable Tabla = DAL.LeerBase(Consulta, null);

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow Row in Tabla.Rows)
                {
                    BE_Registro Registro = new BE_Registro();
                    Registro.ID = Convert.ToInt32(Row["ID"]);
                    Registro.Nombre = Row["Nombre"].ToString();
                    Registro.Fecha = Convert.ToDateTime(Row["Fecha"]);
                    Registro.Tipo = Row["Tipo"].ToString();

                    if(Registro.Fecha.Date == Fecha)
                    {
                        ListaRegistrosFecha.Add(Registro);
                    }
                }
            }
            return ListaRegistrosFecha;
        }
    }
}
