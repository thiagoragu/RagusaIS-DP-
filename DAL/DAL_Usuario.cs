using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DAL_Usuario
    {
        Hashtable TablaH;
        DAL_BaseDatos DAL;

        public DAL_Usuario()
        {
            DAL = new DAL_BaseDatos();
        }

        public List<BE_Usuario> ObtenerUsuarios()
        {
            List<BE_Usuario> ListaUsuarios = new List<BE_Usuario>();
            string Query = "S_ListarUsuarios";
            DataTable TablaD = DAL.LeerBase(Query, null);

            if(TablaD.Rows.Count > 0)
            {
                foreach(DataRow Row in TablaD.Rows)
                {
                    BE_Usuario usuario = new BE_Usuario();
                    BE_PermisoC PermisoUsuario = new BE_PermisoC();
                    PermisoUsuario.Nombre = Row["Name"].ToString();
                    PermisoUsuario.ID = Convert.ToInt32(Row["IDPermiso"]);
                    usuario.ID = Convert.ToInt32(Row["ID"]);
                    usuario.Nombre = Row["NombreUsuario"].ToString();
                    usuario.Contrasena = Row["Contrasena"].ToString();
                    usuario.Permiso = PermisoUsuario;

                    DAL_BaseDatos DAL2 = new DAL_BaseDatos();
                    TablaH = new Hashtable();
                    TablaH.Add(@"CodUsuario", usuario.ID);
                    string Query2 = "S_LeerUsuario_Permiso";
                    DataTable TablaU = DAL2.LeerBase(Query2, TablaH);

                    List<BE_Permiso> ListaPermisos = new List<BE_Permiso>();

                    if(TablaU.Rows.Count > 0)
                    {
                        foreach(DataRow filas in TablaU.Rows)
                        {
                            if (filas["Compuesto"] is "False")
                            {
                                BE_PermisoS PermisoS = new BE_PermisoS();
                                PermisoS.ID = Convert.ToInt32(filas["ID"]);
                                PermisoS.Nombre = filas["Name"].ToString();
                                ListaPermisos.Add(PermisoS);
                            }
                            else
                            {
                                BE_PermisoC PermisoC = new BE_PermisoC();
                                PermisoC.ID = Convert.ToInt32(filas["ID"]);
                                PermisoC.Nombre = filas["Name"].ToString();
                                ListaPermisos.Add(PermisoC);
                            }
                            usuario.ListaPermisos = ListaPermisos;
                        }
                    }
                    ListaUsuarios.Add(usuario);
                }
            }
            return ListaUsuarios;
        }

        public bool Loguearse(string Nombre, string Contrasena)
        {
            string Consulta = "S_Loguearse";
            TablaH = new Hashtable();
            TablaH.Add("@Nombre", Nombre);

            TablaH.Add("@Contrasena", Contrasena);
            DataTable TablaProv = DAL.LeerBase(Consulta, TablaH);
            return TablaProv.Rows.Count > 0;
        }

        public bool Agregar(BE_Usuario usuario)
        {
            string Consulta = "S_AgregarUsuario";
            TablaH = new Hashtable();
            TablaH.Add("@Nombre", usuario.Nombre);
            TablaH.Add("@Contrasena", usuario.Contrasena);
            TablaH.Add("@IDPermiso", usuario.Permiso.ID);
            return DAL.EscribirBase(Consulta, TablaH);
        }

        public bool Eliminar(BE_Usuario usuario)
        {
            string Consulta = "S_EliminarUsuario";
            TablaH = new Hashtable();
            TablaH.Add("@ID", usuario.ID);
            return DAL.EscribirBase(Consulta, TablaH);
        }

        public bool Modificar(BE_Usuario usuario)
        {
            string Consulta = "S_ModificarUsuario";
            TablaH = new Hashtable();
            TablaH.Add("@ID", usuario.ID);
            TablaH.Add("@Nombre", usuario.Nombre);
            TablaH.Add("@Contrasena", usuario.Contrasena);
            TablaH.Add("@IDPermiso", usuario.Permiso.ID);
            return DAL.EscribirBase(Consulta,TablaH);
        }
    }
}
