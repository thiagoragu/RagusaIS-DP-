using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Servicios
{
    public class SesionSingleton
    {
        private static Sesion instance;
        private static Object _lock = new object();

        public static Sesion Instance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new Sesion();
                }
                return instance;
            }
        }
    }
}
