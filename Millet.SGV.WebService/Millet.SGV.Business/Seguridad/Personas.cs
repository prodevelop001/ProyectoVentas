using System.Collections.Generic;

namespace Millet.SGV.Business.Seguridad
{
    public class Personas
    {
        Data.Seguridad.Personas _Persona;

        public List<Entities.Personas> GetPersonas(Entities.Personas p)
        {
            _Persona = new Data.Seguridad.Personas();

            return _Persona.GetPersonas(p);
        }
    }
}
