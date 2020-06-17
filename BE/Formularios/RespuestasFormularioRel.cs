using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Formularios
{
    public class RespuestasFormularioRel
    {
        public RespuestasFormularioRel()
        { }

        public virtual int Interno { get; set; }
        public virtual int InternoRespuestaFormularioOriginal { get; set; }
        public virtual int InternoRespuestaFormularioNuevo { get; set; }
    }
}
