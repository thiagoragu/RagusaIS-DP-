using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Idioma : BE_Entidad
    {
        public int ID { get; set; }
        public string Idioma { get; set; }
        public override string ToString()
        {
            return Idioma;
        }
    }
}
