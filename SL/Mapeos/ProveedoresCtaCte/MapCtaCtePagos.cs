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
    public class MapCtaCtePagos : ClassMapping<CtaCtePagos>
    {
        public MapCtaCtePagos()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.InternoCtaCteProv);
            Property(p => p.InternoCtaCteTiposPago);
            Property(p => p.Concepto);
            Property(p => p.Importe);
        }
    }
}
