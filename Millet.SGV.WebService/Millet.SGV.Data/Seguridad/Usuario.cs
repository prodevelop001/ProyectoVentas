using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Millet.SGV.Data.Seguridad
{
    public class Usuario
    {
        public static List<Entities.Usuario> GetUsuarios(Entities.Usuario u)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entities.Usuario));
                    if (u.PkUsuario != 0 && u.PkUsuario.ToString() != "")
                        crit.Add(Restrictions.Like("PkUsuario", u.PkUsuario));
                    if (!string.IsNullOrEmpty(u.Alias))
                        crit.Add(Restrictions.Like("Alias", u.Alias));
                    if (!string.IsNullOrEmpty(u.Clave))
                        crit.Add(Restrictions.Like("Clave", u.Clave));
                    if (u.Activo != null)
                    {
                        crit.Add(Restrictions.Eq("Activo", u.Activo));
                    }
                    if (u.FchRegistro != null)
                    {
                        crit.Add(Restrictions.Between("FchRegistro", u.FchRegIni, u.FchRegFin));
                    }
                    if (u.IdUsuarioReg != 0 && u.IdUsuarioReg.ToString() != "")
                        crit.Add(Restrictions.Like("IdUsuarioReg", u.IdUsuarioReg));
                    if (u.FchActualizacion != null)
                    {
                        crit.Add(Restrictions.Between("FchActualizacion", u.FchActIni, u.FchActFin));
                    }
                    if (u.IdUsuarioAct != 0 && u.IdUsuarioAct.ToString() != "")
                        crit.Add(Restrictions.Like("IdUsuarioAct", u.IdUsuarioAct));
                    if (u.FchSession != null)
                    {
                        crit.Add(Restrictions.Like("FchSession", u.FchSession));
                    }
                    if (!string.IsNullOrEmpty(u.TokenSession))
                        crit.Add(Restrictions.Like("TokenSession", u.TokenSession));

                    return (List<Entities.Usuario>)crit.List<Entities.Usuario>();
                }
            }
            catch (Exception err)
            {
                return new List<Entities.Usuario>();
            }
        }

        public static bool Actualizar(Entities.Usuario us)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    session.Update(us);
                    session.Flush();
                    session.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

    }
}
