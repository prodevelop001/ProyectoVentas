using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace Millet.SGV.Data.Seguridad
{
    public class Personas
    {
        public List<Entities.Personas> GetPersonas(Entities.Personas p)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entities.Personas));
                    if (p.PkPersona != 0 && p.PkPersona.ToString() != "")
                        crit.Add(Restrictions.Eq("PkPersona", p.PkPersona));
                    if (!string.IsNullOrEmpty(p.Nombre))
                        crit.Add(Restrictions.Like("Nombre", p.Nombre));

                   return (List<Entities.Personas>)crit.List<Entities.Personas>();
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }
    }
}
