using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DenunciaInstancia
    {
        public DenunciaInstancia()
        {
        }

        public virtual int Interno { get; set; }
        public virtual int Denuncia { get; set; }
        public virtual int Fecha { get; set; }
        public virtual int Hora { get; set; }
        public virtual string TipoInstancia { get; set; }
        public virtual string Comentario { get; set; }
        public virtual Byte[] Formulario { get; set; }
    }
}
