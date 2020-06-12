using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Ref
{
    public class SRTSVCCTSustancias
    {
        public SRTSVCCTSustancias()
        { }
        public virtual int Interno { get; set; }
        public virtual int CODIGO { get; set; }
        public virtual string DESCRIPCION { get; set; }
        public virtual int CODIGOESOP { get; set; }
    }
}
