using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_PermisoC : BE_Permiso
    {
        private readonly List<BE_Permiso> _permisos;

        public BE_PermisoC()
        {

        }

        public BE_PermisoC(string nombre, int ID, bool compuesto) : base(ID, nombre, compuesto)
        {
            _permisos = new List<BE_Permiso>();
        }

        public void Agregar(BE_Permiso permiso)
        {
            _permisos.Add(permiso);
        }

        public List<BE_Permiso> ObtenerPermisos()
        {
            return _permisos;
        }

        public override bool TienePermiso(BE_Permiso permiso)
        {
            if (this.ID == permiso.ID)
                return true;

            foreach (BE_Permiso p in _permisos)
            {
                if (p.TienePermiso(permiso))
                    return true;
            }

            return false;
        }

        public bool TienePermiso2(BE_Permiso permiso)
        {
            if (permiso == null)
                return false;

            // 1. Verificación directa (si el objeto actual o su ID coincide)
            if (this.ID == permiso.ID)
                return true;

            // 2. Búsqueda recursiva en la lista de permisos contenidos (_permisos)
            if (_permisos != null)
            {
                foreach (BE_Permiso p in _permisos)
                {
                    // Llama recursivamente a TienePermiso de cada elemento.
                    // Si 'p' es a su vez un BE_PermisoC, evaluará sus propios hijos de forma descendente.
                    if (p.TienePermiso(permiso))
                        return true;
                }
            }

            return false;
        }
    }
}
