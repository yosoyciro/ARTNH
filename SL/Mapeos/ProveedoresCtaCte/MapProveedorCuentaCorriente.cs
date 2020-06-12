using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using BE.ProveedoresCtaCte;

namespace SL
{
    public class MapProveedorCuentaCorriente : ClassMapping<ProveedorCuentaCorriente>
    {
        public MapProveedorCuentaCorriente()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.CUIT);
            Property(p => p.TipoMov);
            Property(p => p.FechaMovimiento);
            Property(p => p.FechaMovimientoNormal, m =>
            {
                m.Formula("dbo.ClarionToDate(FechaMovimiento)");
            });
            Property(p => p.Letra);
            Property(p => p.Sucursal);
            Property(p => p.Numero);
            Property(p => p.Importe);
            Property(p => p.NumeroRecibo);
            Property(p => p.FechaRecibo);
            Property(p => p.FechaReciboNormal, m =>
            {
                m.Formula("dbo.ClarionToDate(FechaRecibo)");
            });
            Property(p => p.Imagen);
        }
    }
}
