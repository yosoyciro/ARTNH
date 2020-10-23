using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Formularios
{
    public class Presentaciones
    {
        public virtual int Interno { get; set; }
        public virtual double CUIT { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Estado { get; set; }
        public virtual string Tipo { get; set; }
        //public virtual System.DateTime? FechaHoraGeneracion { get; set; }
    }
}
