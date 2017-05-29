using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace Millet.SGV.Data.Seguridad
{
    public class Personas
    {
        public List<Entities.Persona> GetPersonas(Entities.Persona p)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entities.Persona));
                    if (p.PkPersona != 0 && p.PkPersona.ToString() != "")
                        crit.Add(Restrictions.Eq("PkPersona", p.PkPersona));
                    if (!string.IsNullOrEmpty(p.Nombre))
                        crit.Add(Restrictions.Like("ApPaterno", p.ApPaterno));
                    if (!string.IsNullOrEmpty(p.Nombre))
                        crit.Add(Restrictions.Like("ApMaterno", p.ApMaterno));
                    if(p.FchNacimiento != null)
                    {
                        crit.Add(Restrictions.Between("FchNacimiento", p.FchIniNac, p.FchFinNac));
                    }
                    if (p.FchContratacion != null)
                    {
                        crit.Add(Restrictions.Between("FchContratacion", p.FchIniCon, p.FchFinCon));
                    }
                    if (!string.IsNullOrEmpty(p.Nombre))
                        crit.Add(Restrictions.Like("NSS", p.Nss));
                    if (!string.IsNullOrEmpty(p.Nombre))
                        crit.Add(Restrictions.Like("RFC", p.Rfc));
                    if(p.Activo!=null)
                    {
                        crit.Add(Restrictions.Eq("Activo", p.Activo));
                    }

                    return (List<Entities.Persona>)crit.List<Entities.Persona>();
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }
    }
}
