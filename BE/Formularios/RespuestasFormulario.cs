using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Formularios
{
    public class RespuestasFormulario
    {
        public RespuestasFormulario()
        {
        }

        public virtual int Interno { get; set; }
        public virtual int InternoFormulario { get; set; }
        public virtual int InternoEstablecimiento { get; set; }
        public virtual DateTime CreacionFechaHora { get; set; }
        public virtual DateTime? CompletadoFechaHora { get; set; }
        public virtual DateTime NotificacionFecha { get; set; }
        public virtual List<BE.Formularios.RespuestasCuestionario> RespuestasCuestionario { get; set; }
        public virtual List<RespuestasGremio> RespuestasGremio { get; set; }
        public virtual List<RespuestasContratista> RespuestasContratista { get; set; }
        public virtual List<RespuestasResponsable> RespuestasResponsable { get; set; }
    }
}
