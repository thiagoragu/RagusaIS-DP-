using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Permiso
    {
        private DAL_Permisos DAL;

        public BLL_Permiso()
        {
            DAL = new DAL_Permisos();
        }

        public List<BE_Permiso> ObtenerPermisosArbol()
        {
            return DAL.ObtenerPermisosArbol();
        }

        public List<BE_Permiso> ObtenerPermisos()
        {
            return DAL.ObtenerPermisos();
        }

        public int AgregarPermisoCompuesto(string Nombre)
        {
            return DAL.AgregarPermisoCompuesto(Nombre);
        }

        public bool AgregarRelacionPH(int IDPadre, int IDHijo)
        {
            return DAL.AgregarRelacionPH(IDPadre, IDHijo);
        }

        public bool EliminarPermiso(int IDPadre)
        {
            DAL.EliminarPermisoC(IDPadre);
            DAL.EliminarRelacionesPermisoC(IDPadre);
            return false;
        }

        public bool EliminarRelacionesPermisoC(int IDPadre)
        {
            DAL.EliminarRelacionesPermisoC(IDPadre);
            return false;
        }

        public bool ModificarNombre(int IDPadre, string NombreNuevo)
        {
            return DAL.ModificarNombreC(IDPadre, NombreNuevo);
        }

        public bool ModificarRelacion(int IDPadre, int IDHijo)
        {
            DAL.AgregarRelacionPH(IDPadre, IDHijo);
            return false;
        }

        public List<BE_Permiso> ObtenerPermisoC()
        {
            return DAL.ObtenerPermisosC();
        }
    }
}
