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
            if (GeneraCiclo(IDPadre, IDHijo))
                throw new InvalidOperationException(
                    "No se puede agregar ese permiso: generaria una referencia circular.");

            return DAL.AgregarRelacionPH(IDPadre, IDHijo);
        }

        public bool GeneraCiclo(int IDPadre, int IDHijo)
        {
            if (IDPadre == IDHijo)
                return true;

            List<BE_Permiso> arbol = ObtenerPermisosArbol();
            BE_Permiso nodoHijo = arbol.FirstOrDefault(p => p.ID == IDHijo);
            BE_Permiso permisoPadre = arbol.FirstOrDefault(p => p.ID == IDPadre);

            if (nodoHijo == null || permisoPadre == null)
                return false;
            return nodoHijo.TienePermiso(permisoPadre);
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
            if (GeneraCiclo(IDPadre, IDHijo))
                throw new InvalidOperationException(
                    "No se puede agregar ese permiso: generaria una referencia circular.");

            DAL.AgregarRelacionPH(IDPadre, IDHijo);
            return false;
        }

        public List<BE_Permiso> ObtenerPermisoC()
        {
            return DAL.ObtenerPermisosC();
        }
    }
}