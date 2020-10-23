using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Formularios
{
    public class ReferenteDatos
    {
        public ReferenteDatos()
        {
        }
        public virtual int Interno { get; set; }
        public virtual double CUIT { get; set; }
        public virtual string TipoDocumento { get; set; }
        public virtual double NroDocumento { get; set; }
        public virtual string RazonSocial { get; set; }
        public virtual string EstadoClave { get; set; }
        public virtual int FechaNacimiento { get; set; }
        public virtual string DomicilioCalle { get; set; }
        public virtual string DomicilioNro { get; set; }
        public virtual string DomicilioPiso { get; set; }
        public virtual string DomicilioDpto { get; set; }
        public virtual string DomicilioEntreCalle1 { get; set; }
        public virtual string DomicilioEntreCalle2 { get; set; }
        public virtual string CodLocalidadSRT { get; set; }
        public virtual string Telefonos { get; set; }
        public virtual string email { get; set; }
        public virtual string ActividadPrincipal { get; set; }
        public virtual int IdActividadPrincipal { get; set; }
        public virtual double IdPersona { get; set; }
        public virtual string TipoPersona { get; set; }
        public virtual string TipoClave { get; set; }

        //Propiedades de otras entidades
        public virtual DateTime? NotificacionRGRL { get; set; }
    }
}
