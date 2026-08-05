using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DAL_Historico
    {
        DAL_BaseDatos DAL = new DAL_BaseDatos();
        Hashtable TablaH;

        public DAL_Historico()
        {

        }

        public List<BE_Historico> ListarHistorico()
        {
            List<BE_Historico> ListaHistoricos = new List<BE_Historico>();
            string Consulta = "S_ListarHistorico";
            DataTable Tabla = DAL.LeerBase(Consulta, null);

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow Row in Tabla.Rows)
                {
                    BE_Historico Historico = new BE_Historico();
                    Historico.ID = Convert.ToInt32(Row["ID"]);
                    Historico.IDProducto = Convert.ToInt32(Row["IDProducto"]);
                    Historico.NombreProducto = Row["NombreProducto"].ToString();
                    Historico.NombreAnterior = Row["NombreAnterior"].ToString();
                    Historico.Descripcion = Row["Descripcion"].ToString();
                    Historico.DescripcionAnterior = Row["DescripcionAnterior"].ToString();
                    Historico.PrecioProducto = Convert.ToInt32(Row["PrecioProducto"]);
                    Historico.PrecioAnterior = Convert.ToInt32(Row["PrecioAnterior"]);
                    Historico.FechaCambio = Convert.ToDateTime(Row["FechaCambio"]);

                    ListaHistoricos.Add(Historico);
                }
            }
            return ListaHistoricos;
        }

        public bool AgregarHistorico(BE_Historico HistoricoNuevo, BE_Historico HistoricoViejo)
        {
            string Consulta = "S_AgregarHistorico";
            TablaH = new Hashtable();
            TablaH.Add("@IDProducto", HistoricoViejo.IDProducto);
            TablaH.Add("@NombreProducto", HistoricoNuevo.NombreProducto);
            TablaH.Add("@NombreAnterior", HistoricoViejo.NombreAnterior);
            TablaH.Add("@Descripcion", HistoricoNuevo.Descripcion);
            TablaH.Add("DescripcionAnterior", HistoricoViejo.DescripcionAnterior);
            TablaH.Add("@PrecioProducto",HistoricoNuevo.PrecioProducto);
            TablaH.Add("@PrecioAnterior", HistoricoViejo.PrecioAnterior);
            TablaH.Add("@FechaCambio", DateTime.Now);
            return DAL.EscribirBase(Consulta, TablaH);
        }

    }
}
