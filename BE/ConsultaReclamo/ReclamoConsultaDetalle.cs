using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ReclamoConsultaDetalle
    {

        public ReclamoConsultaDetalle()
        {
        }

        public virtual int Interno { get; set; }
        public virtual int ReclamoConsulta { get; set; }
        public virtual DateTime Ingreso { get; set; }
        public virtual int Medio { get; set; }
        public virtual string Asunto { get; set; }
        public virtual string Cuerpo { get; set; }
        public virtual char Movimiento { get; set; }
        public virtual int Operador { get; set; }
        public virtual DateTime? Revision { get; set; }
        public virtual string CuerpoHtml { get; set; }

    }
}
