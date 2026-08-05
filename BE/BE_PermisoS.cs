using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_PermisoS : BE_Permiso
    {
        public BE_PermisoS(string nombre, int ID, bool compuesto) : base(ID, nombre, compuesto)
        {
        }

        public override bool TienePermiso(BE_Permiso permiso)
        {
            return this.ID == permiso.ID;
        }
    }
}
