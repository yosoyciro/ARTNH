using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Formularios
{
    public class Cuestionarios
    {
        public Cuestionarios()
        {

        }

        public virtual int Interno { get; set; }
        public virtual int InternoSeccion { get; set; }
        public virtual int Orden { get; set; }
        public virtual int Codigo { get; set; }
        public virtual string Pregunta { get; set; }
        public virtual string Comentario { get; set; }     
        public virtual int BajaFecha { get; set; }
    }
}
