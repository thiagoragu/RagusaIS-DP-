using System.Collections.Generic;
using Abstraccion;
using BE;

namespace Servicios
{
    public class AdministradorIdioma
    {
        //Singleton para no tener multiples instacias abiertas
        private static readonly AdministradorIdioma _instancia = new AdministradorIdioma();

        private readonly List<IObserverIdioma> _observadores;
        private BE_Idioma _idiomaActual;

        private AdministradorIdioma()
        {
            _observadores = new List<IObserverIdioma>();
            _idiomaActual = new BE_Idioma();
        }

        public static AdministradorIdioma Instancia
        {
            get { return _instancia; }
        }

        public void Registrar(IObserverIdioma observer)
        {
            if (!_observadores.Contains(observer))
                _observadores.Add(observer);
        }

        public void CambiarIdioma(BE_Idioma idioma)
        {
            _idiomaActual = idioma;

            foreach (var observer in _observadores)
            {
                observer.ActualizarIdioma(_idiomaActual.ID);
            }
        }
    }
}