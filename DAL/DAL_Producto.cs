using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using BE;
using Servicios;

namespace DAL
{
    public class DAL_Producto
    {
        DAL_BaseDatos DAL = new DAL_BaseDatos();
        Hashtable TablaH;

        public List<BE_Producto> ObtenerProductos()
        {
            List<BE_Producto> ListaProducto = new List<BE_Producto>();
            string Consulta = "S_ObtenerProducto";
            DataTable Tabla = DAL.LeerBase(Consulta, null);

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow Row in Tabla.Rows)
                {
                    BE_Producto Producto = new BE_Producto();
                    Producto.ID = Convert.ToInt32(Row["ID"]);
                    Producto.Nombre = Row["Nombre"].ToString();
                    Producto.Descripcion = Row["Descripcion"].ToString();
                    Producto.Precio = Convert.ToInt32(Row["Precio"]);
                    Producto.DV = Row["DV"].ToString();

                    if (CalcularCoherencia(Producto.ToString(), Producto.DV))
                    {
                        ListaProducto.Add(Producto);

                        string Consulta2 = "S_ObtenerHistoricoProducto";
                        TablaH = new Hashtable();
                        TablaH.Add("@IDProducto", Producto.ID);
                        DataTable Tabla2 = DAL.LeerBase(Consulta2, TablaH);

                        List<BE_Historico> ListaHistoricos = new List<BE_Historico>();
                        if (Tabla2.Rows.Count > 0)
                        {
                            foreach (DataRow Row2 in Tabla2.Rows)
                            {
                                BE_Historico Historico = new BE_Historico();
                                Historico.NombreProducto = Row2["NombreProducto"].ToString();
                                Historico.NombreAnterior = Row2["NombreAnterior"].ToString();
                                Historico.Descripcion = Row2["Descripcion"].ToString();
                                Historico.DescripcionAnterior = Row2["DescripcionAnterior"].ToString();
                                Historico.PrecioProducto = Convert.ToInt32(Row2["PrecioProducto"]);
                                Historico.PrecioAnterior = Convert.ToInt32(Row2["PrecioAnterior"]);
                                Historico.FechaCambio = Convert.ToDateTime(Row2["FechaCambio"].ToString());
                                Historico.IDProducto = Convert.ToInt32(Row2["IDProducto"]);
                                ListaHistoricos.Add(Historico);

                                Producto.ListaHistorico = ListaHistoricos;
                            }
                        }
                    }
                }
            }
            return ListaProducto;
        }

        public bool Agregar(BE_Producto Producto)
        {
            string Consulta = "S_AgregarProducto";
            TablaH = new Hashtable();
            TablaH.Add("@Nombre", Producto.Nombre);
            TablaH.Add("@Descripcion", Producto.Descripcion);
            TablaH.Add("@Precio", Producto.Precio);
            TablaH.Add("@DV", Producto.DV);
            return DAL.EscribirBase(Consulta, TablaH);
        }

        public bool Eliminar(BE_Producto Producto)
        {
            string Consulta = "S_EliminarProducto";
            TablaH = new Hashtable();
            TablaH.Add("@ID", Producto.ID);
            return DAL.EscribirBase(Consulta,TablaH);
        }

        public bool Modificar(BE_Producto Producto)
        {
            string Consulta = "S_ModificarProducto";
            TablaH = new Hashtable();
            TablaH.Add("@ID", Producto.ID);
            TablaH.Add("@Nombre", Producto.Nombre);
            TablaH.Add("@Descripcion", Producto.Descripcion);
            TablaH.Add("@Precio",Producto.Precio);
            TablaH.Add("@DV", Producto.DV);
            return DAL.EscribirBase(Consulta, TablaH);
        }

        public bool CalcularCoherencia(string Texto1, string Texto2)
        {
            string DV = Encriptado.Hashear(Texto1);

            if(DV == Texto2)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}
