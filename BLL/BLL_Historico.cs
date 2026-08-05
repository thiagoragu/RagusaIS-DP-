using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLL_Historico
    {
        DAL_Historico DAL_Historico = new DAL_Historico();
        public List<BE_Historico> ObtenerHistoricos()
        {
            return DAL_Historico.ListarHistorico();
        }

        public bool AgregarHistorico(BE_Historico HistoricoNuevo, BE_Historico HistoricoViejo)
        {
            return DAL_Historico.AgregarHistorico(HistoricoNuevo, HistoricoViejo); ;
        }
    }
}
