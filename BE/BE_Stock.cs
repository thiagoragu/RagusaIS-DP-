using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Stock
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int Tipo { get; set; }

        public DateTime Fecha { get; set; }

        public BE_Stock() { }

        public override string ToString()
        {
            return ID + "-" + Nombre + "-" + Tipo + "-" + Cantidad;
        }
    }
}
