using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.FormRAR
{
    public class FormulariosRARDetalleAgentes
    {
        public FormulariosRARDetalleAgentes()
        { }
        public virtual int Interno { get; set; }
        public virtual int InternoFormulariosRARDetalle { get; set; }
        public virtual int CodigoAgente { get; set; }
    }
}
