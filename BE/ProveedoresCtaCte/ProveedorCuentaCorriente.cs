using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.ProveedoresCtaCte
{
    public class ProveedorCuentaCorriente
    {
        public ProveedorCuentaCorriente()
        {

        }
        public virtual int Interno { get; set; }
        public virtual double CUIT { get; set; }
        public virtual string TipoMov { get; set; }
        public virtual int FechaMovimiento { get; set; }
        public virtual DateTime? FechaMovimientoNormal { get; set; }
        public virtual string Letra { get; set; }
        public virtual int Sucursal { get; set; }
        public virtual int Numero { get; set; }
        public virtual double Importe { get; set; }
        public virtual int NumeroRecibo { get; set; }
        public virtual int FechaRecibo { get; set; }
        public virtual DateTime? FechaReciboNormal { get; set; }
        public virtual Byte[] Imagen { get; set; }

        public virtual List<CtaCtePagos> CtaCtePagos { get; set; }
        public virtual List<CtaCteRetenciones> CtaCteRetenciones { get; set; }
    }
}
