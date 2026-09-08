using BE;
using DAL;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Stock
    {
        DAL_Stock DALS = new DAL_Stock();

        public List<BE_Stock> ListarStock()
        {
            return DALS.ListarStock(); 
        }
        public bool AgregarStock(BE_Stock StockAgregado)
        {
            return DALS.AgregarStock(StockAgregado);
        }

        public bool EliminarStock(BE_Stock StockEliminado)
        {
            return DALS.EliminarStock(StockEliminado);
        }

        public bool ModificarStock(BE_Stock StockNuevo, BE_Stock StockViejo)
        {
            return DALS.ModificarStock(StockNuevo, StockViejo);
        }

        public bool VerificarStock(BE_Stock StockVerificado)
        {
            return DALS.ControlarVencimiento(StockVerificado);
        }
    }
}
