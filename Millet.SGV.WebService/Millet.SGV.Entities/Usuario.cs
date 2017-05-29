using System;

namespace Millet.SGV.Entities
{
    public class Usuario
    {
        public virtual int PkUsuario { get; set; }
        public virtual string Alias { get; set; }
        public virtual string Clave { get; set; }
        public virtual bool? Activo { get; set; }
        public virtual DateTime? FchRegistro { get; set; }
        public virtual int IdUsuarioReg { get; set; }
        public virtual DateTime? FchActualizacion { get; set; }
        public virtual int IdUsuarioAct { get; set; }
        public virtual DateTime? FchSession { get; set; }
        public virtual string TokenSession { get; set; }

        public virtual DateTime? FchRegIni { get; set; }
        public virtual DateTime? FchRegFin { get; set; }
        public virtual DateTime? FchActIni { get; set; }
        public virtual DateTime? FchActFin { get; set; }
        public virtual Error _Error { get; set; }
    }
}
