using System;

namespace Millet.SGV.Entities
{
    public class Persona
    {
        public virtual int PkPersona { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string ApPaterno { get; set; }
        public virtual string ApMaterno { get; set; }
        public virtual DateTime? FchNacimiento { get; set; }
        public virtual DateTime? FchContratacion { get; set; }
        public virtual string Nss { get; set; }
        public virtual string Rfc { get; set; }
        public virtual bool? Activo { get; set; }
        public virtual DateTime? FchIniNac { get; set; }
        public virtual DateTime? FchFinNac { get; set; }
        public virtual DateTime? FchIniCon { get; set; }
        public virtual DateTime? FchFinCon { get; set; }

        public virtual Error error { get; set; }
    }
}
