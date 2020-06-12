using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PrestadorDatos
    {
        public PrestadorDatos()
        {
        }
        public virtual int Interno { get; set; }
        public virtual double CUIT { get; set; }
        public virtual string RazonSocial { get; set; }
}
}
