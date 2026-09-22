using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DAL
{
    public class DAL_Permisos
    {
        public DAL_BaseDatos DAL;

        public DAL_Permisos()
        {
            DAL = new DAL_BaseDatos();
        }

        public List<BE_Permiso> ObtenerPermisosArbol()
        {
            List<BE_Permiso> permisos = ObtenerPermisos();
            List<BE_PermisoRelacion> relaciones = ObtenerPermisosCompuestos();

            Dictionary<int, BE_Permiso> diccionario =
                permisos.ToDictionary(x => x.ID);

            foreach (BE_PermisoRelacion relacion in relaciones)
            {
                if (diccionario.ContainsKey(relacion.IdPadre) &&
                    diccionario.ContainsKey(relacion.IdHijo))
                {
                    BE_PermisoC padre = diccionario[relacion.IdPadre] as BE_PermisoC;

                    if (padre != null)
                    {
                        padre.Agregar(diccionario[relacion.IdHijo]);
                    }
                }
            }

            return permisos;
        }

        public List<BE_Permiso> ObtenerPermisos()
        {
            List<BE_Permiso> permisos = new List<BE_Permiso>();

            DataTable tabla = DAL.LeerBase("S_ObtenerPermisos", null);

            foreach (DataRow row in tabla.Rows)
            {
                bool compuesto = Convert.ToBoolean(row["Compuesto"]);
                int id = Convert.ToInt32(row["ID"]);
                string nombre = row["Name"].ToString();

                if (compuesto)
                    permisos.Add(new BE_PermisoC(nombre, id, true));
                else
                    permisos.Add(new BE_PermisoS(nombre, id, false));
            }

            return permisos;
        }

        private List<BE_PermisoRelacion> ObtenerPermisosCompuestos()
        {
            List<BE_PermisoRelacion> lista = new List<BE_PermisoRelacion>();

            DataTable tabla = DAL.LeerBase("S_ObtenerPermisosCompuestos", null);

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new BE_PermisoRelacion(
                    Convert.ToInt32(row["IDPadre"]),
                    Convert.ToInt32(row["IDHijo"])));
            }

            return lista;
        }

        public BE_Permiso ObtenerPermisoUsuario(string usuario, string contrasena)
        {
            Hashtable parametros = new Hashtable();
            parametros.Add("@Nombre", usuario);
            parametros.Add("Contrasena", contrasena);

            DataTable tabla = DAL.LeerBase("S_ObtenerPermisoPorNombreUsuario", parametros);

            if (tabla.Rows.Count == 0)
                return null;

            int idPermiso = Convert.ToInt32(tabla.Rows[0]["ID"]);

            List<BE_Permiso> permisos = ObtenerPermisosArbol();

            foreach (BE_Permiso permiso in permisos)
            {
                if (permiso.ID == idPermiso)
                    return permiso;
            }

            return null;
        }

        public List<BE_Permiso> ObtenerPermisoUsuario2(string usuario, string contrasena)
        {
            Hashtable parametros = new Hashtable();
            parametros.Add("@Nombre", usuario);

            DataTable tabla = DAL.LeerBase("S_ObtenerPermisoPorNombreUsuario", parametros);

            List<BE_Permiso> permisosUsuario = new List<BE_Permiso>();

            if (tabla.Rows.Count == 0)
            {
              return permisosUsuario;
            }
            else
            {
                List<BE_Permiso> permisos = ObtenerPermisosArbol();

                foreach (DataRow fila in tabla.Rows)
                {
                    int idPermiso = Convert.ToInt32(fila["ID"]);

                    foreach (BE_Permiso permiso in permisos)
                    {
                        if (permiso.ID == idPermiso)
                        {
                            permisosUsuario.Add(permiso);
                            break;
                        }
                    }
                }
                return permisosUsuario;
            }   
        } 

        public int AgregarPermisoCompuesto(string Nombre)
        {
            string Consulta = "S_AgregarPermisoCompuesto";
            Hashtable TablaH = new Hashtable();
            TablaH.Add("@Nombre", Nombre);
            return DAL.EscribirBaseID(Consulta,TablaH);
        }

        public bool AgregarRelacionPH(int IDPadre, int IDHijo)
        {
            string Consulta = "S_AgregarRelacionPH";
            Hashtable TablaH = new Hashtable();
            TablaH.Add("@IDPadre", IDPadre);
            TablaH.Add("@IDHijo", IDHijo);
            return DAL.EscribirBase(Consulta,TablaH);
        }

        public bool EliminarPermisoC(int IDPadre)
        {
            string Consulta = "S_BorrarPermisoC";
            Hashtable TablaH = new Hashtable();
            TablaH.Add("@ID", IDPadre);
            return DAL.EscribirBase(Consulta, TablaH);
        }

        public bool EliminarRelacionesPermisoC(int IDPadre)
        {
            string Consulta = "S_BorrarRelacionesPermisoC";
            Hashtable TablaH = new Hashtable();
            TablaH.Add("@IDPadre", IDPadre);
            return DAL.EscribirBase(Consulta, TablaH);
        }

        public bool ModificarNombreC(int IDPadre, string NombreNuevo)
        {
            string Consulta = "S_ModificarNombrePermisoC";
            Hashtable TablaH = new Hashtable();
            TablaH.Add("@IDPadre", IDPadre);
            TablaH.Add("@NombreNuevo", NombreNuevo);
            return DAL.EscribirBase(Consulta, TablaH);
        }

        public List<BE_Permiso> ObtenerPermisosC()
        {
            List<BE_Permiso> ListaPermisosCompuestos = new List<BE_Permiso>();
            string Consulta = "S_ObtenerPermisosC";
            DataTable Tabla = DAL.LeerBase(Consulta, null);

            if(Tabla.Rows.Count > 0)
            {
                foreach (DataRow Row in Tabla.Rows)
                {
                    BE_PermisoC Permiso = new BE_PermisoC();
                    Permiso.ID = Convert.ToInt32(Row["ID"]);
                    Permiso.Nombre = Row["Name"].ToString();
                    ListaPermisosCompuestos.Add(Permiso);
                }
            }
            return ListaPermisosCompuestos;
        }
    }
}
