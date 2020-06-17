using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Formularios
{
    public class RespuestasCuestionario
    {
        public RespuestasCuestionario()
        {
        }
        public virtual int Interno { get; set; }
        public virtual int InternoCuestionario { get; set; }
        public virtual int InternoRespuestaFormulario { get; set; }
        public virtual string Respuesta { get; set; }
        public virtual int FechaRegularizacion { get; set; }
        public virtual string Observaciones { get; set; }
        public virtual DateTime FechaRegularizacionNormal { get; set; }
        public virtual string EstadoAccion { get; set; }
        public virtual int EstadoFecha { get; set; }
        public virtual string EstadoSituacion { get; set; }
        public virtual int BajaMotivo { get; set; }
    }
}
