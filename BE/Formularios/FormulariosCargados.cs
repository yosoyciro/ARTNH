using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Formularios
{
    public class FormulariosCargados
    {
        public FormulariosCargados()
        {
        }
        public virtual Int32 Interno { get; set; }
        public virtual double CUIT { get; set;}
        public virtual string RazonSocial { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Estado { get; set; }
        public virtual DateTime CreacionFechaHora { get; set; }
        public virtual DateTime CompletadoFechaHora { get; set; }
        public virtual Int32 InternoFormulario { get; set; }
        public virtual Int32 InternoEstablecimiento { get; set; }

    }
}
