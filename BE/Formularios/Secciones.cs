using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Formularios
{
    public class Secciones
    {
        public Secciones()
        {
        }

        public virtual int Interno { get; set; }
        public virtual int InternoFormulario { get; set; }
        public virtual int Orden { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string TieneNoAplica { get; set; }
        public virtual string Comentario { get; set; }
        public virtual int Pagina { get; set; }
        public virtual byte Baja { get; set; }

    }
}
