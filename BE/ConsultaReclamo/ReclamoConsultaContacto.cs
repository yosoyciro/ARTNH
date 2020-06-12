using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ReclamoConsultaContacto
    {

        public ReclamoConsultaContacto()
        {
        }

        public virtual int Interno { get; set; }
        public virtual int DocTipo { get; set; }
        public virtual float DocNro { get; set; }
        public virtual int TrabajadorEmpleador { get; set; }
        public virtual string Nombre { get; set; }
        public virtual List<ReclamoConsultaMedio> RefReclamoConsultaMedio { get; set; }

        //public virtual List<RefReclamoConsultaResponder> RefReclamoConsultaResponder { get; set; }   
    }
}
