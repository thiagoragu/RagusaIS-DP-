using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Servicios;

namespace BLL
{
    public class BLL_Producto
    {
        DAL_Producto DAL_Producto;

        public BLL_Producto()
        {
            DAL_Producto = new DAL_Producto();
        }
        public List<BE_Producto> ListarProductos()
        {
            return DAL_Producto.ObtenerProductos();
        } 

        public bool AgregarProducto(BE_Producto Producto)
        {
            return DAL_Producto.Agregar(Producto);
        }

        public bool EliminarProducto(BE_Producto Producto)
        {
            return DAL_Producto.Eliminar(Producto);
        }

        public bool ModificarProducto(BE_Producto Producto)
        {
            return DAL_Producto.Modificar(Producto);
        }

        public string CalcularDVH(string Texto)
        {
            string DV = Encriptado.Hashear(Texto);
            return DV;
        }
    }
}
