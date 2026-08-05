using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_PermisoRelacion
    {
        public int IdPadre { get; set; }
        public int IdHijo { get; set; }

        public BE_PermisoRelacion(int idPadre, int idHijo)
        {
            IdPadre = idPadre;
            IdHijo = idHijo;
        }
    }
}
