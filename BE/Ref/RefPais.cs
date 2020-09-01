using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Ref
{
    public class RefPais
    {
        public virtual int Codigo { get; set; }
        public virtual string Denominacion { get; set; }
        public virtual string Pais { get; set; }
    }
}