using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Stock
    {
        DAL_BaseDatos DAL = new DAL_BaseDatos();
        Hashtable TablaH;

        public List<BE_Stock> ListarStock()
        {
            List<BE_Stock> ListaStocks = new List<BE_Stock>();
            string Consulta = "S_ListarStock";
            DataTable Tabla = DAL.LeerBase(Consulta, null);

            if(Tabla.Rows.Count > 0 )
            {
                foreach(DataRow row in Tabla.Rows)
                {
                    BE_Stock Stock = new BE_Stock();
                    Stock.ID = Convert.ToInt32(row["ID"]);
                    Stock.Nombre = row["Nombre"].ToString();
                    Stock.Cantidad = Convert.ToInt32(row["Cantidad"]);
                    Stock.Tipo = Convert.ToInt32(row["Tipo"]);
                    Stock.Fecha = Convert.ToDateTime(row["Fecha"]);
                    ListaStocks.Add(Stock);
                }
            }
            return ListaStocks;
        }

        public bool AgregarStock(BE_Stock StockAgregar)
        {
            string Consulta = "S_AgregarStock";
            TablaH = new Hashtable();
            TablaH.Add("@Nombre", StockAgregar.Nombre);
            TablaH.Add("@Tipo", StockAgregar.Tipo);
            TablaH.Add("@Cantidad", StockAgregar.Cantidad);
            TablaH.Add("@Fecha", StockAgregar.Fecha);
            return DAL.EscribirBase(Consulta, TablaH);
        }

        public bool EliminarStock(BE_Stock StockEliminar)
        {
            string Consulta = "S_EliminarStock";
            TablaH = new Hashtable();
            TablaH.Add("@ID", StockEliminar.ID);
            return DAL.EscribirBase(Consulta, TablaH);
        }

        public bool ModificarStock(BE_Stock StockNuevo, BE_Stock StockViejo)
        {
            string Consulta = "S_ModificarStock";
            TablaH = new Hashtable();
            TablaH.Add("@Nombre", StockNuevo.Nombre);
            TablaH.Add("@Tipo", StockNuevo.Tipo);
            TablaH.Add("@Cantidad", StockNuevo.Cantidad);
            TablaH.Add("@Fecha", StockNuevo.Fecha);
            TablaH.Add("@ID", StockViejo.ID);
            return DAL.EscribirBase(Consulta, TablaH);
        }

        public bool ControlarVencimiento(BE_Stock Stock)
        {
            return false;
        }
    }
}
