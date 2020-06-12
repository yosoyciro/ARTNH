using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EmpresaNroPoliza
    {
        public EmpresaNroPoliza()
        {
        }

        public virtual double CUIT { get; set; }
        public virtual double NroPoliza { get; set; }
        public virtual DateTime VigenciaDesde { get; set; }
        public virtual DateTime VigenciaHasta { get; set; }
        public virtual int Interno { get; set; }
    }
}
