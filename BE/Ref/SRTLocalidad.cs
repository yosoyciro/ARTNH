using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Ref
{
    public class SRTLocalidad
    {
        public virtual int Interno { get; set; }
        public virtual string Nombre { get; set; }
        public virtual int ProvinciaDGI { get; set; }
        public virtual int ProvinciaId { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string NombreProvincia { get; set; }
        public virtual string NombreCompleto { get; set; }
        public virtual int CodPostal { get; set; }
        //public virtual IList<BE.AfiliadoDatos> AfiliadoDatos { get; set; }
    }
}
