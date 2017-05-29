using System.Collections.Generic;
using System.ServiceModel;

namespace Millet.SGV.WebService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioGestionVentas" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioGestionVentas
    {
        [OperationContract]
        Entities.Usuario LogIn(string User, string Pwd);

        [OperationContract]
        List<Entities.Persona> GetPersonas(Entities.Usuario u,Entities.Persona p);
    }
}
