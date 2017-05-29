using System.Collections.Generic;

namespace Millet.SGV.Business.Seguridad
{
    public class Personas
    {
        Data.Seguridad.Personas _Persona;

        public List<Entities.Persona> GetPersonas(Entities.Usuario u,Entities.Persona p)
        {
            Entities.Error _e;

            Acceso access = new Acceso();

            _e = access.ValidarSesion(u);

            if(_e.IdError == 0)
            {
                _Persona = new Data.Seguridad.Personas();

                return _Persona.GetPersonas(p);
            }

            return new List<Entities.Persona>() { new Entities.Persona() { error = _e } };
        }
    }
}
