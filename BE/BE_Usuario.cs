using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace BE
{
    public class BE_Usuario : BE_Entidad, IUsuario
    {
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public BE_Permiso Permiso { get; set; }
        public List<BE_Permiso> ListaPermisos {  get; set; }
        public BE_Usuario() { }

        public override string ToString()
        {
            return Nombre + "-" + Contrasena;
        }
    }
}
