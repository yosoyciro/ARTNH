using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ReclamoConsulta
    {

        public ReclamoConsulta()
         { 
         }

        public virtual int Interno { get; set; }
        public virtual int Operador { get; set; }
        public virtual int Origen { get; set; }
        public virtual int Tramite { get; set; }
        public virtual int Tema { get; set; }
        public virtual int Categoria { get; set; }
        public virtual int Contacto { get; set; }
        public virtual DateTime Apertura { get; set; }
        public virtual DateTime? Cierre { get; set; }
        public virtual Int64 Siniestro { get; set; }
        public virtual int ContactoDomicilioInterno { get; set; }
        public virtual ReclamoConsultaContacto RefReclamoConsultaContacto { get; set; }
        public virtual ReclamoConsultaDetalle RefReclamoConsultaDetalle { get; set; }
        
    }
}
