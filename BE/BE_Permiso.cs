using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BE_Permiso
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public bool Compuesto { get; set; }

        public BE_Permiso() { }
        public BE_Permiso(int ID, string nombre, bool Compuesto)
        {
            this.ID = ID;
            this.Nombre = nombre;
            this.Compuesto = Compuesto;
        }

        public abstract bool TienePermiso(BE_Permiso permiso);

        public override string ToString()
        {
            return this.ID + "-" + this.Nombre;
        }
    }
}
