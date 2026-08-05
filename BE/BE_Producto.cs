using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string DV {  get; set; }
        public List<BE_Historico> ListaHistorico { get; set; }
        public BE_Producto()
        {

        }

        public override string ToString()
        {
            return Nombre + "-" + Descripcion;
        }
    }
}
