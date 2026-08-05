using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Historico
    {
        public int IDProducto { get; set; }
        public string NombreProducto { get; set; }
        public string NombreAnterior { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAnterior { get; set; }
        public int PrecioProducto { get; set; }
        public int PrecioAnterior { get; set; }
        public DateTime FechaCambio { get; set; }
        public int ID { get; set; }

        public BE_Historico()
        {

        }
        public override string ToString()
        {
            return IDProducto + "-" + NombreProducto + "-" + NombreAnterior + "-" + Descripcion + "-" + DescripcionAnterior + "-" + PrecioProducto + "-" + PrecioAnterior + "-" + FechaCambio.ToString();
        }
    }
}
