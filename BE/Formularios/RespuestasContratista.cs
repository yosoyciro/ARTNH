using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Formularios
{
    public class RespuestasContratista
    {
        public RespuestasContratista()
        {

        }

        public virtual int Interno { get; set; }
        public virtual int InternoRespuestaFormulario { get; set; }
        public virtual double CUIT { get; set; }
        public virtual string Contratista { get; set; }
        public virtual string EstadoAccion { get; set; }
        public virtual int EstadoFecha { get; set; }
        public virtual string EstadoSituacion { get; set; }
        public virtual int BajaMotivo { get; set; }
        public virtual int Renglon { get; set; }
    }
}
