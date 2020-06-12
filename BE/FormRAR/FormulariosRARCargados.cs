using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.FormRAR
{
    public class FormulariosRARCargados
    {
        public FormulariosRARCargados()
        {
        }
        public virtual Int32 Interno { get; set; }
        public virtual double CUIT { get; set; }
        public virtual string RazonSocial { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Estado { get; set; }
        public virtual DateTime FechaCreacion { get; set; }
        public virtual DateTime? FechaPresentacion { get; set; }
        public virtual Int32 InternoEstablecimiento { get; set; }
        public virtual Int32 CantTrabajadoresExpuestos { get; set; }
        public virtual Int32 CantTrabajadoresNoExpuestos { get; set; }    
    }
}

