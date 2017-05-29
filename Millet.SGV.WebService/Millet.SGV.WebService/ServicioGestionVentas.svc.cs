using System.Collections.Generic;
using Millet.SGV.Entities;

namespace Millet.SGV.WebService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioGestionVentas" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioGestionVentas.svc o ServicioGestionVentas.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioGestionVentas : IServicioGestionVentas
    {
        Business.Seguridad.Acceso _Acceso;
        Business.Seguridad.Personas _Personas;


        public Usuario LogIn(string User, string Pwd)
        {
            _Acceso = new Business.Seguridad.Acceso();

            return _Acceso.LogIn(User, Pwd);
        }

        public List<Persona> GetPersonas(Usuario u,Persona p)
        {
            _Personas = new Business.Seguridad.Personas();

            return _Personas.GetPersonas(u,p);
        }
    }
}
