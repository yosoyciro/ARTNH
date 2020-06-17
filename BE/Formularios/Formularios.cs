using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Formularios
{
    public class Formularios
    {
        public Formularios()
        {

        }
        public virtual int Interno { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual byte CantidadGremios { get; set; }
        public virtual byte CantidadContratistas { get; set; }
        public virtual byte CantidadResponsables { get; set; }
        public virtual string Estado { get; set; }
        public virtual int Decreto { get; set; }
    }
}
