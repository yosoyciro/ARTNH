using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ReclamoConsultaMedio
    {
        public ReclamoConsultaMedio()
         { 
         }
        public virtual int Interno { get; set; }
        public virtual int Contacto { get; set; }
        public virtual char Tipo { get; set; }
        public virtual string Direccion { get; set; }
    }
}
