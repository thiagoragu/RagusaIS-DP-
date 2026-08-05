using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Microsoft.Win32;
using Servicios;

namespace BLL
{
    public class BLL_Usuario
    {
        DAL_Usuario DALUsuario;
        DAL_Permisos DALPermisos;

        public BLL_Usuario()
        {
            DALUsuario = new DAL_Usuario();
            DALPermisos = new DAL_Permisos();
        }

        public List<BE_Usuario> ObtenerUsuarios()
        {
            List<BE_Usuario> Usuarios = new List<BE_Usuario>();
            try
            {
                foreach(BE_Usuario usuario in DALUsuario.ObtenerUsuarios())
                {
                    Usuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Usuarios;
        }

        public bool Loguearse(string nombre, string contrasena)
        {
            if (SesionSingleton.Instance.EstaLogueado())
            {
                throw new Exception("Ya hay una sesión iniciada");
            }
            else
            {
                contrasena = Encriptado.Hashear(contrasena);
                if (DALUsuario.Loguearse(nombre, contrasena))
                {
                    BE_Usuario Usuario = new BE_Usuario();

                    Usuario.Nombre = nombre;
                    Usuario.Contrasena = contrasena;
                    Usuario.Permiso = DALPermisos.ObtenerPermisoUsuario(nombre);
                    
                    SesionSingleton.Instance.Loguearse(Usuario);
                    return true;
                }
                return false;
            }
        }
        public bool Desloguearse()
        {
            if (!SesionSingleton.Instance.EstaLogueado())
            {
                throw new Exception("No hay una sesion iniciada");
            }
            SesionSingleton.Instance.Desloguearse();
            return true;
        }

        public bool AgregarUsuario(BE_Usuario usuario)
        {
            usuario.Contrasena = Encriptado.Hashear(usuario.Contrasena);
            return DALUsuario.Agregar(usuario);
        }

        public bool EliminarUsuario(BE_Usuario usuario)
        {
            return DALUsuario.Eliminar(usuario);
        }

        public bool ModificarUsuario(BE_Usuario usuario)
        {
            usuario.Contrasena = Encriptado.Hashear(usuario.Contrasena);
            return DALUsuario.Modificar(usuario);
        }
    }

}

