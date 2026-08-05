using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Registro
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }

        public BE_Registro()
        {

        }

        public override string ToString()
        {
            return ID + "-" + Nombre + "-" + Fecha.ToString() + "-" + Tipo;
        }
    }
}
