using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PolizaCabecera
    {
        public virtual int Interno { get; set; }
        public virtual int PolizaNumero { get; set; }
        //public virtual int PolizaSPD { get; set; }
        //public virtual int PolizaDigital { get; set; }
        public virtual double EmpleadorCUIT { get; set; }
        public virtual int FechaInicio { get; set; }
        public virtual int FechaFinal { get; set; }
        //public virtual string PolizaEstado { get; set; }
    }
}
