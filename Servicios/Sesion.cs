using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Servicios
{
    public class Sesion
    {
        private BE_Usuario usuario { get; set; }
        public BE_Usuario Usuario
        {
            get
            {
                return usuario;
            }
        }

        public void Loguearse(BE_Usuario user)
        {
            usuario = user;
        }

        public void Desloguearse()
        {
            usuario = null;
        }

        public bool EstaLogueado()
        {
            return usuario != null;
        }
    }
}

