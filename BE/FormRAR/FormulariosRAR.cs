using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.FormRAR
{
    public class FormulariosRAR
    {
        public FormulariosRAR()
        {
        }
        public virtual int Interno { get; set; }
        public virtual int InternoEstablecimiento { get; set; }
        public virtual int CantTrabajadoresExpuestos { get; set; }
        public virtual int CantTrabajadoresNoExpuestos { get; set; }
        public virtual System.DateTime? FechaCreacion { get; set; }
        public virtual System.DateTime? FechaPresentacion { get; set; }
        public virtual int InternoPresentacion { get; set; }

    }
}
