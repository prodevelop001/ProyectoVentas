using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millet.SGV.Business.Seguridad
{
    public class Acceso
    {
        public Entities.Usuario LogIn(string User, string pwd)
        {
            Entities.Usuario _usuario = new Entities.Usuario();
            _usuario._Error = new Entities.Error() { IdError = -1 };
            Utils.Cadena _Cadena = new Utils.Cadena();
            string Token = string.Empty;

            try
            {

                List<Entities.Usuario> userList = Data.Seguridad.Usuario.GetUsuarios(new Entities.Usuario()
                {
                    Alias = User,
                    Clave = pwd,
                    Activo = true
                });

                if (userList.Count > 0)
                {
                    Token = _Cadena.RandomString(32);

                    DateTime fchSession = userList.First().FchSession.Value.AddMinutes(15.0);
                    DateTime fchNow = DateTime.Now;

                    int res = DateTime.Compare(fchNow, fchSession);

                    switch (res)
                    {
                        case -1:
                        //t1 es anterior a t2
                        case 0:
                            //t1 es igual a t2
                            _usuario._Error.IdError = 1;
                            _usuario._Error.Descripcion = "Hay una sesión activa por favor esperar 15 minutos.";
                            break;
                        case 1:
                            //t1 es mayor a t2
                            Entities.Usuario _u = userList.First();
                            _u.FchSession = DateTime.Now;
                            _u.TokenSession = Token;

                            _u._Error = new Entities.Error();

                            _u._Error.IdError = 0;
                            _u._Error.Descripcion = Token;

                            if (!Data.Seguridad.Usuario.Actualizar(_u))
                            {
                                _u._Error.IdError = 1;
                                _u._Error.Descripcion = "Error en el proceso: Actualizar sesion = false";
                            }

                            return _u;
                        default:
                            break;
                    }
                }
                else
                {
                    _usuario._Error.IdError = 1;
                    _usuario._Error.Descripcion = "Usuario y/o contraseña no son correctos.";
                }
            }
            catch (Exception err)
            {
                _usuario._Error.IdError = err.GetHashCode();
                _usuario._Error.Descripcion = err.Message;
            }

            return _usuario;
        }

        public Entities.Error ValidarSesion(Entities.Usuario u)
        {
            Entities.Error error = new Entities.Error() { IdError = -1 };

            try
            {
                List<Entities.Usuario> userList = Data.Seguridad.Usuario.GetUsuarios(new Entities.Usuario()
                {
                    PkUsuario = u.PkUsuario,
                    TokenSession = u.TokenSession
                });

                if (userList.Count > 0)
                {
                    Entities.Usuario _u = userList.First();

                    DateTime fchSession = _u.FchSession.Value.AddMinutes(15.0);
                    DateTime fchNow = DateTime.Now;

                    int res = DateTime.Compare(fchNow, fchSession);

                    switch (res)
                    {
                        case -1:
                        case 0:

                            _u.FchSession = DateTime.Now;

                            error.IdError = 0;
                            error.Descripcion = "Sesion correcta";

                            if (!Data.Seguridad.Usuario.Actualizar(_u))
                            {
                                error.IdError = 1;
                                error.Descripcion = "Error en el proceso: Actualizar sesion = false";
                            }

                            break;
                        case 1:
                            error.IdError = 1;
                            error.Descripcion = "Sesion expirada";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    error.IdError = 1;
                    error.Descripcion = "No hay una sesion asociada.";
                }

            }
            catch (Exception err)
            {
                error.IdError = err.GetHashCode();
                error.Descripcion = err.Message;
            }

            return error;
        }
    }
}
