using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millet.SGV.Business.Seguridad
{
    public class Usuario
    {
        public static List<Entities.Usuario> GetUsuarios(Entities.Usuario u)
        {
            return Data.Seguridad.Usuario.GetUsuarios(u);
        }
    }
}
