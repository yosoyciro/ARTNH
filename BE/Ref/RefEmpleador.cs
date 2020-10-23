using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Ref
{
    public class RefEmpleador
    {
        public virtual int Interno { get; set; }
        public virtual double CUIT { get; set; }
        public virtual double CuilFirmante1 { get; set; }
        public virtual string Nombre1 { get; set; }
        public virtual double CuilFirmante2 { get; set; }
        public virtual string Nombre2 { get; set; }
        public virtual string Comentario { get; set; }
        public virtual int ContratoNro { get; set; }
        public virtual int CIIU { get; set; }        
        public virtual DateTime? NotificacionRGRL { get; set; }
    }
}
