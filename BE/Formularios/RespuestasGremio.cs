using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Formularios
{
    public class RespuestasGremio
    {
        public RespuestasGremio()
        {

        }

        public virtual int Interno { get; set; }
        public virtual int InternoRespuestaFormulario { get; set; }
        public virtual string Legajo { get; set; }
        public virtual string Nombre { get; set; }
    }
}
