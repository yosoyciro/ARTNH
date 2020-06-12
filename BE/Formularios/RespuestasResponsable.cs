using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Formularios
{
    public class RespuestasResponsable
    {
        public RespuestasResponsable()
        {

        }

        public virtual int Interno { get; set; }
        public virtual int InternoRespuestaFormulario { get; set; }
        public virtual double CUIT { get; set; }
        public virtual string Responsable { get; set; }
        public virtual string Cargo { get; set; }
        public virtual string Representacion { get; set; }
        public virtual byte EsContratado { get; set; }
        public virtual string TituloHabilitante { get; set; }
        public virtual string Matricula { get; set; }
        public virtual string EntidadOtorganteTitulo { get; set; }
    }
}
